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

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interface
    public interface IFolhaPontoRepository : ICadastroBase<FolhaPonto, FolhaPontoView>
    {
        Task<ActionResult<bool>> RegistraPonto(RegistraPonto registro);
        Task<bool>VerificaBiometria( VerificaBiometriaModelView biometriaModelView);
    }
    #endregion  

    public class FolhaPontoRepository: BaseRepository<FolhaPonto,FolhaPontoView>, IFolhaPontoRepository
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

        public async Task<bool> VerificaBiometria(VerificaBiometriaModelView biometriaModelView)
        {
            //Verifica aqui
            return false;
        }
    }
}
