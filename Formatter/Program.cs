using System.Reflection;
using System.Text.RegularExpressions;

namespace Formatter;

internal static partial class Program
{
    private static void Main()
    {
        string directory = "";

        if (Directory.Exists(directory) == false)
        {
            string repoName = "JuniorFactory";
            string location = Assembly.GetExecutingAssembly().Location;
            directory = location[..(location.LastIndexOf(repoName, StringComparison.InvariantCultureIgnoreCase) + repoName.Length)];
        }

        IEnumerable<string> folders = Directory
            .EnumerateDirectories(directory)
            .Where(s => s.Contains("Lesson"));

        foreach (string folder in folders)
        {
            string inputFilePath = Path.Combine(folder, "video.md");
            string readmeFilePath = Path.Combine(folder, "README.md");

            Console.WriteLine($"Обработка папки {folder}.");

            if (File.Exists(inputFilePath) == false)
            {
                Console.WriteLine("Файл video.md не найден.");
                return;
            }

            if (File.Exists(readmeFilePath) == false)
            {
                Console.WriteLine("Файл README.md не найден.");
                return;
            }

            ReplaceYouTubeLinks(readmeFilePath);

            string? videoId = ExtractVideoId(readmeFilePath);

            if (string.IsNullOrEmpty(videoId))
            {
                Console.WriteLine("ID видео не найден в файле README.md.");
                return;
            }

            Console.WriteLine($"ID видео: {videoId}");

            string[] lines = File.ReadAllLines(inputFilePath);

            using (StreamWriter outputFile = new(inputFilePath, false))
            {
                bool isTitleBefore = false;

                foreach (string line in lines)
                {
                    if (isTitleBefore && string.IsNullOrWhiteSpace(line) == false)
                    {
                        outputFile.WriteLine();
                        Console.WriteLine("Добавлена пустая строка после заголовка");
                    }

                    if (line.StartsWith('•'))
                    {
                        string updatedLine = "-" + line[1..];
                        outputFile.WriteLine(updatedLine);
                        isTitleBefore = false;
                        continue;
                    }

                    Match match = BasePattern().Match(line.TrimStart('#', ' '));

                    if (match.Success)
                    {
                        string timeCode = match.Groups[1].Value;
                        string description = match.Groups[2].Value;

                        if (line.Contains(']'))
                        {
                            outputFile.WriteLine(line);
                        }
                        else
                        {
                            string timeInSeconds = TimeCodeToSeconds(timeCode);
                            string youtubeLink = $"https://www.youtube.com/watch?v={videoId}&t={timeInSeconds}s";
                            string updatedLine = $"### {timeCode} [{description}]({youtubeLink})";
                            outputFile.WriteLine(updatedLine);
                            Console.WriteLine($"Обновлена строка: {updatedLine}");
                        }

                        isTitleBefore = true;
                    }
                    else
                    {
                        isTitleBefore = false;
                        outputFile.WriteLine(line);
                    }
                }
            }

            Console.WriteLine("Преобразование завершено. Результат сохранен в video.md.");
        }
    }

    private static string? ExtractVideoId(string readmeFilePath)
    {
        string[] lines = File.ReadAllLines(readmeFilePath);

        foreach (string line in lines)
        {
            Match match = ExtractVideoPattern().Match(line);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
        }

        return null;
    }

    private static string TimeCodeToSeconds(string timeCode)
    {
        string[] parts = timeCode.Split(':');
        int hours;
        int minutes;
        int seconds;

        if (parts.Length == 3)
        {
            hours = int.Parse(parts[0]);
            minutes = int.Parse(parts[1]);
            seconds = int.Parse(parts[2]);
        }
        else
        {
            hours = 0;
            minutes = int.Parse(parts[0]);
            seconds = int.Parse(parts[1]);
        }

        return (hours * 3600 + minutes * 60 + seconds).ToString();
    }

    private static void ReplaceYouTubeLinks(string filePath)
    {
        const string Replacement = "https://www.youtube.com/watch?v=$1";

        string input = File.ReadAllText(filePath);
        string output = Regex.Replace(input, YouTubeLinkPattern().ToString(), Replacement);

        if (input == output)
        {
            return;
        }

        File.WriteAllText(filePath, output);
        Console.WriteLine("Ссылки успешно заменены.");
    }

    [GeneratedRegex(@"https://youtu\.be/([a-zA-Z0-9_-]+)")]
    private static partial Regex YouTubeLinkPattern();

    [GeneratedRegex(@"\[.*\]\(https://www\.youtube\.com/watch\?v=([a-zA-Z0-9_-]+)\)")]
    private static partial Regex ExtractVideoPattern();

    [GeneratedRegex(@"(\d{2}:\d{2}:\d{2}|\d{2}:\d{2}) (.+)$")]
    private static partial Regex BasePattern();
}
