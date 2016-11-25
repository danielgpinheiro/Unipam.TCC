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
    public class TipoOrientacaoBLL : ITipoOrientacaoBLL
    {
        //Repositorios
        private readonly ITipoOrientacaoRepository TipoOrientacaoRepository;

        //Inicialização Default
        public TipoOrientacaoBLL()
        {
            this.TipoOrientacaoRepository = new TipoOrientacaoRepository();
        }

        public TipoOrientacaoBLL(ITipoOrientacaoRepository tipoOrientacaoRepository)
        {
            this.TipoOrientacaoRepository = tipoOrientacaoRepository;
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            TipoOrientacaoRepository.Dispose();
        }

        public string Excluir(int idTipoOrientacao)
        {
            try
            {
                TipoOrientacao tipoOrientacao = ObterPorId(idTipoOrientacao);
                TipoOrientacaoRepository.Excluir(tipoOrientacao);
                //Executa as ações
                TipoOrientacaoRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return "Erro: "+ex.Message;
            }
        }

        public TipoOrientacao ObterPorId(int idTipoOrientacao)
        {
            return TipoOrientacaoRepository.Obter(x => x.IdTipoOrientacao == idTipoOrientacao);
        }

        public string Salvar(TipoOrientacao tipoOrientacao)
        {
            try
            {
                //Inserir e o Alterar

                if(tipoOrientacao.IdTipoOrientacao == 0)
                {
                    TipoOrientacaoRepository.Adicionar(tipoOrientacao);
                }
                else
                {
                    TipoOrientacaoRepository.Alterar(tipoOrientacao);
                }

                TipoOrientacaoRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<TipoOrientacao> Todas()
        {
            return TipoOrientacaoRepository.Todos();
        }
    }
}
