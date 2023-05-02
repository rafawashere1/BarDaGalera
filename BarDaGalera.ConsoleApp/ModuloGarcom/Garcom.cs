using BarDaGalera.ConsoleApp.Compartilhado;

namespace BarDaGalera.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcomAtualizado = (Garcom)registroAtualizado;

            Nome = garcomAtualizado.Nome;
            Cpf = garcomAtualizado.Cpf;
        }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrWhiteSpace(Cpf))
                erros.Add("O campo \"cpf\" é obrigatório");

            return erros;
        }
    }
}
