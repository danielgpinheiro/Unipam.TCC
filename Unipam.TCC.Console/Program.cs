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

        private static IUsuarioRepository UsuarioRepository = new UsuarioRepository();

        static void Main(string[] args)
        {


            var contexto = new TCCModel();

            var projetos = contexto.Projetoes;
            var alunos = contexto.Alunoes;
            var notas = contexto.Notas;

            //Implementem a Consulta 1
            // Crie um for para pecorrer o resultado da consulta








            //Fontes dos dados
            var etapas_contexto = UsuarioRepository.GetDbEntity();

            //Array de etapas ou Coleção de etapas - LINQ
            //var consulta1 = from etp in etapas_contexto
            //                    where etp.IdTipoEntrega > 0
            //                select etp;


            //Não precisa de join, se as classes estão relacionadas.
            var consulta_join = from p in projetos
                                join a in alunos
                                    on p.IdPessoaAluno equals a.IdPessoa
                                select new { Projeto = p, Aluno = a };

            //Selecione a tabela base
            var consulta7 = from p in projetos
                                 where p.Aluno.Curso.NomeCurso == "Sistemas de informação"
                            select p;

            var consulta7_lambda = projetos.Where(p => p.Aluno.Curso.NomeCurso
                                == "Sistemas de informação")
                                .Select(p => p.Aluno);

  

            foreach(var projeto in consulta7)
            {
                System.Console.WriteLine(projeto.Aluno.Pessoa.Nome);
                System.Console.WriteLine(projeto.NomeProjeto);
            }




            var consulta1 = etapas_contexto.Where(etp => etp.IdTipoEntrega > 0);

            foreach (var etapa in consulta1)
            {
                System.Console.WriteLine(etapa.IdEtapa);
                System.Console.WriteLine(etapa.NotaMinima);
                System.Console.WriteLine(etapa.Entregas.Count);
            }

            var consulta2 = from etp in etapas_contexto
                                orderby etp.DataInicio descending, etp.DataFim
                            select etp;

            var consulta3 = etapas_contexto.Where(etp => etp.IdTipoEntrega > 0)
                    .OrderByDescending(etp => etp.DataInicio)
                    .ThenBy(etp => etp.DataFim)
                    .ThenBy(etp => etp.IdEtapa);



            var consulta4 = from etp in etapas_contexto
                            select new { Codigo = etp.IdTipoEntrega, etp.NotaMinima };

            var consulta5 = etapas_contexto.Select(etp => new { etp.IdEtapa, etp.NotaMinima });
            foreach(var etapa in consulta4)
            {
                System.Console.WriteLine(etapa.Codigo);
            }


            var consulta6 = from etp in etapas_contexto
                            group etp by new { etp.IdTipoEntrega } into g
                            select new
                            {
                                g.Key.IdTipoEntrega,
                                Soma = g.Sum(x => x.NotaMinima),
                                Media = g.Average(x => x.NotaMinima),
                                Max = g.Max(x => x.IdEtapa)
                            };

            foreach(var c in consulta6)
            {
                System.Console.WriteLine("Media = " + c.Media + " Soma = "+c.Soma);
            }


            System.Console.ReadKey();

        }


    }
}
