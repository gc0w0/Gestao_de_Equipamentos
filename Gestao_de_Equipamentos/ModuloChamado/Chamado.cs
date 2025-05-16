
using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos
{
    public class Chamado : Entidade
    {
        public string titulo;
        public string descricao;
        public DateTime dataAbertura;
        public Equipamento equipamento;
        public int diasEmAberto;

        public Chamado(string titulo, string descricao, DateTime dataAbertura, Equipamento equipamento)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataAbertura = dataAbertura;
            this.equipamento = equipamento;
        }


        public override void MostrarInformacoes()
        {
            Console.WriteLine($" ID :{id} Título: {titulo} | Equipamento: {equipamento.nome} | Data: {dataAbertura} | Dias em aberto: {diasEmAberto}");
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(titulo))
                resultadoValidacao += "O campo \"nome\" é obrigatório" + "\n";

            if (titulo.Length < 3)
                resultadoValidacao += "O campo \"nome\" precisa ter no mínimo 3 letras" + "\n";

            if (string.IsNullOrEmpty(descricao))
                resultadoValidacao += "O campo \"descrição\" é obrigatorio" + "\n";

            return resultadoValidacao;
        }
    }
}
