using BarDaGalera.ConsoleApp.Compartilhado;

namespace BarDaGalera.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase<Mesa>
    {
        public TelaMesa(RepositorioMesa repositorioMesa) : base(repositorioMesa)
        {
            nomeEntidade = "Mesa";
            sufixo = "s";
        }
        protected override void MostrarTabela(List<Mesa> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20}", "Id", "Letra da mesa");

            Console.WriteLine("--------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Mesa mesa in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20}", mesa.Id, mesa.Letra);
            }
        }

        protected override Mesa ObterRegistro()
        {
            Console.Write("\nDigite a letra da mesa: ");
            string letraMesa = Console.ReadLine();

            return new Mesa(letraMesa);
        }
    }
}
