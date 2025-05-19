using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloSetor;

public class TelaSetor : TelaBase
{
    public TelaSetor(RepositorioSetor repositorioSetor)
    {
        modulo = "Setor";
        repositorio = repositorioSetor;
    }

    public override EntidadeBase ObterDados()
    {
        Console.Write( "Digite o nome: ");
        var nome = Console.ReadLine();
        return new Setor(nome);
    }
}
