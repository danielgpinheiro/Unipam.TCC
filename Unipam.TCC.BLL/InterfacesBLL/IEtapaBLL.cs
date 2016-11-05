using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface IEtapaBLL
    {

        string Salvar(Etapa etapa);

        string Excluir(int idEtapa);

        IList<Etapa> Todas();

        Etapa ObterPorId(int idEtapa);

        void Dispose();
    }
}
