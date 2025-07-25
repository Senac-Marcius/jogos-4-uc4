using System;
using System.Data;
using System.Threading;

namespace PastaWin
{
    public abstract class MonoBehaviour
    {
        private Thread t;
        private bool ativo = true;

        public bool visible = false;
        public bool input = false;

        public void Run()
        {
            Awake();
            Start();

            t = new Thread(
                () => {
                    while (ativo) {
                        Update();
                        LateUpdate();
                        Thread.Sleep(100);
                    }
                    
                }
            );

            t.Start();
        }

        public void Stop()
        {
            this.ativo = false;
            OnDestroy();
            t.Join();
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void OnDestroy() { }

        public abstract void Draw();

    }
}
