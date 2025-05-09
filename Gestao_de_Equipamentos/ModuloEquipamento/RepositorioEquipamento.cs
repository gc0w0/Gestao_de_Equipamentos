using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloChamado;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class RepositorioEquipamento : Repositorio
    {
        public List<Equipamento> equipamentosRegistrados = new List<Equipamento>();
        TelaChamado Chamado;
        internal void InserirEquipamento(Equipamento equipamento)
        {
            equipamento.id = equipamentosRegistrados.Count + 1;
            equipamentosRegistrados.Add(equipamento);
        }
    }
}
