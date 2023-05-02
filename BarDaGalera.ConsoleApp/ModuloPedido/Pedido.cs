using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloProduto;

namespace BarDaGalera.ConsoleApp.ModuloPedido
{
    public class Pedido : EntidadeBase
    {

        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal TotalParcial { get; set; }

        public Pedido(Produto produto, int quantidade, decimal totalParcial)
        {
            Produto = produto;
            Quantidade = quantidade;
            TotalParcial = totalParcial;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Pedido pedidoAtualizado = (Pedido)registroAtualizado;

            Produto = pedidoAtualizado.Produto;
            Quantidade = pedidoAtualizado.Quantidade;
            TotalParcial = pedidoAtualizado.TotalParcial;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (Produto == null)
                erros.Add("O campo \"produto\" é obrigatório");

            if (Quantidade < 0)
                erros.Add("O campo \"quantidade\" não pode ser menor que 0");

            return erros;
        }
    }
}
