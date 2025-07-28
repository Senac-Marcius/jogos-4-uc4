using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PastaWin
{
    public static class SaveGame
    {
        private const string Caminho = "savegame.json";

        public static void Save<T>(T dados)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(dados, options);
            File.WriteAllText(Caminho, json);

            Console.WriteLine("[SaveGame] Arquivo salvo.\nPrecione qualquer tecla.");
            Console.ReadKey(true);
        }

        public static T Load<T>() where T : new()
        {
            if (!File.Exists(Caminho))
            {
                Console.WriteLine("[SaveGame] Save não encontrado. Retornando objeto padrão.\nPrecione qualquer tecla.");
                Console.ReadKey(true);
                return new T();
            }

            string json = File.ReadAllText(Caminho);
            T dados = JsonSerializer.Deserialize<T>(json);
            Console.WriteLine("[SaveGame] Arquivo carregado.\nPrecione qualquer tecla.");
            Console.ReadKey(true);
            return dados;
        }
    }
}
