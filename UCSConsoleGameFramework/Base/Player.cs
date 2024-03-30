using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSConsoleGameFramework.Scenarios;

namespace UCSConsoleGameFramework.Base
{
    internal class Player 
    {
        private static Player instance;

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }

                return instance;
            }
        }

        public string Name;

        public int Life;

        public Backpack Backpack;

        public double Money;

        public int[] LifeInimigo = new int[] { 0, 0, 0, 0 };

        //aqui temos um array que guarda o numero de inimigos e se a batalha acabou ou não 
        public int[] Batalha = new int[] { 0, 0 };

        //posição 0 é para ver se o inimigo vai atacar ou defender
        //posição 1 é para ver se o inimigo se defendeu no turno anterior, logo ele tem uma defesa ativa
        public int[] BatalhaInimigo = new int[] { 0, 0 };

        //aqui 0 para não está se defendendo e 1 para esta se defendendo
        public int EstadoPersonagem;

        
        private Player()
        {
            Backpack = new Backpack();
        }

        public void Reviver()
        {
            Player.Instance.Life = 100;
            Player.Instance.Money = 0;
            Player.Instance.Backpack.Items.Clear();
            Coliseum coliseum = new();
            coliseum.Move(new City());

        }
    }
}
