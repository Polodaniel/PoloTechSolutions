using Microsoft.AspNetCore.Mvc;
using Models.ModelView;
using Models.Ponto;
using Models.View.Ponto;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SourceAFIS;
using PontoEletronicoWeb.Server.Models;
using Models.Cadastros;
using Microsoft.EntityFrameworkCore;
using Models.View.Desktop;

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interface
    public interface IFolhaPontoRepository : ICadastroBase<FolhaPonto, FolhaPontoView>
    {
        Task<ActionResult<bool>> RegistraPonto(RegistraPonto registro);

        Task<MarcacaoResultado> GravarPonto(VerificaBiometriaModelView biometriaModelView);
    }
    #endregion  

    public class FolhaPontoRepository : BaseRepository<FolhaPonto, FolhaPontoView>, IFolhaPontoRepository
    {
        #region Construtor
        public FolhaPontoRepository(ApplicationDbContext context) : base(context)
        {
        }
        #endregion

        public async Task<ActionResult<bool>> RegistraPonto(RegistraPonto registro)
        {

            return await Task.FromResult(true);
        }

        public async Task<MarcacaoResultado> GravarPonto(VerificaBiometriaModelView biometriaModelView)
        {
            var Funcionario = await contexto.Funcionario.FindAsync(biometriaModelView.FuncionarioId);

            if (!Equals(Funcionario, null))
            {
                var FolhaPonto = await MontarFolhaPontoAsync(Funcionario, biometriaModelView.ClienteId, biometriaModelView.DataRegistro);

                if (FolhaPonto.Resultado)
                    return FolhaPonto;
                else
                    return FolhaPonto;
            }

            var msgSucesso = $"Ops! Não foi localizado a sua digital. Entre em Contato com o Gestor.";

            return new MarcacaoResultado(true, msgSucesso);
        }

        private async Task<MarcacaoResultado> MontarFolhaPontoAsync(Funcionario funcionario, int clienteId, DateTime DataRegistro)
        {
            var EscalaFuncionario = new EscalaFuncionario();
            var DataFiltro = DataRegistro.Date;
            var horaFiltro = DataRegistro.TimeOfDay;

            // Buscar as Escalas que Pertence ao Funcionario
            var query = contexto.EscalaFuncionario
                                        .Include(x => x.Escala)
                                        .Include(x => x.Escala.Turno)
                                        .Where(x => x.FuncionarioId == funcionario.Id
                                                && x.Escala.ClienteId == clienteId
                                                && DataFiltro >= x.Escala.DataInicio
                                                && DataFiltro <= x.Escala.DataFim)
                                       .AsQueryable();

            var ListaEscalas = await query.ToListAsync();

            if (!Equals(ListaEscalas, null) && ListaEscalas.Count > 0)
            {
                var idEscala = ListaEscalas.Select(x => new
                {
                    x.Id,
                    DataHoraInicial = x.Escala.DataInicio.AddTicks(x.Escala.Turno.HoraInicio.TimeOfDay.Ticks).AddMinutes(-15),
                    DataHoraFinal = x.Escala.DataFim.AddTicks(x.Escala.Turno.HoraioFim.TimeOfDay.Ticks).AddMinutes(15),
                }).Where(x => DataRegistro >= x.DataHoraInicial && DataRegistro <= x.DataHoraFinal)
                  .Select(x => x.Id).FirstOrDefault();

                var escala = ListaEscalas.FirstOrDefault(x => x.Id == idEscala);

                if (escala != null)
                {
                    if (await VerificaMarcacaoRecente(funcionario, DataRegistro, escala))
                    {
                        var msgError = $"Ops! {funcionario.Nome}, foi identificado uma marcação de ponto em um perido bem recente. Tente novamente em alguns segundos !";

                        return new MarcacaoResultado(false, msgError);
                    }

                    var FolhaPonto = new FolhaPonto();

                    FolhaPonto.DataRegistroPonto = DataRegistro;
                    FolhaPonto.FuncionarioId = funcionario.Id;
                    FolhaPonto.EscalaId = escala.EscalaId;
                    FolhaPonto.Status = true;

                    contexto.FolhaPonto.Add(FolhaPonto);

                    await contexto.SaveChangesAsync();

                    var msgSucesso = $"Olá {funcionario.Nome}, seu ponto foi marcado com sucesso !\n\n" +
                              $"Marcação realizada {DataRegistro.ToString("dd/MM/yyyy - hh:mm:ss")}";

                    return new MarcacaoResultado(true, msgSucesso);
                }
                else
                {
                    var msgError = $"Olá {funcionario.Nome}, não foi localizado a escala para você! Entre em contato com seu gestor.";

                    return new MarcacaoResultado(false, msgError);
                }
            }

            var msgSemEscala = $"Olá {funcionario.Nome}, não foi localizado a escala para você! Entre em contato com seu gestor.";

            return new MarcacaoResultado(false, msgSemEscala);
        }

        private async Task<bool> VerificaMarcacaoRecente(Funcionario funcionario, DateTime dataRegistro, EscalaFuncionario escala)
        {
            var result = false;

            var ListaMarcacaoRecente = await contexto.FolhaPonto.Where(x => x.FuncionarioId == funcionario.Id
                                                                   && x.EscalaId == escala.EscalaId).ToListAsync();

            var MarcacaoRecente = ListaMarcacaoRecente.Select(x => new
            {
                x.Id,
                DataRegistro = x.DataRegistroPonto,
                DataRegistroFinal = x.DataRegistroPonto.AddMinutes(2)
            }).Where(x => x.DataRegistroFinal >= dataRegistro).ToList();


            if (!Equals(MarcacaoRecente, null) && MarcacaoRecente.Count > 0)
                result = true;

            return result;
        }

        private List<UserDetails> MontaListaCandidadosAsync(List<Biometria> listaFuncionarios)
        {
            var ListaCandidatos = new List<UserDetails>();

            listaFuncionarios.ForEach(x =>
            {
                var Obj = new UserDetails();
                Obj.Id = x.FuncionarioId;
                Obj.Name = x.Funcionario.Nome;
                Obj.Template = new FingerprintTemplate(x.BiometriaImg);

                ListaCandidatos.Add(Obj);
            });

            return ListaCandidatos;
        }

        private FingerprintMatcher MontarDigital(byte[] biometriaImg) =>
             new FingerprintMatcher(new FingerprintTemplate(biometriaImg));
    }
}
