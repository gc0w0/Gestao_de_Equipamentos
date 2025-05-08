

namespace Gestao_de_Equipamentos
{
    public class Controle_De_Chamado
    {
        private int id;
        private int equipamentoChamado;
        protected string titulo;
        private string descricao;
        protected string dataAbertura;
        protected Equipamento equipamentoRelacionado;
        public List<Equipamento> equipamentosRegistrados;
        private List<Chamado> chamadosRegistrados = new List<Chamado>();

        public Controle_De_Chamado(List<Equipamento> equipamentos)
        {
            equipamentosRegistrados = equipamentos ?? new List<Equipamento>();
        }
        public void ExcluirChamado()
        {
            Console.Write("Digite o ID do chamado a excluir: ");
            id = int.Parse(Console.ReadLine());

            Chamado chamado = chamadosRegistrados.FirstOrDefault(c => c.id == id);

            if (chamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }

            chamadosRegistrados.Remove(chamado);
            Console.WriteLine("Chamado excluído com sucesso.");
        }

        public void EditarChamado()
        {
            Console.Write("Digite o ID do chamado que deseja editar: ");
            id = int.Parse(Console.ReadLine());

            Chamado chamado = chamadosRegistrados.FirstOrDefault(c => c.id == id);

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
                Equipamento equipamentoAlterado = equipamentosRegistrados.FirstOrDefault(e => e.registroId == novoIdEquipamento);
                if (equipamentoAlterado != null)
                    chamado.equipamentoRelacionado = equipamentoAlterado;
            }


            Console.WriteLine("Chamado atualizado.");
        }

        public void ExibirChamado()
        {
            Console.WriteLine("Chamados Registrados:");

            foreach (var chamado in chamadosRegistrados)
            {
                Console.WriteLine(chamado.ToString() + "\n");
            }
        }

        public void CadastrarChamado()
        {

            Console.Write("Digite o título do chamado: ");
            string tituloChamado = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricaoChamado = Console.ReadLine();

            Console.Write("Digite o ID do equipamento relacionado: ");
            int idEquipamento = int.Parse(Console.ReadLine());

            Equipamento equipamentoSelecionado = equipamentosRegistrados.FirstOrDefault(e => e.registroId == idEquipamento);

            if (equipamentoSelecionado == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            string dataAbertura = DateTime.Now.ToString("dd/MM/yyyy");
            int diasEmAberto = 0; 

            Chamado novoChamado = new Chamado
            {
                registroId = chamadosRegistrados.Count + 1,
                titulo = tituloChamado,
                descricao = descricaoChamado,
                dataAbertura = dataAbertura,
                equipamentoRelacionado = equipamentoSelecionado,
                diasEmAberto = diasEmAberto
            };

            RegistarChamado( tituloChamado,  descricaoChamado,  dataAbertura,  equipamentoSelecionado,  diasEmAberto);

            Console.WriteLine("Chamado registrado com sucesso!");

        }

        private void RegistarChamado(string tituloChamado, string descricaoChamado, string dataAbertura, Equipamento equipamentoSelecionado, int diasEmAberto)
        {
            chamadosRegistrados.Add(new Chamado
            {
                registroId = chamadosRegistrados.Count + 1,
                titulo = tituloChamado,
                descricao = descricaoChamado,
                dataAbertura = dataAbertura,
                equipamentoRelacionado = equipamentoSelecionado,
                diasEmAberto = diasEmAberto
            });
        }

    }
}
