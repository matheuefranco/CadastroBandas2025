using System;
namespace CadastroBandas
{
    class Program
    {
        static void addBanda(List<Banda> listaBandas)
        {
            Banda novaBanda = new Banda();
            Console.Write("Nome:");
            novaBanda.nome = Console.ReadLine();
            Console.Write("Genero:");
            novaBanda.genero = Console.ReadLine();
            Console.Write("Integrantes:");
            novaBanda.integrantes = int.Parse(Console.ReadLine());
            Console.Write("Ranking:");
            novaBanda.ranking = int.Parse(Console.ReadLine());
            listaBandas.Add(novaBanda);
            Console.WriteLine("--------");

        }

        static void mostrarBandas(List<Banda> listaBandas)
        {
            int posicao = 1;
            foreach (Banda b in listaBandas)
            {
                Console.WriteLine($"*** Banda {posicao}***");
                Console.WriteLine($"{b.nome} - {b.genero} - {b.integrantes} - {b.ranking}");
                posicao++;
            }

        }
        static int menu()
        {
            int opcao;
            Console.WriteLine("*** Sistema de Cadastro de Bandas 4U***");
            Console.WriteLine("1- Adicionar Banda");
            Console.WriteLine("2- Mostrar Bandas");
            Console.WriteLine("0- Sair do Sistema");
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        static void salvarDados(List<Banda> listaBandas, string nomeArquivo)
        {

            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (Banda b in listaBandas)
                {
                    writer.WriteLine($"{b.nome},{b.genero},{b.integrantes},{b.ranking}");
                }
            }
            Console.WriteLine("Dados salvos com sucesso!");


        }

        static void carregarDados(List<Banda> listaBandas, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');
                    Banda novaBanda = new Banda();
                    novaBanda.nome = campos[0];
                    novaBanda.genero = campos[1];
                    novaBanda.integrantes = int.Parse(campos[2]);
                    novaBanda.ranking = int.Parse(campos[3]);
                    listaBandas.Add(novaBanda);
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
                Console.WriteLine("Arquivo não encontrado :(");

        }

        
        static void Main()
        {
            List<Banda> listaBandas = new List<Banda>();
            int opcao = 0;
            carregarDados(listaBandas, "bandas.txt");
            do
            {
                opcao = menu();
                switch (opcao)
                {
                    case 1:
                        addBanda(listaBandas);
                        break;
                    case 2:
                        mostrarBandas(listaBandas);
                        break;
                    case 0:
                        salvarDados(listaBandas, "bandas.txt");
                        Console.WriteLine("Até mais ;)");
                        break;
                }
                Console.ReadKey();// pausa
                Console.Clear(); // limpa a tela
            } while (opcao != 0);

        }

    }

}
