

using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos
{
    public class Controle_De_Chamado
    {
        private int id;
        private int equipamentoChamado;
        protected string titulo;
        private string descricao;
        protected string dataAbertura;
        protected Equipamento equipamentoRelacionado;
        public List<Equipamento> equipamentosRegistrados;
        private List<Chamado> chamadosRegistrados = new List<Chamado>();


    }
}