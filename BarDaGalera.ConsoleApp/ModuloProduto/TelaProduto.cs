using BarDaGalera.ConsoleApp.Compartilhado;

namespace BarDaGalera.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase<Produto>
    {
        public TelaProduto(RepositorioProduto repositorioProduto) : base(repositorioProduto)
        {
            nomeEntidade = "Produto";
            sufixo = "s";
        }
        protected override void MostrarTabela(List<Produto> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Preco");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Produto produto in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}",
                    produto.Id, produto.Nome, produto.Preco);
            }
        }

        protected override Produto ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preco: ");

            bool precoInvalido;
            decimal preco = 0;

            do
            {
                
                precoInvalido = false;

                try
                {
                    preco = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException)
                {
                    precoInvalido = true;
                    Utils.MostrarMensagem("Formato do preço está inválido.", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                }
                catch (ArgumentNullException)
                {
                    precoInvalido = true;
                    Utils.MostrarMensagem("Informe um preço", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                }

            } while (precoInvalido);

            return new Produto(nome, preco);
        }
    }
}
