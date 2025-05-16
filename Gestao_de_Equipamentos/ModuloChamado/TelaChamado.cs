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
            Console.Clear();

            Console.WriteLine("Modulo de Chamados");

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

            repositorioChamado.InserirRegistro(chamado);

            Console.WriteLine("Chamado registrado com sucesso \n");
            Console.ReadKey();

        }

        internal void EditarChamado()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Chamados"); //título

            Console.WriteLine("Editando chamados..."); //subtítulo

            ExibirChamados(mostrarCabecalho: false);

            Console.Write("Digite o Chamado que deseja editar: ");
            var id = int.Parse(Console.ReadLine());

            Chamado chamado = ObterDados();

            bool conseguiuEditar = repositorioChamado.EditarChamado(id, chamado);

            if (conseguiuEditar == false)
            {
                Console.WriteLine("Não foi possível editar o registro selecionado");
                Console.ReadKey();
                EditarChamado();
                return;
            }

            Console.WriteLine("Chamado editado com sucesso!");
            Console.ReadKey();
        }

        internal void ExcluirChamado()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Chamados"); //título

            Console.WriteLine("Excluindo chamados..."); //subtítulo

            ExibirChamados(mostrarCabecalho: false);

            Console.Write("Digite o Chamado que deseja excluir: ");
            var id = int.Parse(Console.ReadLine());

            bool conseguiuExcluir = repositorioChamado.ExcluirChamado(id);

            if (conseguiuExcluir == false)
            {
                Console.WriteLine("Não foi possível excluir o registro selecionado");
                Console.ReadKey();
                ExcluirChamado();
                return;
            }

            Console.WriteLine("Chamado removido com sucesso!");
            Console.ReadKey();
        }

        public void ExibirChamados(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                Console.Clear();

                Console.WriteLine("Módulo de Chamados"); //título

                Console.WriteLine("Visualizando chamados..."); //subtítulo
            }

            List<Chamado> chamados = repositorioChamado.SelecionarTodos();

            for (int i = 0; i < chamados.Count; i++)
            {
                chamados[i].MostrarInformacoes();
            }
            Console.ReadKey();
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

            Chamado chamado = new Chamado(titulo, descricao, dataAbertura, equipamentoSelecionado);
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
                    e.id, e.nome, e.preco.ToString("C2"), e.serie, e.fabricante.nome, e.dataFabricacao
                );
            }

            Console.ReadLine();
        }
    }
}
