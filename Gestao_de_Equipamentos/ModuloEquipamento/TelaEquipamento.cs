using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class TelaEquipamento : Tela
    {
        
        RepositorioEquipamento repositorioEquipamento;

        public Equipamento equipamento;

        Controle_De_Chamado controleChamado;
        

        public TelaEquipamento(RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioEquipamento = repositorioEquipamento;
            Iniciar(controleChamado);
        }
        public void Iniciar(Controle_De_Chamado controleChamadoExistente)
        {

            this.controleChamado = controleChamadoExistente;
            //string opcao = ExibirOpcoesMenu(); // coloquei na classe de TelaEquipamento
            //EscolherOpcao(opcao);

        }

        public string ExibirOpcoesMenu()
        {
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

        internal void CadastrarEquipamento()
        {
            //Console.Write("Digite o nome do Equipamento com no minimo 6 letras: ");
            //var nome = Console.ReadLine();
            //Console.Write("Digite o preço do equipamento: ");
            //var preco = decimal.Parse(Console.ReadLine());
            //Console.Write("Digite o numero de serie: ");
            //var serie = double.Parse(Console.ReadLine());
            //Console.Write("Digite o Fabricante do equipamento: ");
            //var fabricante = Console.ReadLine();
            //Console.Write("Digite a data de fabricação do equipamento: ");
            //var dataFabricacao = int.Parse(Console.ReadLine());

            var equipamento = new Equipamento();

            equipamento.nome = "nome";
            equipamento.preco = 312;
            equipamento.serie = 3132;
            equipamento.fabricante = "fabricante";
            equipamento.dataFabricacao = 2322;
            repositorioEquipamento.InserirEquipamento(equipamento);
            //RegistarEquipamento(equipamento.id, equipamento.nome, equipamento.preco, equipamento.fabricante, equipamento.dataFabricacao);
            Console.WriteLine("Equipamento registrado com sucesso \n");

        }

        internal void EditarEquipamento()
        {
            Console.WriteLine("Digite o Equipamento que deseja editar");
            var selecionar_Id = int.Parse(Console.ReadLine());
            Equipamento editar = repositorioEquipamento.equipamentosRegistrados.FirstOrDefault(equipamento => equipamento.id == selecionar_Id);

            if (editar == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Console.WriteLine("Digite o novo nome (ou pressione Enter para manter): ");
            string novoNome = Console.ReadLine();
            int numeroCaracteres = novoNome.Length;

            editar.Validar(numeroCaracteres);

            if (!string.IsNullOrEmpty(novoNome) && novoNome.Length >= numeroCaracteres == true)
                editar.nome = novoNome;

            Console.WriteLine("Digite o novo preço (ou pressione Enter para manter): ");
            string novoPrecoConversao = Console.ReadLine();
            if (decimal.TryParse(novoPrecoConversao, out decimal novoPreco) && novoPreco > 0)
                editar.preco = novoPreco;

            Console.WriteLine("Digite o novo número de série (ou pressione Enter para manter): ");
            string novoSerieConversao = Console.ReadLine();
            if (int.TryParse(novoSerieConversao, out int novoSerie) && novoSerie > 0)
                editar.serie = int.Parse(novoSerieConversao);

            Console.WriteLine("Digite o novo fabricante (ou pressione Enter para manter)");
            string novoFabricante = Console.ReadLine();
            if (!string.IsNullOrEmpty(novoFabricante))
                editar.fabricante = novoFabricante;

            Console.WriteLine("Digite a nova data de fabricação (ou pressione Enter para manter): ");
            string novaDataFabricacaoConversao = Console.ReadLine();
            if (int.TryParse(novaDataFabricacaoConversao, out int novaDataFabricacao))
                editar.dataFabricacao = novaDataFabricacao;

            Console.WriteLine("Equipamento editado com sucesso!");

        }

        internal void ExcluirEquipamento()
        {
            Console.WriteLine("Digite o ID do equipamento que deseja excluir");
            int idExcluxao = int.Parse(Console.ReadLine());
            var equipamento = repositorioEquipamento.equipamentosRegistrados.FirstOrDefault(e => e.id == idExcluxao);
            if (equipamento == null)
                Console.WriteLine("Equipamento não encontrado.");

            repositorioEquipamento.equipamentosRegistrados.Remove(equipamento);
            Console.WriteLine("Equipamento removido com sucesso!");
        }

        internal void ExibirEquipamento()
        {
            Console.WriteLine("Equipamentos Registrados:");

            foreach (var equipamento in repositorioEquipamento.equipamentosRegistrados)
            {
                Console.WriteLine(equipamento.ToString() + "\n");
            }
        }

    }
}
