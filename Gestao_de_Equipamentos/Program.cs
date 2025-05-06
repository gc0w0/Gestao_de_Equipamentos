namespace Gestao_de_Equipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controle_De_Equipamento realizarCadastro = new Controle_De_Equipamento();
            bool iniciarCadastro = true;

            while (iniciarCadastro == true)
            {
                realizarCadastro.Iniciar();

            }







        }
    }
}
