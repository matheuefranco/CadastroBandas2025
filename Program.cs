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
        static void Main()
        {
            List<Banda> listaBandas = new List<Banda>();
            int opcao = 0;
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
                        Console.WriteLine("Até mais ;)");
                        break;
                }
                Console.ReadKey();// pausa
                Console.Clear(); // limpa a tela
            } while (opcao != 0);

        }

    }

}
