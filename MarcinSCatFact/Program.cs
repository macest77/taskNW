using MarcinSCatFact.Services;

var writerService = new FileWriterService();
var filePath = writerService.EnsureFileExists();

Console.WriteLine("Witaj w Kocie Fakty [by Marcin Stefanski]");
Console.WriteLine($"Dane będą zapisywane do pliku: {filePath}");
Console.WriteLine();
Console.WriteLine("[Enter] - pobierz fakt");
Console.WriteLine(" f      - zmień nazwę pliku");
Console.WriteLine(" a      - wyświetl zapisane fakty");
Console.WriteLine(" q      - zakończ program");