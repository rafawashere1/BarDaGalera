using BarDaGalera.ConsoleApp.Compartilhado;

namespace BarDaGalera.ConsoleApp.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        public List<Produto> SelecionarTodosProdutos()
        {
            List<Produto> listaProdutos = SelecionarTodos();

            return listaProdutos;
        }
    }
}
