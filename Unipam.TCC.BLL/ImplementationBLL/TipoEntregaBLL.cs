using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.BLL.InterfacesBLL;
using Unipam.TCC.DAL.Entity;
using Unipam.TCC.DAL.ImplementationRepository;
using Unipam.TCC.DAL.InterfaceRepository;

namespace Unipam.TCC.BLL.ImplementationBLL
{
    public class TipoEntregaBLL : ITipoEntregaBLL
    {
        private ITipoEntregaRepository tipoEntregaRepository;

        public TipoEntregaBLL()
        {
            tipoEntregaRepository = new TipoEntregaRepository();
        }
        //É necessário gerar o outro construtor


        public IList<TipoEntrega> Todos()
        {
            return tipoEntregaRepository.Todos().OrderBy(t => t.Descricao).ToList();
        }
    }
}
