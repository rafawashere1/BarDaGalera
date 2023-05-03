using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloMesa;
using BarDaGalera.ConsoleApp.ModuloPedido;

namespace BarDaGalera.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase<Conta>
    {
        private readonly RepositorioPedido _repositorioPedido;
        private readonly TelaMesa _telaMesa;
        private readonly Faturamento _faturamento;

        public TelaConta(RepositorioConta repositorioConta, RepositorioPedido repositorioPedido, TelaMesa telaMesa, Faturamento faturamento) : base(repositorioConta)
        {
            _repositorioPedido = repositorioPedido;
            _telaMesa = telaMesa;
            _faturamento = faturamento;
            nomeEntidade = "Conta";
            sufixo = "s";
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"[1] Adicionar {nomeEntidade}");
            Console.WriteLine($"[2] Fechar {nomeEntidade}{sufixo}");
            Console.WriteLine($"[3] Visualizar {nomeEntidade}{sufixo}");

            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            return Console.ReadLine().ToUpper();
        }

        public void FecharConta()
        {
            VisualizarRegistros(true);

            Conta conta = EncontrarRegistro("Digite o ID da conta que deseja fechar: ");

            List<Pedido> pedidos = _repositorioPedido.SelecionarTodos();

            decimal totalParcial = 0;

            foreach (Pedido pedido in pedidos)
            {
                totalParcial += pedido.TotalParcial;
            }

            conta.ValorFinal = totalParcial;

            _faturamento.IncrementarFaturamento(conta.ValorFinal);

            conta.EmAberto = false;
        }

        protected override void MostrarTabela(List<Conta> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}", "Id", "Quantidade de Pedidos", "Id da mesa", "Data", "Status");

            Console.WriteLine("--------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Conta conta in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}", conta.Id, conta.Pedidos.Count, conta.Mesa.Id, conta.Data, conta.EmAberto ? "Aberto" : "Fechado");
            }
        }

        protected override Conta ObterRegistro()
        {
            List<Pedido> pedidos = _repositorioPedido.SelecionarTodos();

            Mesa mesa = ObterMesa();

            DateTime data = DateTime.Now.Date;

            bool emAberto = true;

            return new Conta(pedidos, mesa, data, emAberto);
        }

        private Mesa ObterMesa()
        {
            _telaMesa.VisualizarRegistros(true);

            Mesa mesa = _telaMesa.EncontrarRegistro("Digite o id da mesa: ");

            Console.WriteLine();

            return mesa;
        }
    }
}
