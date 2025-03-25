using System.Globalization;
using Spectre.Console;
using System.Text.RegularExpressions;
using static CodingTracker.Models.Enums;

namespace CodingTracker.Controllers;
internal class CodingSessionController
{
    public static void AddItem()
    {
        string format = "yyyy MMMM dd HH mm";
        string startTime = GetDate();
        startTime = Regex.Replace(startTime, @"(\b\d\b)", "0$1");
        DateTime startDate = DateTime.ParseExact(startTime, format, CultureInfo.InvariantCulture);
        Console.WriteLine(startTime);
        string endTime = GetDate();
        endTime = Regex.Replace(endTime, @"(\b\d\b)", "0$1");
        DateTime endDate = DateTime.ParseExact(endTime, format, CultureInfo.InvariantCulture);
        if (endDate > startDate)
            Console.WriteLine("Dates entered in correct order.");
        else
            Console.WriteLine("ERROR! endDate occurred prior to startDate.");

        TimeSpan sessionLength = endDate - startDate;

        Console.WriteLine($"The length of this coding session was {sessionLength.Days} days, {sessionLength.Hours} hours, {sessionLength.Minutes} minutes");

        Console.WriteLine("Enter a key to continue");
        Console.ReadKey();
        // TODO: Implement duration
        // TODO: Implement a doWhile loop that continues until user enters an endDate that's AFTER the startDate
    }

    private static string GetDate()
    {
        (string? year, string? month, string? day, string? hour, string? minute) dateTime;

        dateTime.year = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter the year:")
                .Validate(year => Regex.IsMatch(year, @"^\d{4}$")
                    ? ValidationResult.Success()
                    : ValidationResult.Error("Invalid year. Enter a four-digit number."))
        );

        dateTime.month = AnsiConsole.Prompt(
                new SelectionPrompt<MonthOption>()
                    .Title("Please select the month.")
                    .AddChoices(Enum.GetValues<MonthOption>()))
                .ToString();

        // TODO: Enter validation to ensure the date range is allowable within the given month? May be out of scope for project.
        // TODO: Figure out why this isn't handling errors gracefully; might need to involve regex
        dateTime.day = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the day:")
                .Validate(day => 
                {
                    if (day < 1 || day > 31)
                        return ValidationResult.Error("Invalid day. Enter a day between 1 and 31.");

                    return ValidationResult.Success();
                }))
                .ToString();

        dateTime.hour = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the hour:")
                .Validate(hour => (hour >= 0 && hour <= 23)
                    ? ValidationResult.Success()
                    : ValidationResult.Error("Invalid hour. Enter an hour between 1 and 23.")
                ))
                .ToString();

        dateTime.minute = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the minute:")
            .Validate(min => (min >= 0 && min <= 59)
                ? ValidationResult.Success()
                : ValidationResult.Error("Invalid minute. Enter a minute between 1 and 59.")))
            .ToString();

        return $"{dateTime.year} {dateTime.month} {dateTime.day} {dateTime.hour} {dateTime.minute}";
    }
}
