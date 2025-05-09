using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class TelaEquipamento : Tela
    {
        private RepositorioEquipamento repositorioEquipamento;

        public TelaEquipamento(RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioEquipamento = repositorioEquipamento;
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

            repositorioEquipamento.InserirEquipamento(equipamento);

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

            List<Equipamento> equipamentos = repositorioEquipamento.SelecionarTodos();

            foreach (var e in equipamentos)
            {
                Console.WriteLine(e.ToString() + "\n");
            }
        }

        private Equipamento ObterDados()
        {
            Console.Write("Digite o novo nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("Digite o novo preço: ");
            decimal novoPreco = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o novo número de série: ");
            int novoSerieConversao = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo fabricante");
            string novoFabricante = Console.ReadLine();

            Console.Write("Digite a nova data de fabricação: ");
            DateTime novaDataFabricacao = DateTime.Parse(Console.ReadLine());

            var equipamento = new Equipamento();
            equipamento.nome = novoNome;
            equipamento.preco = novoPreco;
            equipamento.serie = novoSerieConversao;
            equipamento.fabricante = novoFabricante;
            equipamento.dataFabricacao = novaDataFabricacao;

            return equipamento;
        }

    }
}
