using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloProduto;

namespace BarDaGalera.ConsoleApp.ModuloPedido
{
    public class TelaPedido : TelaBase<Pedido>
    {
        private readonly TelaProduto _telaProduto;
        private readonly RepositorioProduto _repositorioProduto;

        public TelaPedido(RepositorioBase<Pedido> repositorioPedido, RepositorioProduto repositorioProduto, TelaProduto telaProduto) : base(repositorioPedido)
        {
            _repositorioProduto = repositorioProduto;
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
            Produto produto = ObterProduto();

            if (produto == null)
                return null;

            int quantidade = 0;
            bool quantidadeInvalida;

            do
            {
                quantidadeInvalida = false;

                Console.WriteLine("Quantos produtos deseja adicionar?");

                try
                {
                    quantidade = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Utils.MostrarMensagem("Formato da quantidade está inválido", ConsoleColor.Red, TipoMensagem.READKEY);
                    quantidadeInvalida = true;
                }
                catch (OverflowException)
                {
                    Utils.MostrarMensagem("A Quantidade informada excedeu o limite permitido.", ConsoleColor.Red, TipoMensagem.READKEY);
                    quantidadeInvalida = true;
                }

            } while (quantidadeInvalida);

            decimal totalParcial = produto.Preco * quantidade;

            return new Pedido(produto, quantidade, totalParcial);
        }

        private Produto ObterProduto()
        {
            List<Produto> produtos = _repositorioProduto.SelecionarTodosProdutos();
            if (!_repositorioProduto.TemRegistro(produtos))
            {
                Utils.MostrarMensagem("É necessário ter um produto cadastrado.", ConsoleColor.Red, TipoMensagem.READKEY);
                return null;
            }

            _telaProduto.VisualizarRegistros(false);

            Produto produto = _telaProduto.EncontrarRegistro("Digite o id do registro: ");

            Console.WriteLine();

            return produto;
        }
    }
}
