﻿namespace BarDaGalera.ConsoleApp.Compartilhado
{
    public static class Utils
    {
        public static void VoltarAoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para voltar ao menu");
            Console.ReadKey();
        }

        public static void TentarNovamente()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para tentar novamente");
            Console.ReadKey();
        }

        public static void MostrarMensagem(string mensagem, ConsoleColor cor, TipoMensagem tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case TipoMensagem.READKEY:

                    Console.WriteLine();
                    Console.ForegroundColor = cor;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();
                    Console.ReadKey();
                    break;

                case TipoMensagem.NOREADKEY:

                    Console.WriteLine();
                    Console.ForegroundColor = cor;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();

                    break;

                case TipoMensagem.ABERTO:

                    Console.WriteLine("Aberto");

                    break;

                case TipoMensagem.FECHADO:

                    Console.WriteLine("Fechado");

                    break;
            }
        }
    }
}
