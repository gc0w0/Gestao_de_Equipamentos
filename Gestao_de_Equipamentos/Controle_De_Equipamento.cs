using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos
{
    public class Controle_De_Equipamento
    {
        public List<Equipamento> equipamentosRegistrados = new List<Equipamento>();
        Controle_De_Chamado controleChamado;

        
        protected int id;
        protected int idChamado;
        private int selecionar_Id;
        private double serie;
        private int quantidadeMinimaCaractere = 6;
        protected int data_Fabricacao;
        protected decimal preco;

        public string nome;
        protected string fabricante;

        public void Iniciar(Controle_De_Chamado controleChamadoExistente)
        {
            this.controleChamado = controleChamadoExistente; 
            string opcao = ExibirMenu();
            EscolherOpcao(opcao);
        }

        public string ExibirMenu()
        {
            Console.WriteLine("Bem-vindo ao sistema de controle de equipamentos!\n");
            Console.WriteLine("Digite 1 para cadastrar um equipamento:");
            Console.WriteLine("Digite 2 para exibir equipamentos:");
            Console.WriteLine("Digite 3 para editar um equipamento:");
            Console.WriteLine("Digite 4 para excluir um equipamento:");
            Console.WriteLine("Digite 5 para cadastrar um chamado:");
            Console.WriteLine("Digite 6 para exibir os chamados:");
            Console.WriteLine("Digite 7 para editar um chamado:");
            Console.WriteLine("Digite 8 para excluir um chamado:");
            Console.WriteLine("Digite 9 para sair");
            Console.Write(">: ");
            string opcao = Console.ReadLine();
            return opcao;
        }

        

        private void EscolherOpcao(string opcao)
        {
            if (opcao == "1")
                CadastrarEquipamento();
            else if (opcao == "2")
                ExibirEquipamento();
            else if (opcao == "3")
                EditarEquipamento();
            else if (opcao == "4")
                ExcluirEquipamento();
            else if (opcao == "5")
                controleChamado.CadastrarChamado();
            else if (opcao == "6")
                controleChamado.ExibirChamado();
            else if (opcao == "7")
                controleChamado.EditarChamado();
            else if (opcao == "8")
                controleChamado.ExcluirChamado();
            else
                Console.WriteLine("Opção inválida. Tente novamente.");

        }

        private void ExcluirEquipamento()
        {
            Console.WriteLine("Digite o ID do equipamento que deseja excluir");
            int idExcluxao = int.Parse(Console.ReadLine());
            var equipamento = equipamentosRegistrados.FirstOrDefault(e => e.registroId == idExcluxao);
            if (equipamento == null)
                Console.WriteLine("Equipamento não encontrado.");

            equipamentosRegistrados.Remove(equipamento);
            Console.WriteLine("Equipamento removido com sucesso!");
        }

        private void EditarEquipamento()
        {
            Console.WriteLine("Digite o Equipamento que deseja editar");
            selecionar_Id = int.Parse(Console.ReadLine());
            Equipamento editar = equipamentosRegistrados.FirstOrDefault(equipamento => equipamento.registroId == selecionar_Id);

            if (editar == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Console.WriteLine("Digite o novo nome (ou pressione Enter para manter): ");
            string novoNome = Console.ReadLine();
            if (!string.IsNullOrEmpty(novoNome) && novoNome.Length >= quantidadeMinimaCaractere)
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
                editar.data_Fabricacao = novaDataFabricacao;




            Console.WriteLine("Equipamento editado com sucesso!");

        }

        public void ExibirEquipamento()
        {
            Console.WriteLine("Equipamentos Registrados:");

            foreach (var equipamento in equipamentosRegistrados)
            {
                Console.WriteLine(equipamento.ToString() + "\n");
            }

        }

        private bool CadastrarEquipamento()
        {
            do
            {
                Console.Write("Digite o nome do Equipamento com no minimo 6 letras: ");
                nome = Console.ReadLine();

                if (nome.Length < quantidadeMinimaCaractere)
                {
                    Console.WriteLine($"O nome deve ter no mínimo {quantidadeMinimaCaractere} caracteres.");
                }

            } while (quantidadeMinimaCaractere > nome.Length);

            Console.Write("Digite o preço do equipamento: ");
            preco = decimal.Parse(Console.ReadLine());
            Console.Write("Digite o numero de serie: ");
            serie = double.Parse(Console.ReadLine());
            Console.Write("Digite o Fabricante do equipamento: ");
            fabricante = Console.ReadLine();
            Console.Write("Digite a data de fabricação do equipamento: ");
            data_Fabricacao = int.Parse(Console.ReadLine());

            RegistarEquipamento(id,nome, preco, fabricante, data_Fabricacao);

            return true;

        }

        private void RegistarEquipamento (int id, string nome, decimal preco, string fabricante, int data_Fabricacao)
        {
            equipamentosRegistrados.Add(new Equipamento
            {
                registroId = equipamentosRegistrados.Count + 1,
                nome = nome,
                preco = preco,
                fabricante = fabricante,
                data_Fabricacao = data_Fabricacao
            });
        }

    }
}




    

