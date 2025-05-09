using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloEquipamento;

public class Equipamento : Entidade
{
    public double serie;
    public string nome;
    public int dataFabricacao;
    public decimal preco;
    public string fabricante;

    public override string ToString()
    {
        return $"ID de Registro: {id} | Nome: {nome} | Preço {preco} | Fabricante: {fabricante} | Data de Fabricação: {dataFabricacao}";
    }

    public bool Validar(int quantidadeMinimaCaractere)
    {
        quantidadeMinimaCaractere = 6; // vou usar pro nome ter no minimo 6 caracteres

        if (nome.Length > quantidadeMinimaCaractere)
            return false;

        return true;
    }

}

