using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface ITipoOrientacaoBLL
    {

        string Salvar(TipoOrientacao tipoOrientacao);

        string Excluir(int idTipoOrientacao);

        IList<TipoOrientacao> Todas();

        TipoOrientacao ObterPorId(int idTipoOrientacao);

        void Dispose();
    }
}
