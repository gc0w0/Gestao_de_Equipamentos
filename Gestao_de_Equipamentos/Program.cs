using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using Gestao_de_Equipamentos.ModuloFabricante;

namespace Gestao_de_Equipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
            RepositorioChamado repositorioChamado = new RepositorioChamado();
            RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

            TelaPrincipal telaPrincipal = new TelaPrincipal();
            telaPrincipal.ExibirOpcoesMenu();

            while (true)
            {

                if (telaPrincipal.opcaoEscolhida == "1")
                {
                    TelaEquipamento telaEquipamento = new TelaEquipamento(repositorioEquipamento, repositorioFabricante);
                    telaEquipamento.ExibirOpcoesMenu();

                    if (telaEquipamento.opcaoEscolhida == "1")
                        telaEquipamento.CadastrarEquipamento();

                    else if (telaEquipamento.opcaoEscolhida == "2")
                        telaEquipamento.ExibirEquipamentos(mostrarCabecalho: true);

                    else if (telaEquipamento.opcaoEscolhida == "3")
                        telaEquipamento.EditarEquipamento();

                    else if (telaEquipamento.opcaoEscolhida == "4")
                        telaEquipamento.ExcluirEquipamento();

                    else if (telaEquipamento.opcaoEscolhida == "S")
                    {
                        Console.WriteLine("Saindo do sistema...");
                        telaPrincipal.ExibirOpcoesMenu();
                    }
                    else
                        Console.WriteLine("Opção inválida. Tente novamente.");
                }

                if (telaPrincipal.opcaoEscolhida == "2")
                {
                    TelaChamado telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);

                    telaChamado.ExibirOpcoesMenu();
                    if (telaChamado.opcaoEscolhida == "1")
                        telaChamado.CadastrarChamado();

                    else if (telaChamado.opcaoEscolhida == "2")
                        telaChamado.ExibirChamado();
                    else if (telaChamado.opcaoEscolhida == "3")
                        telaChamado.EditarChamado();
                    else if (telaChamado.opcaoEscolhida == "4")
                        telaChamado.ExcluirChamado();

                    else if (telaChamado.opcaoEscolhida == "S")
                    {
                        Console.WriteLine("Saindo do sistema...");
                        telaPrincipal.ExibirOpcoesMenu();
                    }
                    else
                        Console.WriteLine("Opção inválida. Tente novamente.");

                }

                else if (telaPrincipal.opcaoEscolhida == "S")
                {
                    Console.WriteLine("Saindo do sistema...");
                    break;
                }

                if (telaPrincipal.opcaoEscolhida == "3")
                {
                    TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante, repositorioEquipamento);
                    telaFabricante.ExibirOpcoesMenu();
                    if (telaFabricante.opcaoEscolhida == "1")
                        telaFabricante.CadastrarFabricante();
                    else if (telaFabricante.opcaoEscolhida == "2")
                        telaFabricante.ExibirFabricante();
                    else if (telaFabricante.opcaoEscolhida == "3")
                        telaFabricante.EditarFabricante();
                    else if (telaFabricante.opcaoEscolhida == "4")
                        telaFabricante.ExcluirFabricante();
                    else if (telaFabricante.opcaoEscolhida == "S")
                    {
                        Console.WriteLine("Saindo do sistema...");
                        telaPrincipal.ExibirOpcoesMenu();
                    }
                    else
                        Console.WriteLine("Opção inválida. Tente novamente.");
                }

                else if (telaPrincipal.opcaoEscolhida == "S")
                {
                    Console.WriteLine("Saindo do sistema...");
                    break;
                }

            }
        }
    }
}
