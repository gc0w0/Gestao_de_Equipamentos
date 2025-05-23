namespace Gestao_de_Equipamentos.Compartilhado;

public abstract class EntidadeBase<T> 
{
    public int id;

    public abstract void MostrarInformacoes();

    public abstract void AtualizarInformacoes(T registroAtualizado);

    public abstract string ValidarInformacoes();
}
