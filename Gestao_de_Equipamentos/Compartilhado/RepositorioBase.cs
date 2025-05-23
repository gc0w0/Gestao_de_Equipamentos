

using Gestao_de_Equipamentos.ModuloFabricante;

namespace Gestao_de_Equipamentos.Compartilhado
{
    public class RepositorioBase
    {
        protected List<EntidadeBase> registros = new List<EntidadeBase>();

        public void InserirRegistro(EntidadeBase registro)
        {
            registro.id = registros.Count + 1;
            registros.Add(registro);
        }

        public bool EditarRegistro(int id, EntidadeBase registroAtualizado)
        {
            EntidadeBase? registro = (EntidadeBase)SelecionarPorId(id);

            if (registro == null)
                return false;
            registro.AtualizarInformacoes(registroAtualizado);

            return true;

        }


        public EntidadeBase SelecionarPorId(int id)
        {
            return registros.FirstOrDefault(e => e.id == id);
        }


        public bool ExcluirRegistro(int id)
        {
            EntidadeBase? registro = SelecionarPorId(id);
            if (registro == null)
                return false;
            registros.Remove(registro);
            return true;
        }

        public List<EntidadeBase> SelecionarTodos()
        {
            return registros;
        }

    }



}

