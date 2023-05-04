using BarDaGalera.ConsoleApp.Compartilhado;

namespace BarDaGalera.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string Letra { get; set; }

        public Mesa(string letra)
        {
            Letra = letra;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            Letra = mesaAtualizada.Letra;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrWhiteSpace(Letra))
                erros.Add("\nO campo \"letra da mesa\" é obrigatório");

            return erros;
        }
    }
}

