namespace Gestao_de_Equipamentos.Compartilhado;

internal class TelaPrincipal : Tela
{    
    public void ExibirOpcoesMenu()
    {
        Console.WriteLine("Digite 1 para gerenciar Equipaamentos");
        Console.WriteLine("Digite 2 para gerenciar Chamados");
        Console.WriteLine("Digite s para sair");

        opcaoEscolhida = Console.ReadLine();
    }
}
