using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloConta;
using BarDaGalera.ConsoleApp.ModuloFaturamento;
using BarDaGalera.ConsoleApp.ModuloGarcom;
using BarDaGalera.ConsoleApp.ModuloMesa;
using BarDaGalera.ConsoleApp.ModuloPedido;
using BarDaGalera.ConsoleApp.ModuloProduto;

namespace BarDaGalera.ConsoleApp.ModuloPrincipal
{
    public class TelaPrincipal
    {

        private readonly TelaGarcom _telaGarcom;
        private readonly TelaMesa _telaMesa;
        private readonly TelaProduto _telaProduto;
        private readonly TelaPedido _telaPedido;
        private readonly TelaConta _telaConta;

        public TelaPrincipal()
        {
            RepositorioGarcom repositorioGarcom = new();
            RepositorioMesa repositorioMesa = new();
            RepositorioProduto repositorioProduto = new();
            RepositorioPedido repositorioPedido = new();
            RepositorioConta repositorioConta = new();

            Faturamento faturamento = new();

            _telaGarcom = new(repositorioGarcom);
            _telaMesa = new(repositorioMesa);
            _telaProduto = new(repositorioProduto);
            _telaPedido = new(repositorioPedido, repositorioProduto, _telaProduto);
            _telaConta = new(repositorioConta, repositorioPedido, _telaMesa, faturamento);
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("------ Controle do Bar ------");
            Console.WriteLine();

            Console.WriteLine("[1] Menu de Garcom");
            Console.WriteLine("[2] Menu de Mesa");
            Console.WriteLine("[3] Menu de Produto");
            Console.WriteLine("[4] Menu de Pedidos");
            Console.WriteLine("[5] Menu de Conta");
            Console.WriteLine();
            Console.WriteLine("[S] Fechar o programa");

            Console.WriteLine();
            Console.Write("Digite uma opcão: ");

            return Console.ReadLine().ToUpper();
        }

        public ITelaCadastravel SelecionarTela()
        {
            string opcao;

            do
            {
                opcao = ApresentarMenu();

                if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "S")
                {
                    Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    Utils.VoltarAoMenu();
                }

            } while (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "S");

            switch (opcao)
            {
                case "1":
                    return _telaGarcom; 

                case "2":
                    return _telaMesa; 

                case "3":
                    return _telaProduto;

                case "4":
                    return _telaPedido;

                case "5":
                    return _telaConta;

                default:
                    return null;
            }
        }
    }
}
