using Gestao_de_Equipamentos.ModuloChamado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.Compartilhado
{
    public abstract class TelaBase
    {
        public string opcaoEscolhida;

        public string titulo;

        public string modulo;

        public RepositorioBase repositorio;

        public string ExibirOpcoesMenu()
        {
            Console.Clear();

            Console.WriteLine($"Bem-vindo ao gerenciamento de {modulo}!\n");
            Console.WriteLine($"Digite 1 para cadastrar um novo {modulo}:");
            Console.WriteLine($"Digite 2 para exibir os {modulo}:");
            Console.WriteLine($"Digite 3 para editar um {modulo}:");
            Console.WriteLine($"Digite 4 para excluir um {modulo}:");
            Console.WriteLine("Digite S para sair");
            Console.Write(">: ");

            opcaoEscolhida = Console.ReadLine();
            return opcaoEscolhida;

        }

        internal void CadastrarRegistro()
        {
            Console.Clear();

            Console.WriteLine($"Modulo de {modulo}");

            Console.WriteLine($"Cadastrando {modulo}...");

            EntidadeBase registro = ObterDados();

            string resultadoValidacao = registro.ValidarInformacoes();
            if (resultadoValidacao != "")
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadKey();
                CadastrarRegistro();
                return;
            }

            repositorio.InserirRegistro(registro);

            Console.WriteLine($"{modulo} inserido com sucesso \n");
            Console.ReadKey();

        }

        public abstract EntidadeBase ObterDados(); //metodo muito especifico

        //internal void EditarChamado()
        //{
        //    Console.Clear();

        //    Console.WriteLine("Módulo de Chamados"); //título

        //    Console.WriteLine("Editando chamados..."); //subtítulo

        //    ExibirChamados(mostrarCabecalho: false);

        //    Console.Write("Digite o Chamado que deseja editar: ");
        //    var id = int.Parse(Console.ReadLine());

        //    Chamado chamado = (Chamado)ObterDados();

        //    bool conseguiuEditar = repositorioChamado.EditarRegistro(id, chamado);

        //    if (conseguiuEditar == false)
        //    {
        //        Console.WriteLine("Não foi possível editar o registro selecionado");
        //        Console.ReadKey();
        //        EditarChamado();
        //        return;
        //    }

        //    Console.WriteLine("Chamado editado com sucesso!");
        //    Console.ReadKey();
        //}



    }
}
