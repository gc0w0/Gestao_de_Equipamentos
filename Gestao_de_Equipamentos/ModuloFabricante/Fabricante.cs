using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.ModuloFabricante
{
    public  class Fabricante : Entidade
    {
        public int id;
        public string nome;
        public string email;
        public string telefone;
        public List<Equipamento> equipamentos;
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

        public override string ToString()
        {
            return $"ID: {id} | Nome: {nome} | Email: {email} | Telefone: {telefone} ";
        }

        public override void MostrarInformacoes()
        {
            Console.WriteLine($"ID: {id} | Nome: {nome} | Email: {email} | Telefone: {telefone} ");
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo \"nome\" é obrigatório" + "\n";

            if (nome.Length < 3)
                resultadoValidacao += "O campo \"nome\" precisa ter no mínimo 3 letras" + "\n";

            if (string.IsNullOrEmpty(email))
                resultadoValidacao += "O campo \"email\" é obrigatorio" + "\n";

            if(string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo \"telefone\" é obrigatorio" + "\n";

            return resultadoValidacao;
        }

       

    }
}
