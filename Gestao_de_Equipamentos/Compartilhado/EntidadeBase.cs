

namespace Gestao_de_Equipamentos.Compartilhado;
public abstract class EntidadeBase 
{
    public int id;

    public abstract void MostrarInformacoes();

    public abstract void AtualizarInformacoes(EntidadeBase registroAtualizado);

    public abstract string ValidarInformacoes();
}
