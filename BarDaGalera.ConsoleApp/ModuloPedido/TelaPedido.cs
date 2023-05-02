using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloProduto;

namespace BarDaGalera.ConsoleApp.ModuloPedido
{
    public class TelaPedido : TelaBase<Pedido>
    {
        private readonly TelaProduto _telaProduto;

        public TelaPedido(RepositorioBase<Pedido> repositorioPedido, TelaProduto telaProduto) : base(repositorioPedido)
        {
            _telaProduto = telaProduto;
            nomeEntidade = "Pedido";
            sufixo = "s";
        }

        protected override void MostrarTabela(List<Pedido> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20}", "Id", "Produto", "Quantidade", "TotalParcial");

            Console.WriteLine("--------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Pedido pedido in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20}", pedido.Id, pedido.Produto.Nome, pedido.Quantidade, pedido.TotalParcial);
            }
        }

        protected override Pedido ObterRegistro()
        {
            VisualizarRegistros(false);

            Produto produto = ObterProduto();

            Console.WriteLine("Quantos produtos deseja adicionar?");

            int quantidade = 0;
            bool quantidadeInvalida;

            do
            {
                quantidadeInvalida = false;

                try
                {
                    quantidade = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    quantidadeInvalida = true;
                    Utils.MostrarMensagem("Formato da quantidade está inválido", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                }
                catch (ArgumentNullException)
                {
                    quantidadeInvalida = true;
                    Utils.MostrarMensagem("Informe uma quantidade.", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                }

            } while (quantidadeInvalida);

            decimal totalParcial = produto.Preco * quantidade;

            return new Pedido(produto, quantidade, totalParcial);
        }

        private Produto ObterProduto()
        {
            _telaProduto.VisualizarRegistros(true);

            Produto produto = _telaProduto.EncontrarRegistro("Digite o id do registro: ");

            Console.WriteLine();

            return produto;
        }
    }
}
