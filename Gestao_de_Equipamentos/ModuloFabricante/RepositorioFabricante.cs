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

        public bool EditarFabricante(int id, Fabricante fabricanteAtualizado)
        {
            Fabricante? fabricante = SelecionarPorId(id);

            if (fabricante == null)
                return false;

            fabricante.nome = fabricanteAtualizado.nome;
            fabricante.email = fabricanteAtualizado.email;
            fabricante.telefone = fabricanteAtualizado.telefone;
            fabricante.equipamentos = fabricanteAtualizado.equipamentos;
            return true;

        }

        public Fabricante SelecionarPorId(int id)
        {
            return (Fabricante)registros.FirstOrDefault(e => e.id == id);
        }

        internal List<Entidade> SelecionarTodos()
        {
            return registros;
        }


    }
}
