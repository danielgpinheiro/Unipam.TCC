using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface INotaBLL
    {

        string Salvar(Nota nota);

        string Excluir(int IdNota);

        IList<Nota> Todas();

        Nota ObterPorId(int IdNota);

        void Dispose();
    }
}
