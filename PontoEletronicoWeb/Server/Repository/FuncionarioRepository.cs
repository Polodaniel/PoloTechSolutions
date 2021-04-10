using Models.Cadastros;
using Models.View;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interfaces
    public interface IFuncionarioRepository : ICadastroBase<Funcionario, FuncionarioView>
    {

    }
    #endregion

    public class FuncionarioRepository : BaseRepository<Funcionario,FuncionarioView>, IFuncionarioRepository
    {
        #region Construtor
        public FuncionarioRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion
    }
}
