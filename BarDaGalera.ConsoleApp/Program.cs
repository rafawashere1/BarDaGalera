using BarDaGalera.ConsoleApp.ModuloGarcom;
using BarDaGalera.ConsoleApp.ModuloMesa;
using BarDaGalera.ConsoleApp.ModuloProduto;
using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloPedido;
using BarDaGalera.ConsoleApp.ModuloConta;

namespace BarDaGalera.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioGarcom repositorioGarcom = new();
            RepositorioMesa repositorioMesa = new();
            RepositorioProduto repositorioProduto = new();
            RepositorioPedido repositorioPedido = new();
            RepositorioConta repositorioConta = new();

            Faturamento faturamento = new();

            TelaGarcom telaGarcom = new(repositorioGarcom);
            TelaMesa telaMesa = new(repositorioMesa);
            TelaProduto telaProduto = new(repositorioProduto);
            TelaPedido telaPedido = new(repositorioPedido, telaProduto);
            TelaConta telaConta = new(repositorioConta, repositorioPedido, telaMesa, faturamento);

            while (true)
            {
                string opcao = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && opcao != "S")
                {
                    Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    Utils.VoltarAoMenu();
                }

                switch (opcao)
                {
                    case "1":

                        string opcaoGarcom = telaGarcom.ApresentarMenu();

                        if (opcaoGarcom != "1" && opcaoGarcom != "2" && opcaoGarcom != "3" && opcaoGarcom != "4" && opcaoGarcom != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoGarcom == "1")
                            telaGarcom.InserirNovoRegistro();

                        else if (opcaoGarcom == "2")
                            telaGarcom.EditarRegistro();

                        else if (opcaoGarcom == "3")
                            telaGarcom.ExcluirRegistro();

                        else if (opcaoGarcom == "4")
                        {
                            Console.Clear();

                            telaGarcom.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoGarcom == "S")
                            continue;
                        break;

                    case "2":

                        string opcaoMesa = telaMesa.ApresentarMenu();

                        if (opcaoMesa != "1" && opcaoMesa != "2" && opcaoMesa != "3" && opcaoMesa != "4" && opcaoMesa != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoMesa == "1")
                            telaMesa.InserirNovoRegistro();

                        else if (opcaoMesa == "2")
                            telaMesa.EditarRegistro();

                        else if (opcaoMesa == "3")
                            telaMesa.ExcluirRegistro();

                        else if (opcaoMesa == "4")
                        {
                            Console.Clear();

                            telaMesa.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoMesa == "S")
                            continue;

                        break;

                    case "3":

                        string opcaoProduto = telaProduto.ApresentarMenu();

                        if (opcaoProduto != "1" && opcaoProduto != "2" && opcaoProduto != "3" && opcaoProduto != "4" && opcaoProduto != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoProduto == "1")
                            telaProduto.InserirNovoRegistro();

                        else if (opcaoProduto == "2")
                            telaProduto.EditarRegistro();

                        else if (opcaoProduto == "3")
                            telaProduto.ExcluirRegistro();

                        else if (opcaoProduto == "4")
                        {
                            Console.Clear();

                            telaProduto.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoProduto == "S")
                            continue;

                        break;

                    case "4":

                        string opcaoPedido = telaPedido.ApresentarMenu();

                        if (opcaoPedido != "1" && opcaoPedido != "2" && opcaoPedido != "3" && opcaoPedido != "4" && opcaoPedido != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoPedido == "1")
                            telaPedido.InserirNovoRegistro();

                        else if (opcaoPedido == "2")
                            telaPedido.EditarRegistro();

                        else if (opcaoPedido == "3")
                            telaPedido.ExcluirRegistro();

                        else if (opcaoPedido == "4")
                        {
                            Console.Clear();

                            telaPedido.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoPedido == "S")
                            continue;

                        break;

                    case "5":

                        string opcaoConta = telaConta.ApresentarMenu();

                        if (opcaoConta != "1" && opcaoConta != "2" && opcaoConta != "3" && opcaoConta != "S")
                        {
                            Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                            Utils.VoltarAoMenu();
                        }

                        if (opcaoConta == "1")
                            telaConta.InserirNovoRegistro();

                        else if (opcaoConta == "2")
                            telaConta.FecharConta();

                        else if (opcaoConta == "3")
                        {
                            Console.Clear();

                            telaConta.VisualizarRegistros(true);

                            Utils.VoltarAoMenu();
                        }

                        else if (opcaoConta == "S")
                            continue;

                        break;

                    case "6": faturamento.VisualizarTotalDiario();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}