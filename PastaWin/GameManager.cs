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

        public Mapa map;
        public Player pl;
        public Menu nemo;

        public override void Update()
        {
            Draw();
        }

        public override void OnDestroy()
        {
            Console.Clear();
            Console.WriteLine("Obrigado por jogar!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            var tecla = Console.ReadKey(true);
            Environment.Exit(0);
        }

        public override void Start()
        {
            nemo = Menu.Instancia;
            nemo.visible = true;
            nemo.input = true;
        }

        public override void Draw()
        {
            if(map.visible) map.Draw();
            if (pl.visible)  pl.Draw();
            if (nemo.visible)  nemo.Draw();
        }
}
