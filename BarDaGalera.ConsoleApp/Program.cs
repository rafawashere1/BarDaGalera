using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloConta;
using BarDaGalera.ConsoleApp.ModuloPrincipal;

namespace BarDaGalera.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new();

            while (true)
            {
                ITelaCadastravel tela = telaPrincipal.SelecionarTela();

                if (tela == null)
                    break;

                switch (tela)
                {
                    case TelaConta telaConta:
                        CadastrarContas(telaConta);
                        break;
                    default:
                        ExecutarCadastros(tela);
                        break;
                }
            }
        }

        private static void ExecutarCadastros(ITelaCadastravel tela)
        {
            string subMenu;

            do
            {
                subMenu = tela.ApresentarMenu();

                if (subMenu != "1" && subMenu != "2" && subMenu != "3" && subMenu != "4" && subMenu != "S")
                {
                    Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    Utils.VoltarAoMenu();
                }

            } while (subMenu != "1" && subMenu != "2" && subMenu != "3" && subMenu != "4" && subMenu != "S");

            if (subMenu == "1")
            {
                tela.InserirNovoRegistro();
            }
            else if (subMenu == "2")
            {
                tela.EditarRegistro();
            }
            else if (subMenu == "3")
            {
                tela.ExcluirRegistro();
            }
            else if (subMenu == "4")
            {
                tela.VisualizarRegistros(true);
                Utils.VoltarAoMenu();
            }
        }

        private static void CadastrarContas(TelaConta telaConta)
        {
            string subMenu;

            do
            {
                subMenu = telaConta.ApresentarMenu();

                if (subMenu != "1" && subMenu != "2" && subMenu != "3" && subMenu != "4" && subMenu != "S")
                {
                    Utils.MostrarMensagem("Opção inválida!", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    Utils.VoltarAoMenu();
                }

            } while (subMenu != "1" && subMenu != "2" && subMenu != "3" && subMenu != "4" && subMenu != "S");

            if (subMenu == "1")
            {
                telaConta.InserirNovoRegistro();
            }
            else if (subMenu == "0")
            {
                telaConta.EditarRegistro();
            }
            else if (subMenu == "2")
            {
                telaConta.FecharConta();
            }
            else if (subMenu == "3")
            {
                telaConta.VisualizarRegistros(true);
                Utils.VoltarAoMenu();
            }
            else if (subMenu == "4")
            {
                telaConta.VisualizarFaturamentoDoDia();
                Utils.VoltarAoMenu();
            }
        }
    }
}