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
    public class EntregaBLL : IEntregaBLL
    {
        //Repositorios
        private readonly IEntregaRepository EntregaRepository;

        //Inicialização Default
        public EntregaBLL()
        {
            this.EntregaRepository = new EntregaRepository();
        }

        public EntregaBLL(IEntregaRepository entregaRepository)
        {
            this.EntregaRepository = entregaRepository;
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            EntregaRepository.Dispose();
        }

        public string Excluir(int idEntrega)
        {
            try
            {
                Entrega entrega = ObterPorId(idEntrega);
                EntregaRepository.Excluir(entrega);
                //Executa as ações
                EntregaRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return "Erro: "+ex.Message;
            }
        }

        public Entrega ObterPorId(int idEntrega)
        {
            return EntregaRepository.Obter(x => x.IdEntrega == idEntrega);
        }

        public string Salvar(Entrega entrega)
        {
            try
            {
                //Inserir e o Alterar

                if(entrega.IdEntrega == 0)
                {
                    EntregaRepository.Adicionar(entrega);
                }
                else
                {
                    EntregaRepository.Alterar(entrega);
                }

                EntregaRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Entrega> Todas()
        {
            return EntregaRepository.Todos();
        }
    }
}
