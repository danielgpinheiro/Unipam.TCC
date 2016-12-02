using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.BLL.InterfaceBLL;
using Unipam.TCC.DAL.Entity;
using Unipam.TCC.DAL.ImplementationRepository;
using Unipam.TCC.DAL.InterfaceRepository;

namespace Unipam.TCC.BLL.ImplementationBLL
{
    public class ProjetoBLL : IProjetoBLL
    {
      
        private readonly IProjetoRepository projetoRepository;

        public ProjetoBLL()
        {
            projetoRepository = new ProjetoRepository();
        }

        public ProjetoBLL(IProjetoRepository projetoRepository)
        {
            this.projetoRepository = projetoRepository;
        }

        public string Salvar(Projeto projeto)
        {
            try
            {
                if (projeto.IdProjeto == 0)
                {
                    projetoRepository.Adicionar(projeto);
                }
                else
                {
                    projetoRepository.Alterar(projeto);
                }

                projetoRepository.SalvarAlteracoes();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(int idProjeto)
        {
            try
            {
                Projeto tp = Obter(idProjeto);
                projetoRepository.Excluir(tp);
                projetoRepository.SalvarAlteracoes();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Projeto Obter(int idProjeto)
        {
            return projetoRepository.Obter(x => x.IdProjeto == idProjeto);
        }



        public IList<Projeto> Todos()
        {
            return projetoRepository.Todos();
        }

        public IList<Projeto> Listar(string nome)
        {
            return projetoRepository.Consultar(x => x.NomeProjeto.Contains(nome));
        }

        public void Dispose()
        {
            //Coloque todos os repositórios aqui
            projetoRepository.Dispose();
        }
    }
}
