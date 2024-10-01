namespace RPS;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to Rock, Paper, Scissors!");
        Console.WriteLine("Please enter \"Rock\", \"Paper\" or \"Scissors\" to begin or \"exit\" to exit!");
        string? userInput = Console.ReadLine();

        do{
            if (userInput.ToLower() == "rock" || userInput.ToLower() == "paper" || userInput.ToLower() == "scissors"){
                Console.WriteLine(Rules.GetAnswer(userInput));
            }
            else{
                Console.WriteLine("Please enter \"Rock\", \"Paper\" or \"Scissors\" or \"Exit\" to exit!");
            }
            userInput = Console.ReadLine();

        } while (userInput.ToLower() != "exit");

    }
}
