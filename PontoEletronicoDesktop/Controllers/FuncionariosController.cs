using PontoEletronicoDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Controllers
{
    public class FuncionariosController
    {
        //DataBaseContext context = new DataBaseContext();

        //public List<Funcionario> BuscaFuncionarios() =>
        //    context.Funcionarios.ToList();

        //public List<Funcionario> BuscaFuncionarios(bool Desativado) =>
        //    context.Funcionarios.Where(x => x.Desativado == Desativado).ToList();

        //public List<Funcionario> BuscaFuncionarios(bool Desativado, bool PossuiBiometria) =>
        //    context.Funcionarios.Where(x => x.Desativado == Desativado && x.PossuiBiometria == PossuiBiometria).ToList();

        //public Funcionario Selecionar(int CodigoFuncionario) =>
        //    context.Funcionarios.Find(CodigoFuncionario);

        //public bool Salvar(Funcionario funcionario)
        //{
        //    try
        //    {
        //        context.Entry(funcionario).State = System.Data.Entity.EntityState.Modified;
        //        context.SaveChanges();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public List<FuncinarioView> BuscaFuncionariosBiometria()
        //{
        //    return BuscaFuncionarios().Select(x => new FuncinarioView
        //    {
        //        Codigo = x.Id,
        //        Nome = x.Nome,
        //        Biometrias = x.Biometrias
        //    }).ToList();
        //}

        //public Funcionario BuscarFuncionario(int Id) =>
        //    BuscaFuncionarios().Where(x => x.Id == Id).FirstOrDefault();
    }
}
