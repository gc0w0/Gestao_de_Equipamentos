using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloFabricante;
using Microsoft.Win32;
using System.Runtime.Serialization;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class TelaEquipamento : TelaBase
    {
        private RepositorioEquipamento repositorioEquipamento;
        private RepositorioFabricante repositorioFabricante;


        public TelaEquipamento(RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
        {
            this.repositorioEquipamento = repositorioEquipamento;
            this.repositorioFabricante = repositorioFabricante;
            repositorio = repositorioEquipamento;
            modulo = "Equipamentos";
        }
        
        public void ExibirEquipamentos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                Console.Clear();

                Console.WriteLine("Módulo de Equipamentos"); //título

                Console.WriteLine("Visualizando equipamentos..."); //subtítulo
            }

            List<EntidadeBase> equipamentos = repositorioEquipamento.SelecionarTodos();

            for (int i = 0; i < equipamentos.Count; i++)
            {
                equipamentos[i].MostrarInformacoes();
            }

            Console.ReadKey();
        }

        public override EntidadeBase ObterDados()
        {
            Console.Write("Digite o novo nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("Digite o novo preço: ");
            decimal novoPreco = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o novo número de série: ");
            int novoSerieConversao = int.Parse(Console.ReadLine());

            Console.Write("Digite a nova data de fabricação: ");
            DateTime novaDataFabricacao = DateTime.Parse(Console.ReadLine());

            VisualizarFabricantes();

            Console.Write("Digite o ID do fabricante que deseja selecionar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());
            
            Fabricante fabricanteSelecionado = (Fabricante)repositorioFabricante.SelecionarPorId(idFabricante);

            //string novoNome = "Equipamento2";
            //decimal novoPreco = 122;
            //int novoSerieConversao = 12133132;
            //string novoFabricante = "Fabricante1";
            //DateTime novaDataFabricacao = DateTime.Today;


            var equipamento = new Equipamento(novoSerieConversao, novoNome, DateTime.Now, novoPreco, fabricanteSelecionado);
            equipamento.nome = novoNome;
            equipamento.preco = novoPreco;
            equipamento.serie = novoSerieConversao;
            equipamento.fabricante = fabricanteSelecionado;
            equipamento.dataFabricacao = DateTime.Now;
            fabricanteSelecionado.equipamentos.Add(equipamento);

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

            List<EntidadeBase> fabricantes = repositorioFabricante.SelecionarTodos();

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
