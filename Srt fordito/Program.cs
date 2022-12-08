// See https://aka.ms/new-console-template for more information

using SrtTranslator;
using System.Xml;

OpenAiSimpleTask translator = new OpenAiSimpleTask()
    .SetOpenAiMaxToken(2000)
    .SetOpenAiTemperature(0.0f)
    .SetOpenAiApiKey("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")
    .SetOpenAiModel("text-davinci-003")
    .SetOpenAiPath("https://api.openai.com/v1/completions");

Console.WriteLine("Erről: ");
string errol = Console.ReadLine();
Console.WriteLine("Erre: ");
string erre = Console.ReadLine();
Console.WriteLine("Szöveg: ");
string s = Console.ReadLine();
while (s != "q")
{
    var translated = await translator.Translate($"Fordíts le {errol} nyelvről {erre} nyelvre az alábbi szöveget: \r\n{s}.");
    Console.WriteLine($"{s} ---> {translated}");
    Console.WriteLine("__________________________________________");
    Console.WriteLine("Új Szöveg: ");
    s = Console.ReadLine();
}
