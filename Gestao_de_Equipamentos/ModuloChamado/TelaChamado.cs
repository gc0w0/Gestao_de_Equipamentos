using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloChamado;

internal class TelaChamado : Tela
{    
    public void ExibirOpcoesMenu()
    {
        ///equipamento 
        Console.WriteLine("Digite 1 para inserir novo Chamado");
        Console.WriteLine("Digite 2 para editar Chamado existente");
        Console.WriteLine("Digite 3 para excluir Chamado existente");
        Console.WriteLine("Digite 4 para visualizar Chamados");

        opcaoEscolhida = Console.ReadLine();
    }

    internal void EditarChamado()
    {
        throw new NotImplementedException();
    }

    internal void ExcluirChamado()
    {
        throw new NotImplementedException();
    }

    internal void InserirChamado()
    {
        throw new NotImplementedException();
    }

    internal void VisualizarChamados()
    {
        throw new NotImplementedException();
    }
}
