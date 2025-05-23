using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloFabricante;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class TelaEquipamento : TelaBase<Equipamento>
    {
        private const string formatoColunasTabela = "{0, -10} | {1, -20} | {2, -15} | {3, -15}";
        private RepositorioFabricante repositorioFabricante;
        private TelaFabricante telaFabricante;

        public TelaEquipamento(TelaFabricante telaFabricante, RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
        {            
            this.telaFabricante = telaFabricante;
            this.repositorioFabricante = repositorioFabricante;
            repositorio = repositorioEquipamento;
            modulo = "Equipamentos";
        }       

        public override void ExibirCabecalhoTabela()
        {
            Console.WriteLine(formatoColunasTabela, "Id", "Nome", "Série", "Fabricante");
        }

        public override void ExibirLinhaTabela(Equipamento e)
        {
            Console.WriteLine(formatoColunasTabela, e.id, e.nome, e.serie, e.fabricante.nome);
        }

        public override Equipamento ObterDados()
        {
            Console.Write("Digite o novo nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("Digite o novo preço: ");
            decimal novoPreco = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o novo número de série: ");
            int novoSerieConversao = int.Parse(Console.ReadLine());

            Console.Write("Digite a nova data de fabricação: ");
            DateTime novaDataFabricacao = DateTime.Parse(Console.ReadLine());

            this.telaFabricante.VisualizarRegistros(mostrarCabecalho: false);

            Console.Write("Digite o ID do fabricante que deseja selecionar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());
            
            Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarPorId(idFabricante);

            return new Equipamento(novoSerieConversao, novoNome, DateTime.Now, novoPreco, fabricanteSelecionado);           
        }       
    }
}
