using Gestao_de_Equipamentos.ModuloEquipamento;
using Gestao_de_Equipamentos.ModuloFabricante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.Compartilhado
{
    public class Repositorio
    {
        protected List<Entidade> registros = new List<Entidade>();

        public void InserirRegistro(Entidade registro)
        {
            registro.id = registros.Count + 1;
            registros.Add(registro);
        }

    }



}

