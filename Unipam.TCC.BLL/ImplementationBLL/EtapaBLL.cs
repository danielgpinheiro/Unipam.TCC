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
    public class EtapaBLL : IEtapaBLL
    {
        //Repositorios
        private readonly IEtapaRepository EtapaRepository;

        //Inicialização Default
        public EtapaBLL()
        {
            this.EtapaRepository = new EtapaRepository();
        }

        public EtapaBLL(IEtapaRepository etapaRepository)
        {
            this.EtapaRepository = etapaRepository;
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            EtapaRepository.Dispose();
        }

        public string Excluir(int idEtapa)
        {
            try
            {
                Etapa etapa = ObterPorId(idEtapa);
                EtapaRepository.Excluir(etapa);
                //Executa as ações
                EtapaRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return "Erro: "+ex.Message;
            }
        }

        public Etapa ObterPorId(int idEtapa)
        {
            return EtapaRepository.Obter(x => x.IdEtapa == idEtapa);
        }

        public string Salvar(Etapa etapa)
        {
            try
            {
                //Inserir e o Alterar

                if(etapa.IdEtapa == 0)
                {
                    EtapaRepository.Adicionar(etapa);
                }
                else
                {
                    EtapaRepository.Alterar(etapa);
                }

                EtapaRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Etapa> Todas()
        {
            return EtapaRepository.Todos();
        }
    }
}
