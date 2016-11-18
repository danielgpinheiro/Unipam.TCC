using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface IUsuarioBLL
    {

        string Salvar(Usuario usuario);

        string Excluir(int IdUsuario);

        IList<Usuario> Todas();

        Usuario ObterPorId(int IdUsuario);

        Usuario BuscarUsuario(Usuario usuario);

        void Dispose();
    }
}
