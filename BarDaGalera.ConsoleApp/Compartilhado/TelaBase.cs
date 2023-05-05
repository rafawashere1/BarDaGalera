namespace BarDaGalera.ConsoleApp.Compartilhado
{
    public abstract class TelaBase<T> : ITelaCadastravel where T : EntidadeBase
    {
        public string nomeEntidade;
        public string sufixo;

        protected RepositorioBase<T> repositorioBase;

        public TelaBase(RepositorioBase<T> repositorio)
        {
            this.repositorioBase = repositorio;
        }

        public virtual string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"[1] Inserir {nomeEntidade}");
            Console.WriteLine($"[2] para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"[3] para Excluir {nomeEntidade}{sufixo}");
            Console.WriteLine($"[4] para Visualizar {nomeEntidade}{sufixo}");

            Console.WriteLine();
            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            return Console.ReadLine().ToUpper();
        }

        public virtual void VisualizarRegistros(bool mostrarCabecalho)
        {

            if (mostrarCabecalho)
            {
                Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
                Console.WriteLine();
                Console.WriteLine("Visualizando registros já cadastrados...");
                Console.WriteLine();
            }

            List<T> registros = repositorioBase.SelecionarTodos();

            if (!repositorioBase.TemRegistro(registros))
            {
                Utils.MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow, TipoMensagem.NOREADKEY);
                return;
            }

            MostrarTabela(registros);
        }

        public virtual void InserirNovoRegistro()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de {nomeEntidade}s");

            T registro = ObterRegistro();

            if (registro == null)
                return;

            if (TemErrosDeValidacao(registro))
            {
                InserirNovoRegistro();

                return;
            }

            repositorioBase.Inserir(registro);

            Utils.MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green, TipoMensagem.NOREADKEY);
            Utils.VoltarAoMenu();
        }

        public virtual void EditarRegistro()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
            Console.WriteLine();
            Console.WriteLine("Editando um registro já cadastrado...");
            Console.WriteLine();

            if (!repositorioBase.TemRegistro())
            {
                Utils.MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow, TipoMensagem.NOREADKEY);
                Utils.VoltarAoMenu();
                return;
            }

            VisualizarRegistros(false);

            Console.WriteLine();

            T registro = EncontrarRegistro("Digite o id do registro: ");

            T registroAtualizado = ObterRegistro();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(registro, registroAtualizado);

            Utils.MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green, TipoMensagem.NOREADKEY);
            Utils.VoltarAoMenu();
        }

        public virtual void ExcluirRegistro()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}s");
            Console.WriteLine();
            Console.WriteLine("Excluindo um registro já cadastrado...");
            Console.WriteLine();

            if (!repositorioBase.TemRegistro())
            {
                Utils.MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow, TipoMensagem.NOREADKEY);
                Utils.VoltarAoMenu();
                return;
            }

            VisualizarRegistros(false);

            Console.WriteLine();

            T registro = EncontrarRegistro("Digite o id do registro: ");

            repositorioBase.Excluir(registro);

            Utils.MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green, TipoMensagem.NOREADKEY);
            Utils.VoltarAoMenu();
        }

        public virtual T EncontrarRegistro(string mensagem)
        {
            bool idInvalido;
            T registroSelecionado = null;

            do
            {
                idInvalido = false;

                Console.Write("\n" + mensagem);

                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());

                    registroSelecionado = repositorioBase.SelecionarPorId(id);

                    if (registroSelecionado == null)
                    {
                        Utils.MostrarMensagem("Id inválido, tente novamente", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                        idInvalido = true;
                    }
                        
                }
                catch (FormatException)
                {
                    Utils.MostrarMensagem($"O formato informado não é válido.", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    idInvalido = true;
                }
                catch (OverflowException)
                {
                    Utils.MostrarMensagem("O valor informado excedeu o limite permitido.", ConsoleColor.Red, TipoMensagem.NOREADKEY);
                    idInvalido = true;
                }                  

            } while (idInvalido);

            return registroSelecionado;
        }

    protected bool TemErrosDeValidacao(T registro)
        {
            bool temErros = false;

            List<string> erros = registro.Validar();

            if (erros.Count > 0)
            {
                temErros = true;

                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)
                {
                    Console.WriteLine(erro);
                }

                Console.ResetColor();
                Utils.TentarNovamente();
            }

            return temErros;
        }

        protected abstract T ObterRegistro();

        protected abstract void MostrarTabela(List<T> registros);
    }
}

