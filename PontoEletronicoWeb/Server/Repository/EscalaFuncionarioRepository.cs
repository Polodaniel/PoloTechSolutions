using Models.Ponto;
using Models.View;
using Models.View.Ponto;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PontoEletronicoWeb.Server.Repository
{
    #region Interfaces
    public interface IEscalaFuncionarioRepository : ICadastroBase<EscalaFuncionario, EscalaFuncionarioView>
    {

    }
    #endregion

    public class EscalaFuncionarioRepository : BaseRepository<EscalaFuncionario, EscalaFuncionarioView>, IEscalaFuncionarioRepository
    {
        #region Construtor
        public EscalaFuncionarioRepository(ApplicationDbContext context) : base(context)
        {

        }

        #endregion
    }
}
