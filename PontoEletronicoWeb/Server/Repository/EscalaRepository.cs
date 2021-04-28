using Microsoft.EntityFrameworkCore;
using Models.Ponto;
using Models.View;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Auxiliares;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interfaces
    public interface IEscalaRepository : ICadastroBase<Escala, EscalaView>
    {
        Task<List<EscalaView>> RetornaListViewEscala(FiltroEscala filtro);
        Task<List<EscalaFuncionario>> RetornaEscalaFuncionario(int Id);
    }
    #endregion

    public class EscalaRepository : BaseRepository<Escala, EscalaView>, IEscalaRepository
    {
        #region Construtor
        public EscalaRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion

        #region Metodos override
        public async override Task<Escala> SalvarAsync(Escala model, int usuarioLogado)
        {
            model.IsValid();

            model.RegistraAlteracao(usuarioLogado);

            var entidade = dbSet.Add(model);
            await contexto.SaveChangesAsync();

            return await Task.FromResult(new Escala());
        }

        public async override Task<Escala> AlterarAsync(Escala objeto, int usuarioId)
        {
            objeto.IsValid();

            var entidade = await dbSet.Include(x => x.Funcionarios).FirstAsync(x => x.Id == objeto.Id);
            IsNull(entidade);

            entidade.Update(objeto, usuarioId);

            #region Atualiza Funcionarios
            var funcionariosAtualizar = entidade.Funcionarios;

            foreach (var funcionario in objeto.Funcionarios)
            {
                var funcAt = funcionariosAtualizar.FirstOrDefault(x => x.Id == funcionario.Id);

                if (funcAt == null)
                {
                    funcionario.RegistraAlteracao(usuarioId);
                    entidade.Funcionarios.Add(funcionario);
                }
                else
                    funcAt.Update(funcionario, usuarioId);
            }
            #endregion

            await contexto.SaveChangesAsync();

            return new Escala();
        }
        #endregion

        #region Listar
        public override async Task<Escala> SelecionarAsync(int id)
        {
            var Novo = new Escala();

            var model = await dbSet.Include(x => x.Funcionarios)
                                        .ThenInclude(x => x.Funcionario)
                                   .Where(x => x.Id == id).FirstOrDefaultAsync();

            
            Novo.Id = model.Id;
            Novo.Status = model.Status;
            Novo.UsuarioId = model.UsuarioId;
            Novo.DtaAtualizacao = model.DtaAtualizacao;
            Novo.DataEscala = model.DataEscala;
            Novo.TurnoId = model.TurnoId;
            Novo.ClienteId = model.ClienteId;
            //Novo.Funcionarios = model.Funcionarios;
            Novo.UsuarioId = model.UsuarioId;

            IsNull(Novo);

            return Novo;
        }
        #endregion

        #region Metodos EscalaRestaurante
        public async Task<List<EscalaView>> RetornaListViewEscala(FiltroEscala filtro)
        {
            var query = dbSetAsQueryable.Include(x => x.Cliente)
                                        .Include(x => x.Turno)
                                        .Include(x => x.Funcionarios)
                                            .ThenInclude(y => y.Funcionario)
                                        .AsEnumerable();

            #region Montando Filtro           

            if (filtro != null)
            {
                if (filtro.Status == true)
                    query = query.Where(x => x.Status == false);
                else
                    query = query.Where(x => x.Status == true);

                if (filtro.DataInicio.HasValue)
                    query = query.Where(x => x.DataEscala >= filtro.DataInicio.Value);

                if (filtro.DataFim.HasValue)
                    query = query.Where(x => x.DataEscala <= filtro.DataFim.Value);

                if (filtro.TurnoId > 0)
                    query = query.Where(x => x.TurnoId == filtro.TurnoId);

                if (filtro.ClienteId > 0)
                    query = query.Where(x => x.ClienteId == filtro.ClienteId);

            }
            #endregion

            var lstView = query.ToList().Select(escala => new EscalaView
            {
                Id = escala.Id,
                Status = escala.Status,
                DataEscala = escala.DataEscala,
                Turno = escala.Turno.Descricao,
                HoraTurno = string.Concat(escala.Turno.HoraInicio.ToShortTimeString(), " - ", escala.Turno.HoraioFim.ToShortTimeString()),
                Cliente = escala.Cliente.Nome,
                ListaFuncionarios = escala.Funcionarios.Where(x => x.Status == true).Select(y => y.Funcionario.Nome).ToList()
            }).ToList();

            return await Task.FromResult(lstView);
        }

        public async Task<List<EscalaFuncionario>> RetornaEscalaFuncionario(int id) 
        {
            var result = await contexto.EscalaFuncionario.Where(x => x.EscalaId == id && x.Status == true).ToListAsync();

            return result;
        }
        #endregion
    }
}
