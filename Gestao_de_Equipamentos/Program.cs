using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using Gestao_de_Equipamentos.ModuloFabricante;
using Gestao_de_Equipamentos.ModuloSetor;

namespace Gestao_de_Equipamentos;

internal class Program
{
    //static void Main()
    //{
    //    //Casting com tipos primitivos

    //    int valorInteiro = 10;

    //    decimal valorDecimal = valorInteiro;

    //    double valorDouble = (double) valorDecimal;

    //    decimal valorDecimal2 = 10.30m;

    //    int valorInteiro2 = (int)valorDecimal2;

    //    string valorTexto = "123";

    //    int x = Convert.ToInt32( valorTexto );

    //    //casting com tipos complexos

    //    Fabricante e = (Fabricante) SelecionarFabricante();
    //}


    //public static Entidade SelecionarFabricante()
    //{
    //    return new Equipamento();
    //}

    //Fabricante f1 = new Fabricante();
    //f1.telefone = "321";

    //EntidadeBase f2 = f1;
    //f2.id = 12;

    //Object f3 = f2;
    //f3.ToString();

    static void Main(string[] args)
    {                     
        var repositorioFabricante = new RepositorioFabricante();
        var fabricante = new Fabricante("Fab01", "fab01@gmail", "654987");
        repositorioFabricante.InserirRegistro(fabricante);
        var telaFabricante = new TelaFabricante(repositorioFabricante);        

        var repositorioEquipamento = new RepositorioEquipamento();
        var equipamento = new Equipamento(321, "Mouse", DateTime.Now, 10, fabricante);
        repositorioEquipamento.InserirRegistro(equipamento);
        var telaEquipamento = new TelaEquipamento(repositorioEquipamento, repositorioFabricante);        

        var repositorioChamado = new RepositorioChamado();
        repositorioChamado.InserirRegistro(new Chamado("Não funciona", "Faltou pilha", DateTime.Now, equipamento));
        var telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);

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
    }

    private static void GerenciarFabricantes(TelaFabricante telaFabricante, TelaPrincipal telaPrincipal)
    {
        telaFabricante.ExibirOpcoesMenu();
        if (telaFabricante.opcaoEscolhida == "1")
            telaFabricante.CadastrarRegistro();

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
            telaChamado.CadastrarRegistro();
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
            telaEquipamento.CadastrarRegistro();

        else if (telaEquipamento.opcaoEscolhida == "2")
            telaEquipamento.ExibirEquipamentos(mostrarCabecalho: true);

        else if (telaEquipamento.opcaoEscolhida == "3")
            telaEquipamento.EditarEquipamento();

        else if (telaEquipamento.opcaoEscolhida == "4")
            telaEquipamento.ExcluirEquipamento();
    }
}
