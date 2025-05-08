namespace Gestao_de_Equipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controle_De_Equipamento realizarCadastro = new Controle_De_Equipamento();

            Controle_De_Chamado controleChamado = new Controle_De_Chamado(realizarCadastro.equipamentosRegistrados);
            bool iniciar = true;

            while (iniciar == true)
            {
                realizarCadastro.Iniciar(controleChamado);

                

                Console.WriteLine("\nDeseja realizar outra operação? (s/n)");
                string resposta = Console.ReadLine().ToLower();
                if (resposta != "s")
                    iniciar = false;
            }

        }
    }
}
