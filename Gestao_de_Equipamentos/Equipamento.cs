using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_de_Equipamentos
{
    public class Equipamento : Controle_De_Equipamento
    {
        public int registroId;

        public override string ToString()
        {
            return $"ID de Registro: {registroId} | Nome: {nome} | Preço {preco} | Fabricante: {fabricante} | Data de Fabricação: {data_Fabricacao}";
        }

    }
}
