using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface IPessoaBLL
    {
        string Salvar(Pessoa pessoa);

        string Excluir(int idPessoa);

        IList<Pessoa> Todas();

        Pessoa ObterPorId(int idPessoa);

        void Dispose();
    }
}
