using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloFabricante;

public class TelaFabricante : TelaBase<Fabricante>
{
    public TelaFabricante(RepositorioFabricante repositorioFabricante)
    {
        repositorio = repositorioFabricante;
        modulo = "Fabricantes";
    }

    private const string formatoColunasTabela = "{0, -10} | {1, -20} | {2, -15} | {3, -15}";
   
    public override void ExibirCabecalhoTabela()
    {
        Console.WriteLine(formatoColunasTabela, "Id", "Nome", "Email", "Telefone");
    }

    public override void ExibirLinhaTabela(Fabricante f)
    {
        Console.WriteLine(formatoColunasTabela, f.id, f.nome, f.email, f.telefone);
    }

    public override Fabricante ObterDados()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o email do fabricante: ");
        string email = Console.ReadLine();

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine();
      
        Fabricante fabricante = new Fabricante(nome, email, telefone);
        fabricante.nome = nome;
        fabricante.email = email;
        fabricante.telefone = telefone;

        return fabricante;
    }
}
