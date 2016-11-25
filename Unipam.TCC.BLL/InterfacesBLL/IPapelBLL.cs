using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface IPapelBLL
    {

        string Salvar(Papel papel);

        string Excluir(int idPapel);

        IList<Papel> Todas();

        Papel ObterPorId(int idPapel);

        void Dispose();
    }
}
