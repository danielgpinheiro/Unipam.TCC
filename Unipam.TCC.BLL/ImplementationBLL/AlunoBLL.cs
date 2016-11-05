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
    public class AlunoBLL : IAlunoBLL
    {
        //Repositorios
        private readonly IAlunoRepository AlunoRepository;

        //Inicialização Default
        public AlunoBLL()
        {
            this.AlunoRepository = new AlunoRepository();
        }

        public AlunoBLL(IAlunoRepository AlunoRepository)
        {
            this.AlunoRepository = AlunoRepository;
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            AlunoRepository.Dispose();
        }

        public string Excluir(int idAluno)
        {
            try
            {
                Aluno aluno = ObterPorId(idAluno);
                AlunoRepository.Excluir(aluno);
                //Executa as ações
                AlunoRepository.SalvarAlteracoes();

                return null;

            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Aluno ObterPorId(int idAluno)
        {
            return AlunoRepository.Obter(x => x.IdPessoa== idAluno);
        }

        public string Salvar(Aluno aluno)
        {
            try
            {
                //Inserir e o Alterar

                if (aluno.IdPessoa == 0)
                {
                    AlunoRepository.Adicionar(aluno);
                }
                else
                {
                    AlunoRepository.Alterar(aluno);
                }

                AlunoRepository.SalvarAlteracoes();

                return null;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Aluno> Todas()
        {
            return AlunoRepository.Todos().ToList();
        }
    }
}
