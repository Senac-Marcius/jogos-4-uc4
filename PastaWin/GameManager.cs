using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaWin
{
    class GameManager : MonoBehaviour
    {
        private static GameManager instancia;

        private GameManager() { 
            Run();
        }

        public static GameManager Instance => instancia ??= new GameManager();

        public bool jogando = false;

        public override void Update()
        {
            if (!jogando)
            {
                menu();
            }
        }

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("""
                        Bem vindo ao Jogo da UC4

                        Começar (Tecla J)
                        Créditos (Tecla C)
                        Sair (Tecla ESC)

                    """);

            var tecla = Console.ReadKey(true).Key;

            switch (tecla)
            {
                case ConsoleKey.J:
                    jogar();
                    jogando = true;
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("Jogo criado pelo professor Marcius na UC4 de jogos.");
                    break;
                case ConsoleKey.Escape:
                    Stop();
                    break;
            }

        }

        public override void OnDestroy()
        {
            Console.Clear();
            Console.WriteLine("Obrigado por jogar!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            var tecla = Console.ReadKey(true);
            Environment.Exit(0);
        }

        public void jogar()
        {
            Console.Clear();

            Mapa.Instancia.largura = 40;
            Mapa.Instancia.altura = 20;

            Mapa.Instancia.iniciarMapa();
            
            Player p1 = new Player();
        }
    }
}
