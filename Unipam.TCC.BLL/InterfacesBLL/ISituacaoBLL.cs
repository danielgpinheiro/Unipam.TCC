using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface ISituacaoBLL
    {

        string Salvar(Situacao situacao);

        string Excluir(int idSituacao);

        IList<Situacao> Todas();

        Situacao ObterPorId(int idSituacao);

        void Dispose();
    }
}
