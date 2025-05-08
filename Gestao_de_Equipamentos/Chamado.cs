
using System.Diagnostics;

namespace Gestao_de_Equipamentos
{
    public class Chamado
    {
        public int registroId;
        public int id;
        public string titulo;
        public string descricao;
        public string dataAbertura;
        public Equipamento equipamentoRelacionado;
        public int equipamentoChamado;
        public int diasEmAberto;

        public override string ToString()
        {   equipamentoChamado = equipamentoRelacionado.registroId;
            return $" ID do Chamado:{registroId} Título: {titulo} | Equipamento: {equipamentoChamado} | Data: {dataAbertura} | Dias em aberto: {diasEmAberto}";
        }
    }
}
