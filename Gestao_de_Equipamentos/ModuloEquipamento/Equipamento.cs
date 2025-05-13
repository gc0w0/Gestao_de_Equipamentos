using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloFabricante;

namespace Gestao_de_Equipamentos.ModuloEquipamento;

public class Equipamento : Entidade
{
    public double serie;
    public string nome;
    public int dataFabricacao;
    public decimal preco;
    public string fabricante;
    public Fabricante fabricanteRelacionado;

    public override string ToString()
    {
        return $"ID de Registro: {id} | Nome: {nome} | Preço {preco} | Fabricante: {fabricanteRelacionado} | Data de Fabricação: {dataFabricacao}";
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

