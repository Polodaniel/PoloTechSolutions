using Microsoft.EntityFrameworkCore;
using Models.Cadastros;
using Models.ModelView;
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
        Task<bool> SalvarAsync(FuncionarioBiometrias funcionarioBiometrias);

        Task<bool> ExcluirBiometriasAsync(int CodFuncionario);
    }
    #endregion

    public class BiometriaRepository : BaseRepository<Biometria, Biometria>, IBiometriaRepository
    {
        #region Construtor
        public BiometriaRepository(ApplicationDbContext context) : base(context)
        {
        }
        #endregion

        public async Task<bool> SalvarAsync(FuncionarioBiometrias funcionarioBiometrias)
        {
            try
            {
                var biometrias = funcionarioBiometrias.Biometrias;

                if (!Equals(biometrias, null) && biometrias.Count > 0)
                {
                    var funcionario = await contexto.Funcionario.Include(x => x.Biometrias)
                                                            .FirstAsync(x => x.Id == funcionarioBiometrias.CodFuncionario);

                    if (!Equals(funcionario, null))
                    {
                        funcionario.PossuiBiometria = true;
                        funcionario.Biometrias.AddRange(biometrias);

                        //await dbSet.AddRangeAsync(biometrias);
                        await contexto.SaveChangesAsync();
                    }
                }

                return await Task.FromResult(true);
            }
            catch (Exception erro)
            {
                var msgErro = erro.Message;
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> ExcluirBiometriasAsync(int CodFuncionario)
        {

            var lstRemover = await dbSetAsQueryable.Where(x => x.FuncionarioId == CodFuncionario).ToArrayAsync();

            if (lstRemover == null || lstRemover.Count() == 0)
                return false;

            dbSet.RemoveRange(lstRemover);
            await contexto.SaveChangesAsync();

            return true;
        }

    }
}
