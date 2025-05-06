using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            telaPrincipal.ExibirOpcoesMenu();

            while (true)
            {
                if (telaPrincipal.opcaoEscolhida == "s")
                    break;

                if (telaPrincipal.opcaoEscolhida == "1")
                {
                    TelaEquipamento telaEquipamento = new TelaEquipamento();

                    telaEquipamento.ExibirOpcoesMenu();

                    if (telaEquipamento.opcaoEscolhida == "1")
                        telaEquipamento.InserirEquipamento();

                    else if (telaEquipamento.opcaoEscolhida == "2")
                        telaEquipamento.EditarEquipamento();

                    else if (telaEquipamento.opcaoEscolhida == "3")
                        telaEquipamento.ExcluirEquipamento();

                    else if (telaEquipamento.opcaoEscolhida == "4")
                        telaEquipamento.VisualizarEquipamentos();
                }

                else if (telaPrincipal.opcaoEscolhida == "2")
                {
                    TelaChamado telaChamado = new TelaChamado();

                    telaChamado.ExibirOpcoesMenu();

                    if (telaChamado.opcaoEscolhida == "1")
                    {
                        telaChamado.InserirChamado();
                    }
                    else if (telaChamado.opcaoEscolhida == "2")
                    {
                        telaChamado.EditarChamado();
                    }
                    else if (telaChamado.opcaoEscolhida == "3")
                    {
                        telaChamado.ExcluirChamado();
                    }
                    else if (telaChamado.opcaoEscolhida == "4")
                    {
                        telaChamado.VisualizarChamados();
                    }
                }

               
            }
        }
    }
}
