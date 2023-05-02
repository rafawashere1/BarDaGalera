using BarDaGalera.ConsoleApp.Compartilhado;
using BarDaGalera.ConsoleApp.ModuloMesa;
using BarDaGalera.ConsoleApp.ModuloPedido;

namespace BarDaGalera.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public List<Pedido> Pedidos { get; set; }
        public decimal ValorFinal { get; set; }
        public Mesa Mesa { get; set; }
        public DateTime Data { get; set; }
        public bool EmAberto { get; set; }

        public Conta(List<Pedido> pedidos, Mesa mesa, DateTime data, bool emAberto)
        {
            Pedidos = pedidos;
            Mesa = mesa;
            Data = data;
            EmAberto = emAberto;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizado = (Conta)registroAtualizado;

            Mesa = contaAtualizado.Mesa;
            EmAberto = contaAtualizado.EmAberto;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (Mesa == null)
                erros.Add("O campo \"mesa\" é obrigatório");

            if (Data < DateTime.Now.Date)
                erros.Add("O campo \"data\" deve ser maior que a data atual");

            return erros;
        }
    }
}
