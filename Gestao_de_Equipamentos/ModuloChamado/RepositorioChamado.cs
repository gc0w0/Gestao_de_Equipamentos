using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class RepositorioChamado : Repositorio
    {              
        public List<Chamado> registros = new List<Chamado>();       

        public void InserirChamado(Chamado chamado)
        {
            chamado.id = registros.Count + 1;
            registros.Add(chamado);
        }

        public bool EditarChamado(int id, Chamado chamadoAtualizado)
        {
            Chamado? chamado = SelecionarPorId(id);

            if (chamado == null)
                return false;
            
            chamado.titulo = chamadoAtualizado.titulo;
            chamado.dataAbertura = chamadoAtualizado.dataAbertura;
            chamado.descricao = chamadoAtualizado.descricao;
            chamado.equipamento = chamadoAtualizado.equipamento;
            chamado.diasEmAberto = chamadoAtualizado.diasEmAberto;

            return true;

        }

        public Chamado SelecionarPorId(int id)
        {
            return registros.FirstOrDefault(e => e.id == id);
        }

        internal List<Chamado> SelecionarTodos()
        {
            return registros;
        }

        internal bool ExcluirChamado(int id)
        {
            Chamado? chamado = SelecionarPorId(id);

            if (chamado == null)
                return false;

            registros.Remove(chamado);

            return true;
        }
    }
}
