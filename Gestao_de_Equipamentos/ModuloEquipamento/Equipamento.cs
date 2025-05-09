using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloEquipamento;

public class Equipamento : Entidade
{
    public double serie;
    public string nome;
    public DateTime dataFabricacao;
    public decimal preco;
    public string fabricante;

    public override string ToString()
    {
        return $"ID de Registro: {id} | Nome: {nome} | Preço {preco} | Fabricante: {fabricante} | Data de Fabricação: {dataFabricacao}";
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

        if (string.IsNullOrEmpty(fabricante))
            resultadoValidacao += "O campo \"fabricante\" é obrigatório" + "\n";

        if (serie == 0)
            resultadoValidacao += "O campo \"serie\" é obrigatório" + "\n";

        return resultadoValidacao;
    }

}

