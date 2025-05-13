using Gestao_de_Equipamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.ModuloFabricante
{
    public class RepositorioFabricante : Repositorio
    {
        public List<Fabricante> fabricantesRegistrados = new List<Fabricante>();
        public void InserirFabricante(Fabricante fabricante)
        {
            fabricante.id = fabricantesRegistrados.Count + 1;
            fabricantesRegistrados.Add(fabricante);
        }

        public bool EditarFabricante(int id, Fabricante fabricanteAtualizado)
        {
            Fabricante? fabricante = SelecionarPorId(id);

            if (fabricante == null)
                return false;

            fabricante.nome = fabricanteAtualizado.nome;
            fabricante.email = fabricanteAtualizado.email;
            fabricante.telefone = fabricanteAtualizado.telefone;
            fabricante.equipamentoRelacionado = fabricanteAtualizado.equipamentoRelacionado;
            return true;

        }

        public Fabricante SelecionarPorId(int id)
        {
            return fabricantesRegistrados.FirstOrDefault(e => e.id == id);
        }

        internal List<Fabricante> SelecionarTodos()
        {
            return fabricantesRegistrados;
        }

        internal bool ExcluirFabricante(int id)
        {
            Fabricante? fabricante = SelecionarPorId(id);
            if (fabricante == null)
                return false;
            fabricantesRegistrados.Remove(fabricante);
            return true;
        }
    }
}
