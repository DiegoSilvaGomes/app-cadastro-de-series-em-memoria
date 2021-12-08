using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluiSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();                 
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seu serviço de listagem de séries!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Lista séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine($"#ID {serie.RetornaId()} - {serie.RetornaTitulo()} {(excluido ? "*Excluído*" : "")}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Digite o gênero entre as opções acima");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de ínicio da série");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            var entradaDescricao = Console.ReadLine();

            var novaSerie = new Serie(  id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série");
            var indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Digite o gênero entre as opções acima");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de ínicio da série");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            var entradaDescricao = Console.ReadLine();

            var atualizaSerie = new Serie(  id: indiceSerie,
                                            genero: (Genero)entradaGenero, 
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluiSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
    }
}
