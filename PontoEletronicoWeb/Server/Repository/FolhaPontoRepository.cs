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

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interface
    public interface IFolhaPontoRepository : ICadastroBase<FolhaPonto, FolhaPontoView>
    {
        Task<ActionResult<bool>> RegistraPonto(RegistraPonto registro);
        Task<bool> GravarPonto(VerificaBiometriaModelView biometriaModelView);
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

        public async Task<bool> GravarPonto(VerificaBiometriaModelView biometriaModelView)
        {
            var Funcionario = await contexto.Funcionario.FindAsync(biometriaModelView.FuncionarioId);

            if (!Equals(Funcionario, null))
            {
                var FolhaPonto = await MontarFolhaPontoAsync(Funcionario, biometriaModelView.DataRegistro);

                if (FolhaPonto)
                    return true;
            }

            return false;
        }

        private async Task<bool> MontarFolhaPontoAsync(Funcionario funcionario, DateTime DataRegistro)
        {
            var EscalaFuncionario = new EscalaFuncionario();
            var DataFiltro = new DateTime(DataRegistro.Year, DataRegistro.Month, DataRegistro.Day);

            // Buscar as Escalas que Pertence ao Funcionario
            var query = contexto.EscalaFuncionario
                                        .Include(x => x.Escala)
                                        .Include(x => x.Escala.Turno)
                                        .Where(x => x.FuncionarioId == funcionario.Id
                                                && DataFiltro >= x.Escala.DataInicio
                                                && DataFiltro <= x.Escala.DataFim)
                                       .AsQueryable();

            var ListaEscalas = query.ToList();

            if (!Equals(ListaEscalas, null) && ListaEscalas.Count > 0)
            {
                if (ListaEscalas.Count == 1)
                {
                    var FolhaPonto = new FolhaPonto();
                    
                    FolhaPonto.DataRegistroPonto = DataRegistro;
                    FolhaPonto.FuncionarioId = funcionario.Id;
                    FolhaPonto.EscalaId = ListaEscalas.FirstOrDefault().EscalaId;
                    FolhaPonto.Status = true;

                    contexto.FolhaPonto.Add(FolhaPonto);

                    await contexto.SaveChangesAsync();

                    return true;
                }
            }

            return false;
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
