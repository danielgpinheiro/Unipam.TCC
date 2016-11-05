using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.BLL.InterfacesBLL
{
    public interface IAlunoBLL
    {
        string Salvar(Aluno etapa);

        string Excluir(int idAluno);

        IList<Aluno> Todas();

        Aluno ObterPorId(int idAluno);

        void Dispose();
    }
}
