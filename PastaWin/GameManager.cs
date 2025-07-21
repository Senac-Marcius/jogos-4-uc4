using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaWin
{
    class GameManager
    {
        private static GameManager instancia;

        private GameManager() { }

        public static GameManager Instance => instancia ??= new GameManager();

        public bool jogando;

        public void Start()
        {
            Console.Clear();

            menu();
        }

        public void menu()
        {
            var tecla = ConsoleKey.A;

            do
            {
                Console.Clear();
                Console.WriteLine("""
                    Bem vindo ao Jogo da UC4

                    Começar (Tecla J)
                    Créditos (Tecla C)
                    Sair (Tecla ESC)

                """);

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.J:
                        jogando = true;
                        jogar();
                        break;
                    case ConsoleKey.C:
                        Console.WriteLine("Jogo criado pelo professor Marcius na UC4 de jogos.");
                        break;
                }

            } while (tecla != ConsoleKey.Escape);
        }

        public void jogar()
        {
            Mapa.Instancia.largura = 40;
            Mapa.Instancia.altura = 20;

            Mapa.Instancia.iniciarMapa();
            
            Player p1 = new Player();

            while (jogando)
            {
                Console.SetCursorPosition(0, 0);
                Mapa.Instancia.DesenharMapa();
                p1.DesenhaPlayer();

                var tecla = Console.ReadKey(true).Key;

                p1.AtualizarPosicao(tecla);
            }
        }
    }
}
