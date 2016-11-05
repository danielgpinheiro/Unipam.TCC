using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;
using Unipam.TCC.DAL.GenericRepository;
using Unipam.TCC.DAL.InterfaceRepository;

namespace Unipam.TCC.DAL.ImplementationRepository
{
    public class TipoEntregaRepository 
        : GenericRepository<TipoEntrega>, ITipoEntregaRepository
    {
    }
}
