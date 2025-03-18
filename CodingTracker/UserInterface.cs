using Spectre.Console;
using static CodingTracker.Models.Enums;

namespace CodingTracker;
internal class UserInterface
{
    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MonthOption>()
                .Title("Please select the month your coding session began.")
                .AddChoices(Enum.GetValues<MonthOption>()));

            switch (actionChoice)
            {
                case MonthOption.January:
                    Console.WriteLine("ERROR: January not implemented.");
                    break;
                case MonthOption.February:
                    Console.WriteLine("ERROR: February not implemented either.");
                    break;
                default:
                    Console.WriteLine("Good job!");
                    break;
            }
        }
    }
}
