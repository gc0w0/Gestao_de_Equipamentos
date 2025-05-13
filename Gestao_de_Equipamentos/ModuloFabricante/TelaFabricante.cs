using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloFabricante
{
    public class TelaFabricante : Tela
    {
        RepositorioEquipamento repositorioEquipamento;

        RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioFabricante, RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioFabricante = repositorioFabricante;
            this.repositorioEquipamento = repositorioEquipamento;
        }

        public string ExibirOpcoesMenu()
        {
            Console.WriteLine("Bem-vindo ao gerenciamento de Fabricantes!\n");
            Console.WriteLine("Digite 1 para cadastrar um novo fabricante:");
            Console.WriteLine("Digite 2 para exibir os fabricantes:");
            Console.WriteLine("Digite 3 para editar um fabricantes:");
            Console.WriteLine("Digite 4 para excluir um fabricantes:");
            Console.WriteLine("Digite S para sair");
            Console.Write(">: ");

            opcaoEscolhida = Console.ReadLine();
            return opcaoEscolhida;
        }

        internal void CadastrarFabricante()
        {
            Console.WriteLine("Cadastro de Fabricantes");

            Console.WriteLine("Cadastrando fabricantes...");

            Fabricante fabricante = ObterDados();

            string resultadoValidacao = fabricante.Validar();
            if (resultadoValidacao != "")
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadKey();
                CadastrarFabricante();
                return;
            }

            repositorioFabricante.InserirFabricante(fabricante);

            Console.WriteLine("Fabricante registrado com sucesso \n");
            Console.ReadKey();
        }

        internal void EditarFabricante()
        {
            Console.Write("Digite o ID do fabricante que deseja editar: ");
            var id = int.Parse(Console.ReadLine());

            Fabricante fabricante = repositorioFabricante.fabricantesRegistrados.FirstOrDefault(c => c.id == id);

            if (fabricante == null)
                Console.WriteLine("Fabricante não encontrado.");

            Console.Write("Novo nome (ENTER para manter): ");
            string novoTitulo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoTitulo))
                fabricante.nome = novoTitulo;

            Console.Write("Nova email (ENTER para manter): ");
            string novaDescricao = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaDescricao))
                fabricante.email = novaDescricao;

            Console.Write("Novo ID de equipamento (ENTER para manter): ");
            string novoIdEquipamentoConvercao = Console.ReadLine();
            //if (int.TryParse(novoIdEquipamentoConvercao, out int novoIdEquipamento))
            //{
            //    Equipamento equipamentoAlterado = repositorioEquipamento.equipamentosRegistrados.FirstOrDefault(e => e.id == novoIdEquipamento);
            //    if (equipamentoAlterado != null)
            //        chamado.equipamentoRelacionado = equipamentoAlterado;
            //}

            Console.WriteLine("Fabricante atualizado.");
        }

        internal void ExcluirFabricante()
        {
            Console.Write("Digite o ID do fabricante a excluir: ");
            var id = int.Parse(Console.ReadLine());

            Fabricante fabricante = repositorioFabricante.fabricantesRegistrados.FirstOrDefault(c => c.id == id);

            if (fabricante == null)
            {
                Console.WriteLine("Fabricante não encontrado.");
                return;
            }

            repositorioFabricante.fabricantesRegistrados.Remove(fabricante);
            Console.WriteLine("Fabricante excluído com sucesso.");
        }

        internal void ExibirFabricante()
        {
            List<Equipamento> todosEquipamentos = repositorioEquipamento.SelecionarTodos();

            Console.WriteLine("Fabricantes Registrados:");

            foreach (var fabricante in repositorioFabricante.SelecionarTodos())
            {
                int quantidadeEquipamentos = todosEquipamentos.Count(e =>
                    e.fabricanteRelacionado != null &&
                    e.fabricanteRelacionado.id == fabricante.id);

                Console.WriteLine(
                    $"ID: {fabricante.id} | Nome: {fabricante.nome} | Email: {fabricante.email} | Telefone: {fabricante.telefone} | Equipamentos: {quantidadeEquipamentos}"
                );
            }
        }

        public Fabricante ObterDados()
        {
            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine();

            //VisualizarEquipamentos();

            //Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            //int idEquipamento = Convert.ToInt32(Console.ReadLine());

            //Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(idEquipamento);

            Fabricante fabricante = new Fabricante();
            fabricante.nome = nome;
            fabricante.email = email;
            fabricante.telefone = telefone;
            //fabricante.equipamentoRelacionado = equipamentoSelecionado;

            return fabricante;
        }

        #region Sessão Comentada
        //public void VisualizarEquipamentos()
        //{
        //    Console.WriteLine();

        //    Console.WriteLine("Visualização de Equipamentos");

        //    Console.WriteLine();

        //    Console.WriteLine(
        //        "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
        //        "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
        //    );

        //    List<Equipamento> equipamentos = repositorioEquipamento.SelecionarTodos();

        //    for (int i = 0; i < equipamentos.Count; i++)
        //    {
        //        Equipamento e = equipamentos[i];

        //        if (e == null)
        //            continue;

        //        Console.WriteLine(
        //            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
        //            e.id, e.nome, e.preco.ToString("C2"), e.serie, e.fabricante, e.dataFabricacao.ToShortDateString()
        //        );
        //    }

        //    Console.ReadLine();
        //}
        #endregion




    }

}
