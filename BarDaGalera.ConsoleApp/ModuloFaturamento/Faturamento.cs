namespace BarDaGalera.ConsoleApp.ModuloFaturamento
{
    public class Faturamento
    {
        public decimal TotalFaturado { get; set; }

        public void IncrementarFaturamento(decimal valor)
        {
            TotalFaturado += valor;
        }
    }
}
