namespace BarDaGalera.ConsoleApp.Compartilhado
{
    public interface ITelaCadastravel
    {
        public string ApresentarMenu();

        public void InserirNovoRegistro();

        public void EditarRegistro();

        public void ExcluirRegistro();

        public void VisualizarRegistros(bool mostrarCabecalho);
    }
}
