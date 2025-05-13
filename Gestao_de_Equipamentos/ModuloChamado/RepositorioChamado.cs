using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class RepositorioChamado : Repositorio
    {              
        public List<Chamado> chamadosRegistrados = new List<Chamado>();       

        public void InserirChamado(Chamado chamado)
        {
            chamado.id = chamadosRegistrados.Count + 1;
            chamadosRegistrados.Add(chamado);
        }

        public bool EditarChamado(int id, Chamado chamadoAtualizado)
        {
            Chamado? chamado = SelecionarPorId(id);

            if (chamado == null)
                return false;
            
            chamado.titulo = chamadoAtualizado.titulo;
            chamado.dataAbertura = chamadoAtualizado.dataAbertura;
            chamado.descricao = chamadoAtualizado.descricao;
            chamado.equipamentoRelacionado = chamadoAtualizado.equipamentoRelacionado;
            chamado.diasEmAberto = chamadoAtualizado.diasEmAberto;

            return true;

        }

        public Chamado SelecionarPorId(int id)
        {
            return chamadosRegistrados.FirstOrDefault(e => e.id == id);
        }

        internal List<Chamado> SelecionarTodos()
        {
            return chamadosRegistrados;
        }

        internal bool ExcluirChamado(int id)
        {
            Chamado? chamado = SelecionarPorId(id);

            if (chamado == null)
                return false;

            chamadosRegistrados.Remove(chamado);

            return true;
        }
    }
}
