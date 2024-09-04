


class Program{
    static void Main(){
        loadingAnimation();
        Random random = new Random();

        bool gameOver = false;
        int money = 0;
        int room = 0;
        string[] roomNames = { "Main Room","Vault Room", "Living Room", "Kitchen"};
        int vaultCode = random.Next(1000, 9999);


       // int vaultCode = 1000;
        bool vaultIsRobbed = false;

        Console.Clear();
        Console.WriteLine("Klicka SPACE för att starta!");
        Console.ReadKey();
        
        while(!gameOver) { // Kollar om spelet är över
            Console.Clear();
            Console.WriteLine($"Pengar: {money}");

            if(room <= 3){ // Använder för att det inte ska bli error
                Console.WriteLine($"Rum: {roomNames[room]}\n");
            }
            
            switch(room){ // Kollar om rummet är 0, 1, 2, 3 eller 9
                case 0:
                    Console.WriteLine("Du är i ett hus, du ser 3 dörrar framför dig \n");
                    roomInput(ref room); // Kollar vilket rum du vill gå till
                    break;
                case 1:
                    if(vaultIsRobbed) {
                        System.Console.WriteLine("Du har redan tagit pengarna från kassaskåpet \n");
                        roomInput(ref room);
                    }
                    else {
                        Console.WriteLine("Du kliver in i ett rum med ett kassaskåp, kassaskåpet är låst \n");
                        vaultManager(ref vaultCode, ref room, ref money, random.Next(50, 1000), ref vaultIsRobbed, ref gameOver);
                    }
                    break;
                case 2:
                    Console.WriteLine("Du kliver in i ett rum med en soffa och en TV \n Du lägger märke på att det sitter en man i soffan. Du ser även att det befinner sig en lapp på andra sidan rummet på väggen. \n");
                    System.Console.WriteLine("Commands: \n Lapp \n Mannen");
                    string choice = Console.ReadLine() ?? string.Empty;
                    if(choice.ToLower() == "lapp") {
                        System.Console.WriteLine("######");
                        System.Console.WriteLine($"#{vaultCode}#");
                        System.Console.WriteLine("######");
                        System.Console.WriteLine("Denna kod kan vara viktig! Kom ihåg den. \n");
                        
                        roomInput(ref room);
                    }
                    if(choice.ToLower() == "mannen") {
                        gameOver = true;
                        System.Console.WriteLine("Mannen tog fram ett maskingevär och döda dig!");
                        System.Console.WriteLine("Klicka Space för att börja om");
                        var inputKey1 = Console.ReadKey(intercept: true);
                        if(inputKey1.Key == ConsoleKey.Spacebar) {
                            Main();
                        }
                        
                    }

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Du kliver in i ett kök med en arg kok som dödar dig. \n \n klicka Spacebar för att börja om!");
                    gameOver = true;
                    var inputKey2 = Console.ReadKey(intercept: true);
                        if(inputKey2.Key == ConsoleKey.Spacebar) {
                            Main();
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
            System.Console.WriteLine("Välj ett nummer 1-3 \n");
            System.Console.WriteLine("1. Vault Room");
            System.Console.WriteLine("2. Living Room");
            System.Console.WriteLine("3. Kitchen");
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

    static void vaultManager(ref int vaultCode, ref int room, ref int money, int vaultMoney, ref bool vault, ref bool gameOver){ // Kollar om kod till kassaskåpet är rätt
        while(true){
            System.Console.WriteLine("För att lämna rummet skriv Exit");
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
                    vault = true;
                    gameOver = true;
                    Console.Clear();
                    System.Console.WriteLine($"Du Lyckades själa {vaultMoney}!! \n \n Du vann!");
                    Console.ReadLine();
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
