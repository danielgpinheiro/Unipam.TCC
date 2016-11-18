using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.GenericRepository;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.DAL.InterfaceRepository
{
    public interface IProfessorRepository 
        : IGenericRepository<Professor>
    {
    }
}
