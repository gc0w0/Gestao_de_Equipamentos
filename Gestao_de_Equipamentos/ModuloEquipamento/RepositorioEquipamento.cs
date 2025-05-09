using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class RepositorioEquipamento : Repositorio
    {
        private List<Equipamento> equipamentosRegistrados = new List<Equipamento>();

        public void InserirEquipamento(Equipamento equipamento)
        {
            equipamento.id = equipamentosRegistrados.Count + 1;
            equipamentosRegistrados.Add(equipamento);
        }

        public bool EditarEquipamento(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento? equipamento = SelecionarPorId(id);
            
            if (equipamento == null)
                return false;

            equipamento.nome = equipamentoAtualizado.nome;
            equipamento.fabricante = equipamentoAtualizado.fabricante;
            equipamento.dataFabricacao = equipamentoAtualizado.dataFabricacao;
            equipamento.preco = equipamentoAtualizado.preco;
            equipamento.serie = equipamentoAtualizado.serie;

            return true;
        }

        public Equipamento SelecionarPorId(int id)
        {
             return equipamentosRegistrados.FirstOrDefault(e => e.id == id);
        }

        internal List<Equipamento> SelecionarTodos()
        {
            return equipamentosRegistrados;
        }

        internal bool ExcluirEquipamento(int id)
        {
            Equipamento? equipamento = SelecionarPorId(id);

            if (equipamento == null)
                return false;

            equipamentosRegistrados.Remove(equipamento);

            return true;
        }
    }
}
