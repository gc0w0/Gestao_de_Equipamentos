using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloEquipamento;

internal class RepositorioEquipamento : Repositorio
{
    public List<Equipamento> equipamentosRegistrados = new List<Equipamento>();

    internal void InserirEquipamento(Equipamento equipamento)
    {
        equipamentosRegistrados.Add(equipamento);
    }
}


