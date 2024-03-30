using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSConsoleGameFramework.Base;

namespace UCSConsoleGameFramework.Scenarios
{
    internal class Coliseum : Scene
    {
        public Coliseum()
        {

            if (Player.Instance.Batalha[1] == 0)
            {
                Random random = new Random();
                int numeroDeInimigos = 0;

                numeroDeInimigos = random.Next(1, 5);
                if (numeroDeInimigos == 0) numeroDeInimigos = 1;
                Player.Instance.Batalha[0] = numeroDeInimigos;
                Player.Instance.Batalha[1] = 1;
                for (int i = (numeroDeInimigos-1); i> 0; i--)
                {
                    Player.Instance.LifeInimigo[i] = 100;
        
                }
            }
            
        
            

            Add(@$"  Numero de inimigos: {Player.Instance.Batalha[0]}");



            Add(@"  Você esta no Coliseu!


                    . o       c ,              0   \0
                    `'#v-- --v#`'             /0--- :\
                     /'>     <`\              / >  / >

                                  0   \0
                                 /0--- :\
                                 / >  / >

                    . o       c ,              0   \0
                    `'#v-- --v#`'             /0--- :\
                     /'>     <`\              / >  / >
            ");

            if (Player.Instance.Batalha[1] == 1)
            {
                Add(@"1) Atacar       2) Defender");
            }
            else
            {
                Add(@"1) Para ir ao Castelo       2) Ir para a Floresta         3) Loja");
            }

        }

        public override void ProcessOption(string playerOption)
        {
            if (Player.Instance.Batalha[1] == 1)
            {
                if (playerOption == "1")
                {
                    Atacar();
                    if (Player.Instance.Batalha[0] > 0 && Player.Instance.Life > 0)
                    {
                        AcaoDoInimigo();
                        Coliseum c = new Coliseum();
                        Move(c);
                    } else if (Player.Instance.Batalha[0] == 0 && Player.Instance.Life > 0)
                    {
                        Console.WriteLine("PARABENS! Você ganhou a batalha\nPrecione qualquer tecle...");
                        Console.ReadKey();
                        Move(new City());
                    }
                    else
                    {
                        Console.WriteLine("GAME OVER! Voce perdeu\nPrecione qualquer tecle...");
                        Console.ReadKey();
                        Player.Instance.Reviver();

                    }
                }
                else if (playerOption == "2")
                {
                    Defender();
                    if (Player.Instance.Batalha[0] > 0 && Player.Instance.Life > 0)
                    {
                        AcaoDoInimigo();
                        Coliseum c = new Coliseum();
                        Move(c);
                    }
                    else if (Player.Instance.Batalha[0] == 0 && Player.Instance.Life > 0)
                    {
                        Add(@"PARABENS! Você ganhou a batalha");
                        Console.ReadKey();
                        Move(new City());
                    }
                    else
                    {
                        Add(@"GAME OVER! Voce perdeu ");
                        Console.ReadKey();
                        Player.Instance.Reviver();

                    }
                }
            }
            else
            {
                if (playerOption == "1")
                {
                    Castle c = new Castle();
                    Move(c);
                }
                else if (playerOption == "2")
                {
                    Florest f = new Florest();
                    Move(f);
                }
                else if (playerOption == "3")
                {
                    Move(new Shop());
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }
            
        }

        public void Atacar()
        {
            int inimigo = Player.Instance.Batalha[0];
            if (Player.Instance.BatalhaInimigo[1] == 0)
            {
                Player.Instance.LifeInimigo[(inimigo - 1)] -= 20;
                if (Player.Instance.LifeInimigo[(inimigo - 1)] <= 0) Player.Instance.Batalha[0]--;
            }
            else
            {
                Player.Instance.LifeInimigo[(inimigo - 1)] -= 10;
                Player.Instance.BatalhaInimigo[1] = 0;
                if (Player.Instance.LifeInimigo[(inimigo - 1)] <= 0) Player.Instance.Batalha[0]--;

            }
            
        }

        public void Defender()
        {
            Player.Instance.EstadoPersonagem = 1;
            
        }

        public void AcaoDoInimigo()
        {
            Random random = new Random();
            int acao = 0;

            acao = random.Next(0, 1);

            if(acao == 0) //aqui o inimigo escolheu atacar
            {
                if (Player.Instance.EstadoPersonagem == 0)
                {
                    Player.Instance.Life -= 20;
                }
                else
                {
                    Player.Instance.Life -= 10;
                    Player.Instance.EstadoPersonagem = 0;
                }
            }
            else
            {

            }

            
        }
    }
}
