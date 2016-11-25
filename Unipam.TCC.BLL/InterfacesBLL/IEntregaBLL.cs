using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface IEntregaBLL
    {

        string Salvar(Entrega entrega);

        string Excluir(int idEntrega);

        IList<Entrega> Todas();

        Entrega ObterPorId(int idEntrega);

        void Dispose();
    }
}
