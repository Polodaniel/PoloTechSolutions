using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.Cadastros;
using Models.Ponto;
using PontoEletronicoWeb.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        #region Set Tabelas no Contexto
        public DbSet<Biometria> Biometria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Escala> Escala { get; set; }
        public DbSet<FolhaPonto> FolhaPonto { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<EscalaFuncionario> EscalaFuncionario { get; set; }
        #endregion
    }
}
