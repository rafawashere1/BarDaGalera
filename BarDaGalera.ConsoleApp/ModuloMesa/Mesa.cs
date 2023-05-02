using BarDaGalera.ConsoleApp.Compartilhado;

namespace BarDaGalera.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string Bloco { get; set; }

        public Mesa(string bloco)
        {
            Bloco = bloco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            Bloco = mesaAtualizada.Bloco;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrWhiteSpace(Bloco))
                erros.Add("O campo \"bloco\" é obrigatório");

            return erros;
        }
    }
}

