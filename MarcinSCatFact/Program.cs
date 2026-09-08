using MarcinSCatFact.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient(); // rejestruje IHttpClientFactory
builder.Services.AddSingleton<IApiService, ApiService>();
builder.Services.AddSingleton<IFileWriterService, FileWriterService>();

using var host = builder.Build();

var apiService = host.Services.GetRequiredService<IApiService>();
var writerService = new FileWriterService();
var readerService = new FileReaderService();
var filePath = writerService.EnsureFileExists();

Console.WriteLine("Witaj w Kocie Fakty [by Marcin Stefanski]");
Console.WriteLine($"Dane będą zapisywane do pliku: {filePath}");
Console.WriteLine();
Console.WriteLine("[Enter] - pobierz fakt");
Console.WriteLine(" f      - zmień nazwę pliku");
Console.WriteLine(" a      - wyświetl zapisane fakty");
Console.WriteLine(" q      - zakończ program");
Console.WriteLine();

var run = true;

while (run)
{
    Console.Write("> ");
    var input = Console.ReadLine()?.Trim().ToLowerInvariant();

    switch (input)
    {
        case "q":
            run = false; break;
        case "a":
            readerService.ReadFile(writerService);
            break;
        case "f":
            Console.Write("Podaj nową nazwę pliku: ");
            var newName = Console.ReadLine()?.Trim().ToLowerInvariant();
            if (newName.Length > 0)
            {
                writerService.SetFileName(newName);
            } else
            {
                Console.WriteLine("Nie podano nazwy pliku. Nazwa bez zmian.");
            }
            break;
        default:
            await FetchAndSaveFactAsync(apiService, writerService);
            break;

    }


}

static async Task FetchAndSaveFactAsync(IApiService apiService, IFileWriterService writerService)
{
    try {
        var fact = await apiService.GetCatFactAsync();
        Console.WriteLine($"Pobrano: {fact}");

        await writerService.AppendLineAsync(fact.ToString());
        Console.WriteLine("Zapisano do pliku.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Błąd podczas pobierania/zapisu: {ex.Message}");
    }
}