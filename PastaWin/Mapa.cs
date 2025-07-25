using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaWin
{
    class Mapa : MonoBehaviour
    {
        private static Mapa instancia { get; set; }

        private Mapa() {
            Run();
        }

        public static Mapa Instancia => instancia ??= new Mapa();


        public char[,] mapa;
        public int largura = 20;
        public int altura = 10;


        public void iniciarMapa()
        {
            mapa = new char[largura, altura];

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    //ultima posição do vetor é tamanho - 1
                    if (x == 0 || y == 0 || x == largura - 1 || y == altura - 1)
                    {
                        mapa[x, y] = '#';
                    }
                    else
                    {
                        mapa[x, y] = ' ';
                    }
                }
            }
        }


        public override void Draw()
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write(mapa[x, y]);    
                }
                Console.WriteLine();
            }
        }

        public override void Start()
        {
            iniciarMapa();
        }


    }
}
