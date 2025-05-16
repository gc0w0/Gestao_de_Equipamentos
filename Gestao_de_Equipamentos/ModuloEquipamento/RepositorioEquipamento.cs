using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class RepositorioEquipamento : Repositorio
    {

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
             return (Equipamento)registros.FirstOrDefault(e => e.id == id);
        }

        internal List<Entidade> SelecionarTodos()
        {
            return registros;
        }

    }
}
