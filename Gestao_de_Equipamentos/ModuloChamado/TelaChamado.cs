using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class TelaChamado : TelaBase
    {  
        RepositorioEquipamento repositorioEquipamento;
        RepositorioChamado repositorioChamado;

        public TelaChamado(RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioChamado = repositorioChamado;
            this.repositorioEquipamento = repositorioEquipamento;
            modulo = "Chamado";
        }
      
        internal void EditarChamado()
        {
            Console.Clear();

            Console.WriteLine("Módulo de Chamados"); //título

            Console.WriteLine("Editando chamados..."); //subtítulo

            ExibirChamados(mostrarCabecalho: false);

            Console.Write("Digite o Chamado que deseja editar: ");
            var id = int.Parse(Console.ReadLine());

            Chamado chamado = (Chamado)ObterDados();

            bool conseguiuEditar = repositorioChamado.EditarRegistro(id, chamado);

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

            bool conseguiuExcluir = repositorioChamado.ExcluirRegistro(id);

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

            List<EntidadeBase> chamados = repositorioChamado.SelecionarTodos();

            Console.WriteLine(
              "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15}" +          
              "Id", "Data de Abertura", "Título", "Descrição", "Equipamento"
            );

            for (int i = 0; i < chamados.Count; i++)
            {
                Chamado chamado = (Chamado) chamados[i];

                Console.WriteLine(
                  "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15}" +
                   chamado.id, chamado.dataAbertura, chamado.titulo, chamado.descricao, chamado.equipamento.nome
                );
            }

            Console.ReadKey();
        }

        public override EntidadeBase ObterDados()
        {
            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            DateTime dataAbertura = DateTime.Now;

            VisualizarEquipamentos();

            Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = (Equipamento)repositorioEquipamento.SelecionarPorId(idEquipamento);

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

            List<EntidadeBase> equipamentos = repositorioEquipamento.SelecionarTodos();

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
