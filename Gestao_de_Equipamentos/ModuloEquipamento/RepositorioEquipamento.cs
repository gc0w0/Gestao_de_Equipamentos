using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloEquipamento
{
    public class RepositorioEquipamento : Repositorio
    {
        public List<Equipamento> equipamentosRegistrados = new List<Equipamento>();
        Controle_De_Chamado controleChamado;

        internal void InserirEquipamento(Equipamento equipamento)
        {
            equipamento.id = equipamentosRegistrados.Count + 1;
            equipamentosRegistrados.Add(equipamento);

        }






    }
}
