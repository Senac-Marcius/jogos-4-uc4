using System;

namespace PastaWin
{
    class JogoSorte
    {
        static char[,] mapa;
        static int largura = 20;
        static int altura = 10;
        static int playerX = 1;
        static int playerY = 1;
        static bool jogando = true;

        static void Main()
        {
            Console.Clear();

            // Aqui vai entrar o menu de vocês
            jogar();
        }

        static void jogar()
        {
            iniciarMapa();



            while (jogando)
            {
                Console.Clear();
                DesenharMapa();

                var tecla = Console.ReadKey(true).Key;

                AtualizarPosicao(tecla);
            }
        }

        static void iniciarMapa()
        {
            mapa = new char[largura, altura];

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    //ultima posição do vetor é tamanho - 1
                    if(x == 0 || y == 0 || x == largura-1 || y == altura - 1)
                    {
                        mapa[x, y] = '#';
                    }
                    else
                    {
                        mapa[x, y] = ' ';
                    }
                }
            }

            mapa[playerX, playerY] = '@';
        }


        static void DesenharMapa()
        {
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write( mapa[x, y] );
                }
                Console.WriteLine();
            }
        }

        static void AtualizarPosicao(ConsoleKey tecla)
        {
            int tempX = playerX;
            int tempY = playerY;

            switch (tecla)
            {
                case ConsoleKey.A:
                    tempX--;
                    break;
                case ConsoleKey.D:
                    tempX++;
                    break;
                case ConsoleKey.W:
                    tempY--;
                    break;
                case ConsoleKey.S:
                    tempY++;
                    break;
            }

            if (mapa[tempX, tempY] != '#')
            {
                mapa[playerX, playerY] = ' ';
                mapa[tempX, tempY] = '@';
                playerX = tempX;
                playerY = tempY;
            }

        }



    }
}
