using UCSConsoleGameFramework;
using UCSConsoleGameFramework.Base;
using UCSConsoleGameFramework.Scenarios;

Menu c = new Menu();
c.Show();

//Personagem
//---> Barra de vida

//Coliseu
//---> Mais um caminho quando chegamos na cidade
//---> O coliseu terá que decidir automaticamente quantos inimigos teremos
//---> E as batalhas acontecesse ==> exemplo 3 inimigos*****
//---> Primeiro batalha ---> luta ---> turnos 
//---> Personagem ataca ==> inimigo tem - 10 de vida 
//----> Inimigos atacal==> 5 dano ===> -5 de vida 
//---> Quem defende ===> absorve x% do próximo ataque 

//***
//--->Se eu tenho 3 inimigos, quando eu mato o primeiro, o jogo me transfere 
//----> pro segundo. Mas a minha vida não se recupera