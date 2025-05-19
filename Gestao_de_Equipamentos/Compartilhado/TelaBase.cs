using Gestao_de_Equipamentos.ModuloChamado;

namespace Gestao_de_Equipamentos.Compartilhado;

public abstract class TelaBase
{
    public string opcaoEscolhida;

    public string titulo;

    public string modulo;

    public RepositorioBase repositorio;

    public string ExibirOpcoesMenu()
    {
        Console.Clear();

        Console.WriteLine($"Bem-vindo ao gerenciamento de {modulo}s!\n");
        Console.WriteLine($"Digite 1 para cadastrar um novo {modulo}:");
        Console.WriteLine($"Digite 2 para exibir os {modulo}s:");
        Console.WriteLine($"Digite 3 para editar um {modulo}:");
        Console.WriteLine($"Digite 4 para excluir um {modulo}:");
        Console.WriteLine("Digite S para sair");
        Console.Write(">: ");

        opcaoEscolhida = Console.ReadLine();

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {
        Console.Clear();

        Console.WriteLine($"Modulo de {modulo}s");

        Console.WriteLine($"Cadastrando {modulo}s...");

        EntidadeBase registro = ObterDados();

        string resultadoValidacao = registro.Validar();

        if (resultadoValidacao != "")
        {
            Console.WriteLine(resultadoValidacao);
            Console.ReadKey();
            CadastrarRegistro();
            return;
        }

        repositorio.InserirRegistro(registro);

        Console.WriteLine("Registro inserido com sucesso \n");
        Console.ReadKey();
    }

    public abstract EntidadeBase ObterDados();
}
