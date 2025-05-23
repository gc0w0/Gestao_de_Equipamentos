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
            repositorio = repositorioFabricante;
            modulo = "Fabricantes";
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
