class Rules{
    public static string GetAnswer(string userResponse){
        Random rnd = new Random();
        int rpsAnswer = rnd.Next(0,2);
        userResponse = userResponse.ToLower();

        switch(rpsAnswer){
            case 0:
                Console.WriteLine("Rock!");
                if(userResponse == "rock"){
                    return "A Tie! Let's try again!";
                }
                else if(userResponse == "paper"){
                    return "You Win! Let's go again!";
                }
                else{
                    return "I Win! Let's play again!";
                }
            case 1:
                Console.WriteLine("Paper!");
                if(userResponse == "rock"){
                    return "I Win! Let's play again!";
                }
                else if(userResponse == "paper"){
                    return "A Tie! Let's try again!";
                }
                else{
                    return "You Win! Let's go again!";
                }
            case 2:
                Console.WriteLine("Scissors!");
                if(userResponse == "rock"){
                    return "You Win! Let's go again!";
                }
                else if(userResponse == "paper"){
                    return "I Win! Let's play again!";
                }
                else{
                    return "A Tie! Let's try again!";
                }
            default:
                return "Oh no! Something went wrong! Please enter \"Rock\", \"Paper\" or \"Scissors\" to try again! Or type \"exit\" to exit!";
        }
        
    }
}