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
    internal class TelaFuncionario : TelaBase
    {
        RepositorioFuncionario repositorioFuncionario;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            repositorio = repositorioFuncionario;
            this.repositorioFuncionario = repositorioFuncionario;
            modulo = "Funcionarios";
        }


        public override EntidadeBase ObterDados()
        {
            Console.Write("Digite o nome do Funcionario: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF do Funcionario: ");
            string cpf = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, cpf);
            funcionario.nome = nome;
            funcionario.cpf = cpf;

            return funcionario;
        }
    }
}
