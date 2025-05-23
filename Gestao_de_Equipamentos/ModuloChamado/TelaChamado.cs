using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class TelaChamado : TelaBase<Chamado>
    {
        private const string formatoColunasTabela = "{0, -10} | {1, -20} | {2, -15} | {3, -15}";
        private RepositorioEquipamento repositorioEquipamento;
        private TelaEquipamento telaEquipamento;

        public TelaChamado(TelaEquipamento telaEquipamento, RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento)
        {            
            this.repositorioEquipamento = repositorioEquipamento;
            repositorio = repositorioChamado;
            this.telaEquipamento = telaEquipamento;
            modulo = "Chamados";
        }        

        public override void ExibirCabecalhoTabela()
        {
            Console.WriteLine(formatoColunasTabela, "Id", "Título", "Descrição", "Equipamento");
        }

        public override void ExibirLinhaTabela(Chamado c)
        {
            Console.WriteLine(formatoColunasTabela, c.id, c.titulo, c.descricao, c.equipamento.nome);
        }

        public override Chamado ObterDados()
        {
            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            DateTime dataAbertura = DateTime.Now;
            
            telaEquipamento.VisualizarRegistros(mostrarCabecalho: false);

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(idEquipamento);

            Chamado chamado = new Chamado(titulo, descricao, dataAbertura, equipamentoSelecionado);
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.dataAbertura = dataAbertura;
            chamado.equipamento = equipamentoSelecionado;

            return chamado;
        }      
    }
}
