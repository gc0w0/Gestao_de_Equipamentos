using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ModuloFabricante
{
    public class Fabricante : EntidadeBase
    {
        private RepositorioEquipamento repositorioEquipamento;
        public string nome;
        public string email;
        public string telefone;
        public List<Equipamento> equipamentos = new List<Equipamento>();
        
        public int quantidadeEquipamentos;

        public Fabricante()
        {
            
        }
        public Fabricante(string nome, string email, string telefone)
        {   
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
        }
        
        public override void MostrarInformacoes()
        {
            Console.WriteLine($"ID: {id} | Nome: {nome} | Email: {email} | Telefone: {telefone} | Equipamentos: {equipamentos.Count} ");
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Fabricante fabricanteAtualizado = (Fabricante)registroAtualizado;

            this.nome = fabricanteAtualizado.nome;
            this.email = fabricanteAtualizado.email;
            this.telefone = fabricanteAtualizado.telefone;
            this.equipamentos = fabricanteAtualizado.equipamentos;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";
            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo \"nome\" é obrigatório" + "\n";

            if (nome.Length < 3)
                resultadoValidacao += "O campo \"nome\" precisa ter no mínimo 3 letras" + "\n";

            if (string.IsNullOrEmpty(email))
                resultadoValidacao += "O campo \"email\" é obrigatorio" + "\n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo \"telefone\" é obrigatorio" + "\n";

            return resultadoValidacao;
        }
    }
}
