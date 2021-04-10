using Models.Cadastros;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interface
    public interface IBiometriaRepository : ICadastroBase<Biometria, Biometria>
    {

    }
    #endregion

    public class BiometriaRepository : BaseRepository<Biometria, Biometria>,IBiometriaRepository
    {
        #region Construtor
        public BiometriaRepository(ApplicationDbContext context) : base(context)
        {
        }
        #endregion
    }
}
