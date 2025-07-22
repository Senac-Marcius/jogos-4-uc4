using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaWin
{
    public class Vector2
    {
        public int x; //atributos
        public int y;

        public Vector2(int x, int y) //construtor
        {
            this.x = x;
            this.y = y;
        }

        //métodos
        public int Up => this.y -= 1;
        public int Down => this.y += 1;
        public int Left => this.x -= 1;
        public int Right => this.x += 1;

        public static int Distance(Vector2 a, Vector2 b)
        {
            if (a == null) return -1;
            if (b == null) return -1;

            return (
                (int) Math.Sqrt(
                    (a.x - b.x) * (a.x - b.x) +
                    (a.y - b.y) * (a.y - b.y)
                )
            );
        }

    }
}
