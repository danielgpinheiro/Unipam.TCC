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
    public class SituacaoBLL : ISituacaoBLL
    {
        //Repositorios
        private readonly ISituacaoRepository SituacaoRepository;

        //Inicialização Default
        public SituacaoBLL()
        {
            this.SituacaoRepository = new SituacaoRepository();
        }

        public SituacaoBLL(ISituacaoRepository situacaoRepository)
        {
            this.SituacaoRepository = situacaoRepository;
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            SituacaoRepository.Dispose();
        }

        public string Excluir(int idSituacao)
        {
            try
            {
                Situacao situacao = ObterPorId(idSituacao);
                SituacaoRepository.Excluir(situacao);
                //Executa as ações
                SituacaoRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return "Erro: "+ex.Message;
            }
        }

        public Situacao ObterPorId(int idSituacao)
        {
            return SituacaoRepository.Obter(x => x.IdSituacao == idSituacao);
        }

        public string Salvar(Situacao situacao)
        {
            try
            {
                //Inserir e o Alterar

                if(situacao.IdSituacao == 0)
                {
                    SituacaoRepository.Adicionar(situacao);
                }
                else
                {
                    SituacaoRepository.Alterar(situacao);
                }

                SituacaoRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Situacao> Todas()
        {
            return SituacaoRepository.Todos();
        }
    }
}
