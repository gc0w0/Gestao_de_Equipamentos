using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using System.Diagnostics;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class Chamado : Entidade
    {        
        public string titulo;
        public string descricao;
        public string dataAbertura;
        public Equipamento equipamentoRelacionado;
        public int equipamentoChamado;
        public int diasEmAberto;

        public void AbrirChamado()
        {
        }

        public bool EstaAberto()
        {
            return false;
        }

        public override string ToString()
        {   equipamentoChamado = equipamentoRelacionado.registroId;
            return $" ID do Chamado:{id} Título: {titulo} | Equipamento: {equipamentoChamado} | Data: {dataAbertura} | Dias em aberto: {diasEmAberto}";
        }
    }
}
