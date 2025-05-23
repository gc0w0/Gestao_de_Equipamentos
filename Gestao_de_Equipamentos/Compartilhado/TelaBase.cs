using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloSetor;
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

        internal void EditarRegistro()
        {
            Console.Clear();

            Console.WriteLine($"Módulo de {modulo}"); //título

            Console.WriteLine($"Editando {modulo}..."); //subtítulo

            ExibirRegistro(mostrarCabecalho: false);

            Console.Write($"Digite o {modulo} que deseja editar: ");
            var id = int.Parse(Console.ReadLine());
            EntidadeBase registro = ObterDados();

            bool conseguiuEditar = repositorio.EditarRegistro(id, registro);

            if (conseguiuEditar == false)
            {
                Console.WriteLine("Não foi possível editar o registro selecionado");
                Console.ReadKey();
                EditarRegistro();
                return;
            }

            Console.WriteLine($"{modulo} editado com sucesso!");
            Console.ReadKey();
        }

        public void ExibirRegistro(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                Console.Clear();

                Console.WriteLine($"Módulo de {modulo}"); //título

                Console.WriteLine($"Editando {modulo}..."); //subtítulo
            }

            List<EntidadeBase> registros = repositorio.SelecionarTodos();

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i].MostrarInformacoes();
            }
            Console.ReadKey();
        }

        internal void ExcluirRegistro()
        {
            Console.Clear();

            Console.WriteLine($"Módulo de {modulo}"); //título

            Console.WriteLine($"Editando {modulo}..."); //subtítulo

            ExibirRegistro(mostrarCabecalho: false);

            Console.Write($"Digite o {modulo} que deseja excluir: ");
            var id = int.Parse(Console.ReadLine());

            bool conseguiuExcluir = repositorio.ExcluirRegistro(id);

            if (conseguiuExcluir == false)
            {
                Console.WriteLine("Não foi possível excluir o registro selecionado");
                Console.ReadKey();
                ExcluirRegistro();
                return;
            }

            Console.WriteLine("Chamado removido com sucesso!");
            Console.ReadKey();
        }


    }
}
