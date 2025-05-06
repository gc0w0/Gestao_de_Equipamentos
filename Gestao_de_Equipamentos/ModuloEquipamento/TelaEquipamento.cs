using Gestao_de_Equipamentos.Compartilhado;
using System.Threading.Tasks.Sources;

namespace Gestao_de_Equipamentos.ModuloEquipamento;

public class TelaEquipamento : Tela
{
    public RepositorioEquipamento repositorioEquipamento;

    public void ExibirOpcoesMenu()
    {
        ///equipamento 
        Console.WriteLine("Digite 1 para inserir novo Equipamento");
        Console.WriteLine("Digite 2 para editar Equipamento existente");
        Console.WriteLine("Digite 3 para excluir Equipamento existente");
        Console.WriteLine("Digite 4 para visualizar Equipamentos");

        opcaoEscolhida = Console.ReadLine();
    }

    internal void InserirEquipamento()
    {
        Console.Write("Digite o nome do Equipamento com no minimo 6 letras: ");
        var nome = Console.ReadLine();

        Console.Write("Digite o preço do equipamento: ");
        var preco = decimal.Parse(Console.ReadLine());
        Console.Write("Digite o numero de serie: ");
        var serie = double.Parse(Console.ReadLine());
        Console.Write("Digite o Fabricante do equipamento: ");
        var fabricante = Console.ReadLine();
        Console.Write("Digite a data de fabricação do equipamento: ");
        var data_Fabricacao = int.Parse(Console.ReadLine());

        var equipamento = new Equipamento();
        equipamento.fabricante = fabricante;
        equipamento.preco = preco;
        equipamento.dataFabricacao = data_Fabricacao;
        equipamento.nome = nome;

        repositorioEquipamento.InserirEquipamento(equipamento);
    }

    internal void EditarEquipamento()
    {
        throw new NotImplementedException();
    }

    internal void ExcluirEquipamento()
    {
        throw new NotImplementedException();
    }

    internal void VisualizarEquipamentos()
    {
        throw new NotImplementedException();
    }
}
