

using System.Diagnostics;

class Program{
    static void Main(){
        Random random = new Random();

        bool gameOver = true;
        bool input = false;
        int money = 0;
        int room = 0;
        //int vaultCode = random.Next(1000, 9999);
        int vaultCode = 1000;
        bool vault = false;

        Console.WriteLine("Klicka SPACE för att starta!");
        var startKey = Console.ReadKey(intercept: true);
        if(startKey.Key == ConsoleKey.Spacebar) gameOver = false;
        
        while(!gameOver) {
            Console.Clear();
            input = false;
            System.Console.WriteLine($"Pengar: {money}");

            switch(room){
                case 0:
                    input = true;
                    Console.WriteLine("Du står utanför ett okänt hus");
                    break;
                case 1:
                    Console.WriteLine("Du Är i huset och ser 3 dörrar");
                    Console.WriteLine("Vilken dörr väljer du att gå in i? Skriv 1-3");
                    int door;
                    while(!int.TryParse(Console.ReadLine(), out door)){
                        Console.WriteLine("Skriv ett nummer mellan 1-3");
                    }
                    if(door == 2) room = 2;
                    if(door == 3) room = 3;
                    if(door == 4) room = 4;
                    break;
                case 2:
                    if(vault) break;
                    bool isRobbed = false;
                    int vaultMoney = random.Next(50, 1000);
                    Console.WriteLine("Du kliver in i ett rum med ett kassaskåp, kassaskåpet är låst");
                    System.Console.WriteLine("Skriv in koden till kassaskåpet");
                    int kod;
                    while(!int.TryParse(Console.ReadLine(), out kod)){
                        System.Console.WriteLine("Skriv en kod mellan 0001-9999");
                    }
                    if(kod == vaultCode) {money = vaultMoney; isRobbed = true;}
                    if(isRobbed) {
                        System.Console.WriteLine($"Du öppnade kassaskåpet med koden {vaultCode} och tog alla pengar! ${vaultMoney}+");
                        room = 9;
                    }
                    break;
                case 9:
                    Console.Clear();
                    System.Console.WriteLine("Du vann du lyckades ta pengarna ur kassaskåpet!");
                    Thread.Sleep(10000);
                    gameOver = true;
                    break;
                default:
                    System.Console.WriteLine("Finns inget rum");
                    break;

            }

            
            if(input){
                var key = Console.ReadKey(intercept: true);
                switch(key.Key){
                    case ConsoleKey.D1:
                        room = 1;
                        break;
                }
            }
            

        }
    }
}
