

class Program{
    static void Main(){
        loadingAnimation();
        Random random = new Random();

        bool gameOver = true;
        int money = 0;
        int room = 0;
        string[] roomNames = { "Main Room","Vault Room", "Living Room", "Kitchen"};
        //int vaultCode = random.Next(1000, 9999);
        int vaultCode = 1000;
        bool vaultIsRobbed = false;

        Console.Clear();
        Console.WriteLine("Klicka SPACE för att starta!");
        var startKey = Console.ReadKey(intercept: true);
        if(startKey.Key == ConsoleKey.Spacebar) gameOver = false;
        
        while(!gameOver) { // Kollar om spelet är över
            Console.Clear();
            Console.WriteLine($"Pengar: {money}");

            if(room <= 3){ // Använder för att det inte ska bli error
                Console.WriteLine($"Rum: {roomNames[room]}\n");
            }
            
            switch(room){ // Kollar om rummet är 0, 1, 2, 3 eller 9
                case 0:
                    Console.WriteLine("Du är i ett hus, du ser 3 dörrar framför dig");
                    roomInput(ref room); // Kollar vilket rum du vill gå till
                    break;
                case 1:
                    if(vaultIsRobbed) {
                        System.Console.WriteLine("Du har redan tagit pengarna från kassaskåpet \n");
                        roomInput(ref room);
                    }
                    else {
                        Console.WriteLine("Du kliver in i ett rum med ett kassaskåp, kassaskåpet är låst");
                        vaultManager(ref vaultCode, ref room, ref money, random.Next(50, 1000), ref vaultIsRobbed);
                    }
                    break;
                case 9:
                    gameOver = true;
                    break;
                default: // Om rummet inte finns
                    Console.WriteLine($"Finns inget rum {room}");
                    roomInput(ref room);
                    break;

            }
        }
    }

    static void roomInput(ref int room){ // Kollar vilket rum du vill gå till
        while(true){
            System.Console.WriteLine("1. Vault Room");
            System.Console.WriteLine("2. Living Room");
            System.Console.WriteLine("4. Kitchen");
            System.Console.Write("Skriv in vilket rum du vill gå till: ");
            string input = Console.ReadLine() ?? string.Empty;
            if (input.ToLower() == "exit")
            {
                room = 0;
                return;
            }
            else if (int.TryParse(input, out int door))
            {
                room = door;
                return;
            }
            else
            {
                Console.WriteLine("Skriv en siffra mellan 1-3 eller skriv exit för att gå tillbaka");
            }
        }
    }

    static void vaultManager(ref int vaultCode, ref int room, ref int money, int vaultMoney, ref bool vault){ // Kollar om kod till kassaskåpet är rätt
        while(true){
            System.Console.Write("Skriv in koden: ");
            string input = Console.ReadLine() ?? string.Empty;
            if(input.ToLower() == "exit"){
                room = 0;
                return;
            }
            else if (int.TryParse(input, out int kod))
            {
                if(kod == vaultCode){
                    money = vaultMoney; 
                    System.Console.WriteLine($"+{vaultMoney}$ pengar");
                    Thread.Sleep(500);
                    vault = true;
                }
                else{
                    Console.WriteLine("Fel kod");
                }
                return;
            }
            else
            {
                Console.WriteLine("Skriv en siffra mellan 0001-9999 eller Skriv Exit för att gå tillbaka");
            }
        }
    }

    static void loadingAnimation(){ // Laddningsanimation
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < 10; i++) { // Adjust the number of iterations as needed
            foreach (var s in spinner) {
                Console.Write($"\rLaddar {s}");
                Thread.Sleep(50); // Adjust the speed as needed
            }
        }
        Console.WriteLine();
        return;
    }
}
