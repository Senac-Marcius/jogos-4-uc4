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
        private JogoSalvo jogo;
        private Menu()
        {
            Run();
        }
        public static Menu Instancia => instancia ??= new Menu();


        public override void Update()
        {
            if (!input) return;

            var tecla = Console.ReadKey(true).Key;

            switch (tecla)
            {
                case ConsoleKey.N:
                    GameManager.Instance.map = Mapa.Instancia;
                    GameManager.Instance.map.visible = true;

                    GameManager.Instance.pl = new Player();
                    GameManager.Instance.pl.visible = true;
                    GameManager.Instance.pl.input = true;

                    GameManager.Instance.nemo.visible = false;
                    GameManager.Instance.nemo.input = false;
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("Jogo criado pelo professor Marcius na UC4 de jogos.");
                    break;
                case ConsoleKey.S:
                    jogo = new JogoSalvo
                    {
                        Jogador = GameManager.Instance.pl,
                        MapaAtual = GameManager.Instance.map
                    };
                    SaveGame.Save(jogo);
                    break;
                case ConsoleKey.L:
                    jogo = SaveGame.Load<JogoSalvo>();
                    GameManager.Instance.map = jogo.MapaAtual;
                    GameManager.Instance.map.visible = true;

                    GameManager.Instance.pl = jogo.Jogador;
                    GameManager.Instance.pl.visible = true;
                    GameManager.Instance.pl.input = true;

                    GameManager.Instance.nemo.visible = false;
                    GameManager.Instance.nemo.input = false;
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

                Novo (Tecla N)
                Continuar (Tecla L)
                Salvar (Tecla S)
                Créditos (Tecla C)
                Sair (Tecla ESC)

            """);
        }
    }
}
