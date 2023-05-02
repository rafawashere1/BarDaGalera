namespace BarDaGalera.ConsoleApp.Compartilhado
{
    public class Faturamento
    {
        public decimal TotalFaturado { get; set; }

        public void IncrementarFaturamento(decimal valor)
        {
            TotalFaturado += valor;
        }

        public void VisualizarTotalDiario()
        {
            Console.WriteLine($"O total faturado foi: R$ {TotalFaturado}");
        }
    }
}
