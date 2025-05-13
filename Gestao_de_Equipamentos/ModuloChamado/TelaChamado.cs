using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class TelaChamado : Tela
    {  
        RepositorioEquipamento repositorioEquipamento;
        RepositorioChamado repositorioChamado;


        public TelaChamado(RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioChamado = repositorioChamado;
            this.repositorioEquipamento = repositorioEquipamento;
        }

        public string ExibirOpcoesMenu()
        {
            Console.Clear();

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
            Console.WriteLine("Cadastro de Chamados");

            Console.WriteLine("Cadastrando chamados...");

            Chamado chamado = ObterDados();

            string resultadoValidacao = chamado.Validar();
            if (resultadoValidacao != "")
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadKey();
                CadastrarChamado();
                return;
            }

            repositorioChamado.InserirChamado(chamado);

            Console.WriteLine("Chamado registrado com sucesso \n");
            Console.ReadKey();

            #region codigo comentado
            //Console.Write("Digite o título do chamado: ");
            //string tituloChamado = Console.ReadLine();

            //Console.Write("Digite a descrição do chamado: ");
            //string descricaoChamado = Console.ReadLine();

            //Console.Write("Digite o ID do equipamento relacionado: ");
            //int idEquipamento = int.Parse(Console.ReadLine());
            //var idEquipamento = 1;
            //Equipamento equipamentoSelecionado = repositorioEquipamento.equipamentosRegistrados.FirstOrDefault(e => e.id == idEquipamento);

            ////if (equipamentoSelecionado == null)
            ////{
            ////    Console.WriteLine("Equipamento não encontrado.");
            ////    return;
            ////}

            ////string dataAbertura = DateTime.Now.ToString("dd/MM/yyyy");
            //int diasEmAberto = 0;


            //var chamado = new Chamado();

            //chamado.titulo = "tituloChamado";
            //chamado.descricao = "descricaoChamado";
            //chamado.dataAbertura = DateTime.Now.ToString("dd/MM/yyyy");
            //chamado.equipamentoRelacionado = equipamentoSelecionado;
            //chamado.diasEmAberto = diasEmAberto;

            //repositorioChamado.InserirChamado(chamado);

            //Console.WriteLine("Chamado registrado com sucesso!");
            #endregion
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
            //if (int.TryParse(novoIdEquipamentoConvercao, out int novoIdEquipamento))
            //{
            //    Equipamento equipamentoAlterado = repositorioEquipamento.equipamentosRegistrados.FirstOrDefault(e => e.id == novoIdEquipamento);
            //    if (equipamentoAlterado != null)
            //        chamado.equipamentoRelacionado = equipamentoAlterado;
            //}


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

        public Chamado ObterDados()
        {
            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            DateTime dataAbertura = DateTime.Now;

            VisualizarEquipamentos();

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(idEquipamento);

            Chamado chamado = new Chamado();
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.dataAbertura = dataAbertura;
            chamado.equipamento = equipamentoSelecionado;

            return chamado;
        }

        public void VisualizarEquipamentos()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Equipamentos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );

            List<Entidade> equipamentos = repositorioEquipamento.SelecionarTodos();

            for (int i = 0; i < equipamentos.Count; i++)
            {
                Equipamento e = (Equipamento)equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine (
                    "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                    e.id, e.nome, e.preco.ToString("C2"), e.serie, e.fabricante, e.dataFabricacao
                );
            }

            Console.ReadLine();
        }
    }
}
