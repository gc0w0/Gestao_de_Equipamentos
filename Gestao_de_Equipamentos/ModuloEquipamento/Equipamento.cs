using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloFabricante;

namespace Gestao_de_Equipamentos.ModuloEquipamento;

public class Equipamento : Entidade
{
    public double serie; //tem que ser string
    public string nome;
    public DateTime dataFabricacao;
    public decimal preco;
    public Fabricante fabricante;
    public List<Chamado> chamados;

    public Equipamento(double serie, string nome, DateTime dataFabricacao, decimal preco, Fabricante fabricante)
    {
        this.serie = serie;
        this.nome = nome;
        this.dataFabricacao = dataFabricacao;
        this.preco = preco;
        this.fabricante = fabricante;
    }

    public override void MostrarInformacoes()
    {
        Console.WriteLine($"ID de Registro: {id} | Nome: {nome} | Preço {preco} | Fabricante: {fabricante.nome} | Data de Fabricação: {dataFabricacao}");
    }

    public string Validar()
    {
        string resultadoValidacao = "";

        if (string.IsNullOrEmpty(nome))
            resultadoValidacao += "O campo \"nome\" é obrigatório" + "\n";

        if (nome.Length < 3)
            resultadoValidacao += "O campo \"nome\" precisa ter no mínimo 3 letras" + "\n";

        if (preco < 0)
            resultadoValidacao += "O campo \"preço\" precisa não pode ser negativo" + "\n";

        if (serie == 0)
            resultadoValidacao += "O campo \"serie\" é obrigatório" + "\n";

        return resultadoValidacao;
    }

}

