using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloFabricante
{
    public class TelaFabricante : TelaBase
    {
        RepositorioEquipamento repositorioEquipamento;
        RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioFabricante, RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioFabricante = repositorioFabricante;
            this.repositorioEquipamento = repositorioEquipamento;
            base.repositorio = repositorioFabricante;
            modulo = "Fabricantes";
        }

        //internal void CadastrarFabricante()
        //{
        //    Console.Clear();

        //    Console.WriteLine("Modulo de Fabricantes");

        //    Console.WriteLine("Cadastrando fabricantes...");

        //    Fabricante fabricante = ObterDados();

        //    string resultadoValidacao = fabricante.ValidarInformacoes();
        //    if (resultadoValidacao != "")
        //    {
        //        Console.WriteLine(resultadoValidacao);
        //        Console.ReadKey();
        //        CadastrarFabricante();
        //        return;
        //    }

        //    repositorioFabricante.InserirRegistro(fabricante);

        //    Console.WriteLine("Fabricante registrado com sucesso \n");
        //    Console.ReadKey();
        //}

        internal void EditarFabricante()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Fabricantes"); //título

            Console.WriteLine("Editando fabricantes..."); //subtítulo

            ExibirFabricante(mostrarCabecalho: false);

            Console.Write("Digite o Fabricante que deseja editar: ");
            var id = int.Parse(Console.ReadLine());

            Fabricante fabricante = (Fabricante)ObterDados();

            bool conseguiuEditar = repositorioFabricante.EditarRegistro(id, fabricante);

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

            Console.Write("Digite o Fabricante que deseja excluir: ");
            var id = int.Parse(Console.ReadLine());

            bool conseguiuExcluir = repositorioFabricante.ExcluirRegistro(id);

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

            List<EntidadeBase> fabricantes = repositorioFabricante.SelecionarTodos();

            for (int i = 0; i < fabricantes.Count; i++)
            {
                fabricantes[i].MostrarInformacoes();
            }

            Console.ReadKey();
        }

        public override EntidadeBase ObterDados()
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
