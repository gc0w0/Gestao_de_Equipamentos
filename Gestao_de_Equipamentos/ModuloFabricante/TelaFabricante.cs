using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloFabricante
{
    public class TelaFabricante : Tela
    {
        RepositorioEquipamento repositorioEquipamento;
        RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioFabricante, RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioFabricante = repositorioFabricante;
            this.repositorioEquipamento = repositorioEquipamento;
        }

        public string ExibirOpcoesMenu()
        {
            Console.Clear();

            Console.WriteLine("Bem-vindo ao gerenciamento de Fabricantes!\n");
            Console.WriteLine("Digite 1 para cadastrar um novo fabricante:");
            Console.WriteLine("Digite 2 para exibir os fabricantes:");
            Console.WriteLine("Digite 3 para editar um fabricantes:");
            Console.WriteLine("Digite 4 para excluir um fabricantes:");
            Console.WriteLine("Digite S para sair");
            Console.Write(">: ");

            opcaoEscolhida = Console.ReadLine();
            return opcaoEscolhida;
        }

        internal void CadastrarFabricante()
        {
            Console.Clear();

            Console.WriteLine("Modulo de Fabricantes");

            Console.WriteLine("Cadastrando fabricantes...");

            Fabricante fabricante = ObterDados();

            string resultadoValidacao = fabricante.Validar();
            if (resultadoValidacao != "")
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadKey();
                CadastrarFabricante();
                return;
            }

            repositorioFabricante.InserirRegistro(fabricante);

            Console.WriteLine("Fabricante registrado com sucesso \n");
            Console.ReadKey();
        }

        internal void EditarFabricante()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Fabricantes"); //título

            Console.WriteLine("Editando fabricantes..."); //subtítulo

            ExibirFabricante(mostrarCabecalho: false);

            Console.WriteLine("Digite o Fabricante que deseja editar");
            var id = int.Parse(Console.ReadLine());

            Fabricante fabricante = ObterDados();

            bool conseguiuEditar = repositorioFabricante.EditarFabricante(id, fabricante);

            if (conseguiuEditar == false)
            {
                Console.WriteLine("Não foi possível editar o registro selecionado");
                Console.ReadKey();
                EditarFabricante();
                return;
            }

            Console.WriteLine("Fabricante editado com sucesso!");
            Console.ReadKey();
        }

        internal void ExcluirFabricante()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Fabricantes"); //título

            Console.WriteLine("Excluindo Fabricantes..."); //subtítulo

            ExibirFabricante(mostrarCabecalho: false);

            Console.WriteLine("Digite o Fabricante que deseja excluir");
            var id = int.Parse(Console.ReadLine());

            bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(id);

            if (conseguiuExcluir == false)
            {
                Console.WriteLine("Não foi possível excluir o registro selecionado");
                Console.ReadKey();
                ExcluirFabricante();
                return;
            }

            Console.WriteLine("Fabricante removido com sucesso!");
            Console.ReadKey();
        }

        public void ExibirFabricante(bool mostrarCabecalho)
        {
          
            if (mostrarCabecalho)
            {
                Console.Clear();

                Console.WriteLine("Módulo de Fabricantes"); //título

                Console.WriteLine("Visualizando fabricantes..."); //subtítulo
            }

            List<Entidade> fabricantes = repositorioFabricante.SelecionarTodos();

            foreach (var f in repositorioFabricante.SelecionarTodos())
            {
                f.MostrandoInformacoes();
            }

            Console.ReadKey();
        }

        public Fabricante ObterDados()
        {
            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine();

          
            Fabricante fabricante = new Fabricante(nome, email, telefone);
            fabricante.nome = nome;
            fabricante.email = email;
            fabricante.telefone = telefone;

            return fabricante;
        }


    }

}
