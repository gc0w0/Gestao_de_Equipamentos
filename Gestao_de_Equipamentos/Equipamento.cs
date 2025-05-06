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
        public decimal precoRegistrado;
        public int data_FabricacaoRegistrada;
        public string fabricanteRegistrado;
        public string nomeRegistrado;

        public override string ToString()
        {
            return $"ID de Registro: {registroId} | Nome: {nomeRegistrado} | Preço {precoRegistrado} | Fabricante: {fabricanteRegistrado} | Data de Fabricação: {data_FabricacaoRegistrada}";
        }

        



    }
}
