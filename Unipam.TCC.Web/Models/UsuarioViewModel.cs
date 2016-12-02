using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.Web.Models
{
    public class UsuarioViewModel
    {

        public Usuario usuario { get; set; }
        public List<Papel> papeis { get; set; }

        public int[] papeisSelecionados { get; set; }


    }
}