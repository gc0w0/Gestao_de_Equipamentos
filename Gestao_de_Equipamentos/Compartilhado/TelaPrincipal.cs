using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.Compartilhado
{
    public class TelaPrincipal
    {
        public string opcaoEscolhida;  
        public void ExibirOpcoesMenu()
        {
            Console.Clear();

            Console.WriteLine("Bem-vindo ao sistema de Gestão de equipamentos!\n");

            Console.WriteLine("Digite 1 para gerenciar Equipamentos:");
            Console.WriteLine("Digite 2 para gerenciar Chamados:");
            Console.WriteLine("Digite 3 para gerenciar Fabricantes");
            Console.WriteLine("Digite 4 para gerenciar Setores");
            Console.WriteLine("Digite S para sair");
            Console.Write(">: ");

            opcaoEscolhida = Console.ReadLine();
        }
        

    }
}
