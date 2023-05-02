namespace BarDaGalera.ConsoleApp
{
    public static class TelaPrincipal
    {
        public static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("------ Controle do Bar ------");
            Console.WriteLine();

            Console.WriteLine("[1] Menu de Garcom");
            Console.WriteLine("[2] Menu de Mesa");
            Console.WriteLine("[3] Menu de Produto");
            Console.WriteLine("[4] Menu de Pedidos");
            Console.WriteLine("[5] Menu de Conta");
            Console.WriteLine("[6] Visualizar relatório diário");
            Console.WriteLine();
            Console.WriteLine("[S] Fechar o programa");

            Console.WriteLine();
            Console.Write("Digite uma opcão: ");

            return Console.ReadLine().ToUpper();
        }
    }
}
