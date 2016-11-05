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
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly IUsuarioRepository UsuarioRepository;

        public UsuarioBLL(IUsuarioRepository usuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }

        public void Dispose()
        {
            UsuarioRepository.Dispose();
        }

        public string Excluir(int idUsuario)
        {
            try
            {
                Usuario usuario = ObterPorId(idUsuario);
                UsuarioRepository.Excluir(usuario);
                //Executa as ações
                UsuarioRepository.SalvarAlteracoes();

                return null;
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Usuario ObterPorId(int IdUsuario)
        {
            return UsuarioRepository.Obter(x => x.IdUsuario == IdUsuario);
        }

        public string Salvar(Usuario usuario)
        {
            try
            {
                if (usuario.IdUsuario == 0)
                {
                    UsuarioRepository.Adicionar(usuario);
                }
                else
                {
                    UsuarioRepository.Alterar(usuario);
                }
                UsuarioRepository.SalvarAlteracoes();

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IList<Usuario> Todas()
        {
            return UsuarioRepository.Todos().ToList();
        }
    }
}
