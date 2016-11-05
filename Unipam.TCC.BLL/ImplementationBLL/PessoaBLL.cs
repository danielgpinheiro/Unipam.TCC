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
    public class PessoaBLL : IPessoaBLL
    {
        private readonly IPessoaRepository PessoaRepository;

        public PessoaBLL()
        {
            this.PessoaRepository = new PessoaRepository();
        }

        public PessoaBLL(IPessoaRepository PessoaRepository)
        {
            this.PessoaRepository = PessoaRepository;
        }

        public void Dispose()
        {
            PessoaRepository.Dispose();
        }

        public string Excluir(int idPessoa)
        {
            try
            {
                Pessoa pessoa = ObterPorId(idPessoa);
                PessoaRepository.Excluir(pessoa);
                //Executa as ações
                PessoaRepository.SalvarAlteracoes();

                return null;
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Pessoa ObterPorId(int idPessoa)
        {
            return PessoaRepository.Obter(x => x.IdPessoa == idPessoa);
        }

        public Pessoa ObterPorNome(string Nome)
        {
            return PessoaRepository.Obter(x => x.Nome == Nome);
        }

        public string Salvar(Pessoa pessoa)
        {
            try
            {
                if (pessoa.IdPessoa == 0)
                {
                    PessoaRepository.Adicionar(pessoa);
                }
                else
                {
                    PessoaRepository.Alterar(pessoa);
                }
                PessoaRepository.SalvarAlteracoes();

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Pessoa> Todas()
        {
            return PessoaRepository.Todos().ToList();
        }
    }
}
