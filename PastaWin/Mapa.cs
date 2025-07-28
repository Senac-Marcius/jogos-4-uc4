using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaWin
{
    public class Mapa : MonoBehaviour
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
            Console.Clear();
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Primeira linha com largura e altura
            sb.AppendLine($"{largura}|{altura}");

            // Conteúdo do mapa
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    sb.Append(mapa[x, y]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static Mapa FromString(string data)
        {
            var linhas = data.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Lê as dimensões da primeira linha
            var dimensoes = linhas[0].Split('|');
            int largura = int.Parse(dimensoes[0]);
            int altura = int.Parse(dimensoes[1]);

            var novoMapa = new Mapa();
            novoMapa.largura = largura;
            novoMapa.altura = altura;
            novoMapa.mapa = new char[largura, altura];

            for (int y = 0; y < altura; y++)
            {
                var linha = linhas[y + 1]; // pula a linha das dimensões
                for (int x = 0; x < largura; x++)
                {
                    novoMapa.mapa[x, y] = linha[x];
                }
            }

            return novoMapa;
        }


    }
}
