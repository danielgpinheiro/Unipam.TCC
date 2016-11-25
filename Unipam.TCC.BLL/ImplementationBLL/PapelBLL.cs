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
    public class PapelBLL : IPapelBLL
    {
        //Repositorios
        private readonly IPapelRepository PapelRepository;

        //Inicialização Default
        public PapelBLL()
        {
            this.PapelRepository = new PapelRepository();
        }

        public PapelBLL(IPapelRepository papelRepository)
        {
            this.PapelRepository = papelRepository;
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            PapelRepository.Dispose();
        }

        public string Excluir(int idPapel)
        {
            try
            {
                Papel papel = ObterPorId(idPapel);
                PapelRepository.Excluir(papel);
                //Executa as ações
                PapelRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return "Erro: "+ex.Message;
            }
        }

        public Papel ObterPorId(int idPapel)
        {
            return PapelRepository.Obter(x => x.IdPapel == idPapel);
        }

        public string Salvar(Papel papel)
        {
            try
            {
                //Inserir e o Alterar

                if(papel.IdPapel == 0)
                {
                    PapelRepository.Adicionar(papel);
                }
                else
                {
                    PapelRepository.Alterar(papel);
                }

                PapelRepository.SalvarAlteracoes();

                return null;

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Papel> Todas()
        {
            return PapelRepository.Todos();
        }
    }
}
