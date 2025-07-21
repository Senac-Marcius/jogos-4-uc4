using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaWin
{
    class Player
    {
        Vector2 pos = new Vector2(1, 1);

        public Player() { }

        public void AtualizarPosicao(ConsoleKey tecla)
        {
            int oldX = pos.x;
            int oldY = pos.y;
            int x = pos.x;
            int y = pos.y;

            switch (tecla)
            {
                case ConsoleKey.A:
                    x = pos.Left;
                    break;
                case ConsoleKey.D:
                    x = pos.Right;
                    break;
                case ConsoleKey.W:
                    y = pos.Up;
                    break;
                case ConsoleKey.S:
                    y = pos.Down;
                    break;
            }

            if (Mapa.Instancia.mapa[x, y] == '#')
            {
                pos.x = oldX;
                pos.y = oldY;
            }

        }


        public void DesenhaPlayer()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write('@');
        }

    }
}
