using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaWin
{
    public class Menu : MonoBehaviour
    {
        private static Menu instancia { get; set; }
        private Menu()
        {
            Run();
        }
        public static Menu Instancia => instancia ??= new Menu();


        public override void Update()
        {
            var tecla = Console.ReadKey(true).Key;

            switch (tecla)
            {
                case ConsoleKey.J:
                    GameManager.Instance.map.visible = true;

                    GameManager.Instance.pl.visible = true;
                    GameManager.Instance.pl.input = true;

                    GameManager.Instance.nemo.visible = false;
                    GameManager.Instance.nemo.input = false;
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("Jogo criado pelo professor Marcius na UC4 de jogos.");
                    break;
                case ConsoleKey.Escape:
                    Stop();
                    break;
            }
        }

        public override void Draw()
        {
            Console.Clear();
            Console.WriteLine("""
                Bem vindo ao Jogo da UC4

                Começar (Tecla J)
                Créditos (Tecla C)
                Sair (Tecla ESC)

            """);
        }
    }
}
