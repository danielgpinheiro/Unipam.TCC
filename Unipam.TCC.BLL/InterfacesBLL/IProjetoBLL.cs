using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfaceBLL
{
    public interface IProjetoBLL
    {

        string Salvar(Projeto projeto);

        string Excluir(int idprojeto);

        Projeto Obter(int idprojeto);

        IList<Projeto> Todos();

        IList<Projeto> Listar(string nome);
    }
}
