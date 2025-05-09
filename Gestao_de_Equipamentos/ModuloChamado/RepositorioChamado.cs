using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class RepositorioChamado : Repositorio
    {
        public Equipamento equipamentoRelacionado;
        public List<Equipamento> equipamentosRegistrados;

        public List<Chamado> chamadosRegistrados = new List<Chamado>();
        public RepositorioChamado(List<Equipamento> equipamentos)
        {
            equipamentosRegistrados = equipamentos ?? new List<Equipamento>();
        }

        public void InserirChamado(Chamado chamado)
        {
            chamado.id = chamadosRegistrados.Count + 1;
            chamadosRegistrados.Add(chamado);
        }

    }
}
