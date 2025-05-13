using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloFabricante;
using System.Runtime.Serialization;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class TelaEquipamento : Tela
    {
        private RepositorioEquipamento repositorioEquipamento;
        private RepositorioFabricante repositorioFabricante;


        public TelaEquipamento(RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
        {
            this.repositorioEquipamento = repositorioEquipamento;
            this.repositorioFabricante = repositorioFabricante;
        }

        public string ExibirOpcoesMenu()
        {
            Console.Clear();

            Console.WriteLine("Bem-vindo ao gerenciamento de equipamentos!\n");
            Console.WriteLine("Digite 1 para cadastrar um equipamento:");
            Console.WriteLine("Digite 2 para exibir equipamentos:");
            Console.WriteLine("Digite 3 para editar um equipamento:");
            Console.WriteLine("Digite 4 para excluir um equipamento:");
            Console.WriteLine("Digite S para sair");
            Console.Write(">: ");

            opcaoEscolhida = Console.ReadLine();
            return opcaoEscolhida;
        }

        public void CadastrarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Equipamentos"); //título

            Console.WriteLine("Cadastrando equipamentos..."); //subtítulo

            Equipamento equipamento = ObterDados();

            string resultadoValidacao = equipamento.Validar();

            if (resultadoValidacao != "")
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadKey();
                CadastrarEquipamento();
                return;
            }

            repositorioEquipamento.InserirRegistro(equipamento);

            Console.WriteLine("Equipamento registrado com sucesso \n");
            Console.ReadKey();
        }

        public void EditarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Equipamentos"); //título

            Console.WriteLine("Editando equipamentos..."); //subtítulo

            ExibirEquipamentos(mostrarCabecalho: false);

            Console.WriteLine("Digite o Equipamento que deseja editar");
            var id = int.Parse(Console.ReadLine());

            Equipamento equipamento = ObterDados();

            bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(id, equipamento);

            if (conseguiuEditar == false)
            {
                Console.WriteLine("Não foi possível editar o registro selecionado");
                Console.ReadKey();
                EditarEquipamento();
                return;
            }

            Console.WriteLine("Equipamento editado com sucesso!");
            Console.ReadKey();
        }

        public void ExcluirEquipamento()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Equipamentos"); //título

            Console.WriteLine("Excluindo equipamentos..."); //subtítulo

            ExibirEquipamentos(mostrarCabecalho: false);

            Console.WriteLine("Digite o Equipamento que deseja excluir");
            var id = int.Parse(Console.ReadLine());

            bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(id);

            if (conseguiuExcluir == false)
            {
                Console.WriteLine("Não foi possível excluir o registro selecionado");
                Console.ReadKey();
                ExcluirEquipamento();
                return;
            }

            Console.WriteLine("Equipamento removido com sucesso!");
            Console.ReadKey();
        }

        public void ExibirEquipamentos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                Console.Clear();

                Console.WriteLine("Módulo de Equipamentos"); //título

                Console.WriteLine("Visualizando equipamentos..."); //subtítulo
            }

            List<Entidade> equipamentos = repositorioEquipamento.SelecionarTodos();

            foreach (var e in equipamentos)
            {
                Console.WriteLine(e.ToString() + "\n");
            }

            Console.ReadKey();
        }

        private Equipamento ObterDados()
        {
            Console.Write("Digite o novo nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("Digite o novo preço: ");
            decimal novoPreco = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o novo número de série: ");
            int novoSerieConversao = int.Parse(Console.ReadLine());

            Console.Write("Digite a nova data de fabricação: ");
            int novaDataFabricacao = int.Parse(Console.ReadLine());

            VisualizarFabricantes();

            Console.Write("Digite o ID do fabricante que deseja selecionar");
            int idFabricante = Convert.ToInt32(Console.ReadLine());
            
            Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarPorId(idFabricante);

            //string novoNome = "Equipamento2";
            //decimal novoPreco = 122;
            //int novoSerieConversao = 12133132;
            //string novoFabricante = "Fabricante1";
            //DateTime novaDataFabricacao = DateTime.Today;


            var equipamento = new Equipamento();
            equipamento.nome = novoNome;
            equipamento.preco = novoPreco;
            equipamento.serie = novoSerieConversao;
            equipamento.fabricante = fabricanteSelecionado;
            equipamento.dataFabricacao = DateTime.Now;

            return equipamento;
        }

        private void VisualizarFabricantes()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Fabricantes");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                "Id", "Nome", "Email", "Telefone"
            );

            List<Entidade> fabricantes = repositorioFabricante.SelecionarTodos();

            for (int i = 0; i < fabricantes.Count; i++)
            {
                Fabricante e = (Fabricante)fabricantes[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                    e.id, e.nome, e.email, e.telefone
                );
            }

            Console.ReadLine();
        }
    }
}
