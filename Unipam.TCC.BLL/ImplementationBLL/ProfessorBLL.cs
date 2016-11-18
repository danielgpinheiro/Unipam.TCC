using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unipam.TCC.DAL.Entity;
using Unipam.TCC.BLL.InterfacesBLL;
using Unipam.TCC.DAL.InterfaceRepository;
using Unipam.TCC.DAL.ImplementationRepository;

namespace Unipam.TCC.BLL.ImplementationBLL
{
    public class ProfessorBLL : IProfessorBLL
    {
        //Repositorios
        private readonly IProfessorRepository ProfessorRepository;

        //Inicialização Default
        public ProfessorBLL()
        {
            this.ProfessorRepository = new ProfessorRepository();
        }

        public ProfessorBLL(IProfessorRepository professorRepository)
        {
            this.ProfessorRepository = professorRepository;
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            ProfessorRepository.Dispose();
        }

        public string Excluir(int idProfessor)
        {
            try
            {
                Professor professor = ObterPorId(idProfessor);
                ProfessorRepository.Excluir(professor);
                //Executa as ações
                ProfessorRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return "Erro: "+ex.Message;
            }
        }

        public Professor ObterPorId(int idProfessor)
        {
            return ProfessorRepository.Obter(x => x.IdPessoa == idProfessor);
        }

        public string Salvar(Professor professor)
        {
            try
            {
                //Inserir e o Alterar

                if(professor.IdPessoa == 0)
                {
                    ProfessorRepository.Adicionar(professor);
                }
                else
                {
                    ProfessorRepository.Alterar(professor);
                }

                ProfessorRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Professor> Todas()
        {
            return ProfessorRepository.Todos();
        }
    }
}
