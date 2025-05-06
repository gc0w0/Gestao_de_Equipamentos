using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos
{
    public class Controle_De_Equipamento
    {
        private List<Equipamento> equipamentosRegistrados = new List<Equipamento>();

        protected int id;
        private int serie;
        private int quantidadeMinimaCaractere = 6; // vou usar pro nome ter no minimo 6 caracteres
        protected int data_Fabricacao;
        protected decimal preco;

        protected string nome;
        protected string fabricante;

        public void Iniciar()
        {
            
            string opcao = ExibirMenu();
            EscolherOpcao(opcao);
        }
        

        public Controle_De_Equipamento()
        {
            Iniciar();
            
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
                CadastrarChamado();
            else if (opcao == "6")
                ExibirChamado();
            else if (opcao == "7")
                EditarChamado();
            else if (opcao == "8")
                ExcluirChamado();
            else
                Console.WriteLine("Opção inválida. Tente novamente.");

        }

        private void ExcluirChamado()
        {
            throw new NotImplementedException();
        }

        private void EditarChamado()
        {
            throw new NotImplementedException();
        }

        private void ExibirChamado()
        {
            throw new NotImplementedException();
        }

        private void CadastrarChamado()
        {
            throw new NotImplementedException();
        }

        private void ExcluirEquipamento()
        {
            throw new NotImplementedException();
        }

        private void EditarEquipamento()
        {
            throw new NotImplementedException();
        }

        public string ExibirEquipamento()
        {   
            string equipamentos = "";
            equipamentos += "Equipamentos Registrados: \n";

            foreach (var equipamento in equipamentosRegistrados)
            {
                equipamentos += equipamento.ToString() + "\n";
            }

            return equipamentos;
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
            Console.Write("Digite o Fabricante do equipamento: ");
            fabricante = Console.ReadLine();
            Console.Write("Digite a data de fabricação do equipamento: ");
            data_Fabricacao = int.Parse(Console.ReadLine());

            RegistarEquipamento("nome", preco, "fabricante", data_Fabricacao);

            return true;

        }

        private void RegistarEquipamento (string nome, decimal preco, string fabricante, int data_Fabricacao)
        {
            equipamentosRegistrados.Add(new Equipamento
            {
                registroId = equipamentosRegistrados.Count + 1,
                nomeRegistrado = nome,
                precoRegistrado = preco,
                fabricanteRegistrado = fabricante,
                data_FabricacaoRegistrada = data_Fabricacao
            });
        }

    }
}




    

