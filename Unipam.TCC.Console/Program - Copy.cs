using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unipam.TCC.DAL.InterfaceRepository;
using Unipam.TCC.DAL.ImplementationRepository;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.Console
{
    class Program
    {

        private static IEtapaRepository etapaRepository = new EtapaRepository();

        static void Main(string[] args)
        {

            var contexto = new TCCModel();
            var projetos = contexto.Projetoes;
            var alunos = contexto.Alunoes;
            var notas = contexto.Notas;


            System.Console.ReadKey();

        }


    }
}
