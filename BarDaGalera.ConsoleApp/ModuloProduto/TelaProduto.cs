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
            Console.Write("\nDigite o nome: ");
            string nome = Console.ReadLine();

            bool precoInvalido;
            decimal preco = 0;

            do
            {
                precoInvalido = false;

                Console.Write("\nDigite o preco: ");

                try
                {
                    preco = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException)
                {                   
                    Utils.MostrarMensagem("Formato do preço está inválido.", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    precoInvalido = true;
                }
                catch (OverflowException)
                {
                    Utils.MostrarMensagem("O preço informado excedeu o limite permitido.", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    precoInvalido = true;
                }

            } while (precoInvalido);

            return new Produto(nome, preco);
        }
    }
}
