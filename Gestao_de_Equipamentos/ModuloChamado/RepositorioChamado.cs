using Gestao_de_Equipamentos.Compartilhado;

namespace Gestao_de_Equipamentos.ModuloChamado
{
    public class RepositorioChamado : Repositorio
    {              
        public List<Chamado> chamadosRegistrados = new List<Chamado>();       

        public void InserirChamado(Chamado chamado)
        {
            chamado.id = chamadosRegistrados.Count + 1;
            chamadosRegistrados.Add(chamado);
        }

    }
}
