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
    public class NotaBLL : INotaBLL
    {
        private readonly INotaRepository NotaRepository;

        //Inicialização Default
        public NotaBLL()
        {
            this.NotaRepository = new NotaRepository();
        }

        public NotaBLL(INotaRepository notaRepository)
        {
            this.NotaRepository = notaRepository;
        }

        public void Dispose()
        {
            NotaRepository.Dispose();
        }

        public string Excluir(int idNota)
        {
            try
            {
                Nota nota = ObterPorId(idNota);
                NotaRepository.Excluir(nota);
                //Executa as ações
                NotaRepository.SalvarAlteracoes();

                return null;
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Nota ObterPorId(int IdNota)
        {
            return NotaRepository.Obter(x => x.IdNota == IdNota);
        }

        public string Salvar(Nota nota)
        {
            try
            {
                if (nota.IdNota == 0)
                {
                    NotaRepository.Adicionar(nota);
                }
                else
                {
                    NotaRepository.Alterar(nota);
                }
                NotaRepository.SalvarAlteracoes();

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Nota> Todas()
        {
            return NotaRepository.Todos().ToList();
        }
    }
}
