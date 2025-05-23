using Gestao_de_Equipamentos.Compartilhado;
using Gestao_de_Equipamentos.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.ModuloSetor
{
    public class Setor : EntidadeBase
    {
        public string nome;

        public Setor(string nome) 
        {
            this.nome = nome;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Setor setorAtualizado = (Setor)registroAtualizado;
            this.nome = setorAtualizado.nome;
        }

        public override void MostrarInformacoes()
        {
            Console.WriteLine($" ID :{id} Nome: {nome}");
        }

        public override string ValidarInformacoes()
        {
            return "";
        }
    }
}
