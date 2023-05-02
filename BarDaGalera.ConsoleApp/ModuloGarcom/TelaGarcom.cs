using BarDaGalera.ConsoleApp.Compartilhado;

namespace BarDaGalera.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase<Garcom>
    {
        public TelaGarcom(RepositorioGarcom repositorioGarcom) : base(repositorioGarcom)
        {
            nomeEntidade = "Garcom";
            sufixo = "s";
        }

        protected override void MostrarTabela(List<Garcom> registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "CPF");

            Console.WriteLine("--------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Garcom garcom in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", garcom.Id, garcom.Nome, garcom.Cpf);
            }
        }

        protected override Garcom ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o número do CPF: ");
            string cpf = Console.ReadLine();

            return new Garcom(nome, cpf);
        }
    }
}
