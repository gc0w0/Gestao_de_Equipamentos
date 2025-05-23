using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using Gestao_de_Equipamentos.ModuloFabricante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {

        public string nome;
        public string cpf;

        public Funcionario(string nome, string cpf)
        {
            this.nome = nome;
            this.cpf = cpf;

        }
        public override void MostrarInformacoes()
        {
            Console.WriteLine($"ID: {id} | Nome: {nome} | CPF: {cpf}");
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

            this.nome = funcionarioAtualizado.nome;
            this.cpf = funcionarioAtualizado.cpf;

        }

        public override string ValidarInformacoes()
        {
            string resultadoValidacao = "";
            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo \"nome\" é obrigatório" + "\n";

            if (nome.Length < 3)
                resultadoValidacao += "O campo \"nome\" precisa ter no mínimo 3 letras" + "\n";

            if (string.IsNullOrEmpty(cpf))
                resultadoValidacao += "O campo \"cpf\" é obrigatorio" + "\n";

            return resultadoValidacao;
        }
    }
}
