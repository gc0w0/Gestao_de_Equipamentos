using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class TelaChamado : Tela
    {  
        RepositorioEquipamento repositorioEquipamento;
        RepositorioChamado repositorioChamado;

        public Chamado chamado;

        public TelaChamado(RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioChamado = repositorioChamado;
            this.repositorioEquipamento = repositorioEquipamento;
        }

        public string ExibirOpcoesMenu()
        {
            Console.WriteLine("Bem-vindo ao gerenciamento de Chamados!\n");
            Console.WriteLine("Digite 1 para cadastrar um novo chamado:");
            Console.WriteLine("Digite 2 para exibir os chamados:");
            Console.WriteLine("Digite 3 para editar um chamado:");
            Console.WriteLine("Digite 4 para excluir um chamado:");
            Console.WriteLine("Digite S para sair");
            Console.Write(">: ");

            opcaoEscolhida = Console.ReadLine();
            return opcaoEscolhida;
        }

        internal void CadastrarChamado()
        {


            //Console.Write("Digite o título do chamado: ");
            //string tituloChamado = Console.ReadLine();

            //Console.Write("Digite a descrição do chamado: ");
            //string descricaoChamado = Console.ReadLine();

            //Console.Write("Digite o ID do equipamento relacionado: ");
            //int idEquipamento = int.Parse(Console.ReadLine());
            var idEquipamento = 1;
            Equipamento equipamentoSelecionado = repositorioEquipamento.equipamentosRegistrados.FirstOrDefault(e => e.id == idEquipamento);

            //if (equipamentoSelecionado == null)
            //{
            //    Console.WriteLine("Equipamento não encontrado.");
            //    return;
            //}

            //string dataAbertura = DateTime.Now.ToString("dd/MM/yyyy");
            int diasEmAberto = 0;


            var chamado = new Chamado();
            
            chamado.titulo = "tituloChamado";
            chamado.descricao = "descricaoChamado";
            chamado.dataAbertura = DateTime.Now.ToString("dd/MM/yyyy");
            chamado.equipamentoRelacionado = equipamentoSelecionado;
            chamado.diasEmAberto = diasEmAberto;

            repositorioChamado.InserirChamado(chamado);

            Console.WriteLine("Chamado registrado com sucesso!");
        }

        internal void EditarChamado()
        {
            Console.Write("Digite o ID do chamado que deseja editar: ");
            var id = int.Parse(Console.ReadLine());

            Chamado chamado = repositorioChamado.chamadosRegistrados.FirstOrDefault(c => c.id == id);

            if (chamado == null)
                Console.WriteLine("Chamado não encontrado.");

            Console.Write("Novo título (ENTER para manter): ");
            string novoTitulo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoTitulo))
                chamado.titulo = novoTitulo;

            Console.Write("Nova descrição (ENTER para manter): ");
            string novaDescricao = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaDescricao))
                chamado.descricao = novaDescricao;

            Console.Write("Novo ID de equipamento (ENTER para manter): ");
            string novoIdEquipamentoConvercao = Console.ReadLine();
            if (int.TryParse(novoIdEquipamentoConvercao, out int novoIdEquipamento))
            {
                Equipamento equipamentoAlterado = repositorioEquipamento.equipamentosRegistrados.FirstOrDefault(e => e.id == novoIdEquipamento);
                if (equipamentoAlterado != null)
                    chamado.equipamentoRelacionado = equipamentoAlterado;
            }


            Console.WriteLine("Chamado atualizado.");
        }

        internal void ExcluirChamado()
        {
            Console.Write("Digite o ID do chamado a excluir: ");
            var id = int.Parse(Console.ReadLine());

            Chamado chamado = repositorioChamado.chamadosRegistrados.FirstOrDefault(c => c.id == id);

            if (chamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }

            repositorioChamado.chamadosRegistrados.Remove(chamado);
            Console.WriteLine("Chamado excluído com sucesso.");
        }

        internal void ExibirChamado()
        {
            Console.WriteLine("Chamados Registrados:");

            foreach (var chamado in repositorioChamado.chamadosRegistrados)
                Console.WriteLine(chamado.ToString() + "\n");
        }
    }
}
