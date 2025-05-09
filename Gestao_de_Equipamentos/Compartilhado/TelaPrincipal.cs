using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.Compartilhado
{
    public class TelaPrincipal : Tela
    {
        public void ExibirOpcoesMenu()
        {
            Console.WriteLine("Bem-vindo ao sistema de Gestão de equipamentos!\n");

            Console.WriteLine("Digite 1 para gerenciar Equipamentos:");
            Console.WriteLine("Digite 2 para gerenciar Chamados:");
            Console.WriteLine("Digite S para sair");
            Console.Write(">: ");

            opcaoEscolhida = Console.ReadLine();
        }
        

    }
}
