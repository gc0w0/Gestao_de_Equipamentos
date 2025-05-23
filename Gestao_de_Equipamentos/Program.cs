using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using Gestao_de_Equipamentos.ModuloFabricante;
using Gestao_de_Equipamentos.ModuloSetor;
using Microsoft.Win32;

namespace Gestao_de_Equipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repositorioFabricante = new RepositorioFabricante();
            var fabricante = new Fabricante("Fab01", "fab01@gmail", "654987");
            repositorioFabricante.InserirRegistro(fabricante);

            var repositorioEquipamento = new RepositorioEquipamento();
            var equipamento = new Equipamento(321, "Mouse", DateTime.Now, 10, fabricante);
            repositorioEquipamento.InserirRegistro(equipamento); 


            var repositorioChamado = new RepositorioChamado();
            var telaEquipamento = new TelaEquipamento(repositorioEquipamento, repositorioFabricante);
            
            var telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);
            var telaFabricante = new TelaFabricante(repositorioFabricante, repositorioEquipamento);

            var repositorioSetor = new RepositorioSetor();
            var telaSetor = new TelaSetor(repositorioSetor);

            var telaPrincipal = new TelaPrincipal();

            while (true)
            {
                telaPrincipal.ExibirOpcoesMenu();

                if (telaPrincipal.opcaoEscolhida == "1")
                    GerenciarEquipamentos(telaEquipamento, telaPrincipal);

                else if (telaPrincipal.opcaoEscolhida == "2")
                    GerenciarChamados(telaChamado, telaPrincipal);

                else if (telaPrincipal.opcaoEscolhida == "3")
                    GerenciarFabricantes(telaFabricante, telaPrincipal);

                else if (telaPrincipal.opcaoEscolhida == "4")
                    GerenciarSetores(telaSetor, telaPrincipal);

                else if(telaPrincipal.opcaoEscolhida == "S")
                {
                    Console.WriteLine("Saindo do sistema...");
                    break;
                }
            }
        }

        private static void GerenciarSetores(TelaSetor telaSetor, TelaPrincipal telaPrincipal)
        {
            telaSetor.ExibirOpcoesMenu();
            if (telaSetor.opcaoEscolhida == "1")
                telaSetor.CadastrarRegistro();
            else if (telaSetor.opcaoEscolhida == "2")
                telaSetor.ExibirRegistro(mostrarCabecalho: true);
            else if (telaSetor.opcaoEscolhida == "3")
                telaSetor.EditarRegistro();
            else if (telaSetor.opcaoEscolhida == "4")
                telaSetor.ExcluirRegistro();
        }

        private static void GerenciarFabricantes(TelaFabricante telaFabricante, TelaPrincipal telaPrincipal)
        {
            telaFabricante.ExibirOpcoesMenu();
            if (telaFabricante.opcaoEscolhida == "1")
                telaFabricante.CadastrarRegistro();
            else if (telaFabricante.opcaoEscolhida == "2")
                telaFabricante.ExibirRegistro(mostrarCabecalho: true);
            else if (telaFabricante.opcaoEscolhida == "3")
                telaFabricante.EditarRegistro();
            else if (telaFabricante.opcaoEscolhida == "4")
                telaFabricante.ExcluirRegistro();
        }

        private static void GerenciarChamados(TelaChamado telaChamado, TelaPrincipal telaPrincipal)
        {
            telaChamado.ExibirOpcoesMenu();
            if (telaChamado.opcaoEscolhida == "1")
                telaChamado.CadastrarRegistro();
            else if (telaChamado.opcaoEscolhida == "2")
                telaChamado.ExibirRegistro(mostrarCabecalho: true);
            else if (telaChamado.opcaoEscolhida == "3")
                telaChamado.EditarRegistro();
            else if (telaChamado.opcaoEscolhida == "4")
                telaChamado.ExcluirRegistro();
        }

        private static void GerenciarEquipamentos(TelaEquipamento telaEquipamento, TelaPrincipal telaPrincipal)
        {
            telaEquipamento.ExibirOpcoesMenu();

            if (telaEquipamento.opcaoEscolhida == "1")
                telaEquipamento.CadastrarRegistro();

            else if (telaEquipamento.opcaoEscolhida == "2")
                telaEquipamento.ExibirEquipamentos(mostrarCabecalho: true);

            else if (telaEquipamento.opcaoEscolhida == "3")
                telaEquipamento.EditarRegistro();

            else if (telaEquipamento.opcaoEscolhida == "4")
                telaEquipamento.ExcluirRegistro();
        }
    }
}
