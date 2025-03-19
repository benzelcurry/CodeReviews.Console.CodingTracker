using Spectre.Console;
using System.Text.RegularExpressions;
using static CodingTracker.Models.Enums;

namespace CodingTracker.Controllers;
internal class CodingSessionController
{
    public static void AddItem()
    {
        string startTime = GetDate();
        Console.WriteLine(startTime);
        Console.WriteLine("Enter a key to continue");
        Console.ReadKey();
        // TODO: Implement endTime
        // TODO: Implement duration
    }

    private static string GetDate()
    {
        (string? year, string? month, string? day, string? hour, string? minute) dateTime;

        dateTime.year = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter the year:")
                .Validate(year => Regex.IsMatch(year, @"^\d{4}$")
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]Invalid year. Enter a four-digit number.[/]"))
        );

        dateTime.month = AnsiConsole.Prompt(
                new SelectionPrompt<MonthOption>()
                    .Title("Please select the month.")
                    .AddChoices(Enum.GetValues<MonthOption>()))
                .ToString();

        // TODO: Enter validation to ensure the date range is allowable within the given month? May be out of scope for project.
        dateTime.day = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the day:")
                .Validate(day => 
                {
                    if (day < 1 || day > 31)
                        return ValidationResult.Error("[red]Invalid day. Enter a day between 1 and 31.[/red]");

                    return ValidationResult.Success();
                }))
                .ToString();

        dateTime.hour = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the hour:")
                .Validate(hour => (hour >= 1 && hour <= 23)
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]Invalid day. Enter an hour between 1 and 23.[/red]")))
                .ToString();

        dateTime.minute = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the minute:")
            .Validate(min => (min >= 1 && min <= 59)
                ? ValidationResult.Success()
                : ValidationResult.Error("[red]Invalid minute. Enter a minute between 1 and 59.[/red]")))
            .ToString();

        return $"{dateTime.year} {dateTime.month} {dateTime.day} {dateTime.hour} {dateTime.minute}";
    }
}
