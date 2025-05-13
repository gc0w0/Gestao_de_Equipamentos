using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos.Compartilhado
{
    public class Entidade 
    {
        public int id;

        public virtual void MostrarInformacoes()
        {
            Console.WriteLine( "Id: " + id );
        }
            
    }
}
