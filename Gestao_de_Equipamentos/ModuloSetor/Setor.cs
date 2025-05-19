using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloSetor;

public class Setor : EntidadeBase
{
    public string nome;

    public Setor(string nome)
    {
        this.nome = nome;
    }

    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
    {
        Setor setorAtualizado = (Setor)registroAtualizado;
        this.nome = setorAtualizado.nome;
    }

    public override void MostrarInformacoes()
    {        
    }

    public override string Validar()
    {
        return "";
    }
}
