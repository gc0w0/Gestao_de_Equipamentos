using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.ModuloSetor
{
    internal class TelaSetor : TelaBase
    {
        public TelaSetor(RepositorioSetor repositorioSetor) 
        {
            modulo = "Setor";
            repositorio = repositorioSetor;
        }
        public override EntidadeBase ObterDados()
        {
            Console.Write("Digite o nome: ");
            var nome = Console.ReadLine();
            return new Setor(nome);
        }
        
    }
}
