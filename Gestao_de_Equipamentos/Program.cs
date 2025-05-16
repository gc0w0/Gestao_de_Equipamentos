using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using Gestao_de_Equipamentos.ModuloFabricante;
using Microsoft.Win32;

namespace Gestao_de_Equipamentos
{
    internal class Program
    {
        private static void MostrarRegistros(List<Entidade> registros)
        {
            Console.WriteLine("Mostrando registros...");

            for (int i = 0; i < registros.Count; i++)
            {
                registros[i].MostrarInformacoes();
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //MostrarRegistros(registros);

            RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
            //repositorioEquipamento.InserirRegistro(new Equipamento());

            RepositorioFabricante repositorioFabricante = new RepositorioFabricante();
            //repositorioFabricante.InserirRegistro(new Fabricante());

            RepositorioChamado repositorioChamado = new RepositorioChamado();
            TelaEquipamento telaEquipamento = new TelaEquipamento(repositorioEquipamento, repositorioFabricante);
            TelaChamado telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);
            TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante, repositorioEquipamento);

            //TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                TelaPrincipal telaPrincipal = new TelaPrincipal();
                telaPrincipal.ExibirOpcoesMenu();

                if (telaPrincipal.opcaoEscolhida == "1")
                    GerenciarEquipamentos(telaEquipamento, telaPrincipal);

                else if (telaPrincipal.opcaoEscolhida == "2")
                    GerenciarChamados(telaChamado, telaPrincipal);

                else if (telaPrincipal.opcaoEscolhida == "3")
                    GerenciarFabricantes(telaFabricante, telaPrincipal);

                else if(telaPrincipal.opcaoEscolhida == "S")
                {
                    Console.WriteLine("Saindo do sistema...");
                    break;
                }
            }
        }

        private static void GerenciarFabricantes(TelaFabricante telaFabricante, TelaPrincipal telaPrincipal)
        {
            telaFabricante.ExibirOpcoesMenu();
            if (telaFabricante.opcaoEscolhida == "1")
                telaFabricante.CadastrarFabricante();
            else if (telaFabricante.opcaoEscolhida == "2")
                telaFabricante.ExibirFabricante(mostrarCabecalho: true);
            else if (telaFabricante.opcaoEscolhida == "3")
                telaFabricante.EditarFabricante();
            else if (telaFabricante.opcaoEscolhida == "4")
                telaFabricante.ExcluirFabricante();
        }

        private static void GerenciarChamados(TelaChamado telaChamado, TelaPrincipal telaPrincipal)
        {
            telaChamado.ExibirOpcoesMenu();
            if (telaChamado.opcaoEscolhida == "1")
                telaChamado.CadastrarChamado();
            else if (telaChamado.opcaoEscolhida == "2")
                telaChamado.ExibirChamados(mostrarCabecalho: true);
            else if (telaChamado.opcaoEscolhida == "3")
                telaChamado.EditarChamado();
            else if (telaChamado.opcaoEscolhida == "4")
                telaChamado.ExcluirChamado();
        }

        private static void GerenciarEquipamentos(TelaEquipamento telaEquipamento, TelaPrincipal telaPrincipal)
        {
            telaEquipamento.ExibirOpcoesMenu();

            if (telaEquipamento.opcaoEscolhida == "1")
                telaEquipamento.CadastrarEquipamento();

            else if (telaEquipamento.opcaoEscolhida == "2")
                telaEquipamento.ExibirEquipamentos(mostrarCabecalho: true);

            else if (telaEquipamento.opcaoEscolhida == "3")
                telaEquipamento.EditarEquipamento();

            else if (telaEquipamento.opcaoEscolhida == "4")
                telaEquipamento.ExcluirEquipamento();
        }
    }
}
