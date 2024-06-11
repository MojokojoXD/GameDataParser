using GameDataParser.Main.Interfaces;

namespace GameDataParser.Main.Dialog
{
    public class ConsoleDialog : IUserPromptable
    {
        public void Output(string message, bool isErrorMessage = false)
        {
            Console.ForegroundColor = isErrorMessage ? ConsoleColor.Red : ConsoleColor.White;

            Console.WriteLine(message);
        }

        public string? Input() => Console.ReadLine();


        public void Exit()
        {
               Console.WriteLine("Press any key to close.");

               Console.ReadKey();

        }

    }
}
