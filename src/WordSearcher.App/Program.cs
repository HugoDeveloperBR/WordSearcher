using Figgle;
using WordSearcher.App.Core;

namespace WordSearcher.App;

internal static class Program
{
    

    static void Main(string[] args)
    {
        Console.WriteLine(FiggleFonts.Doom.Render("Word Searcher"));

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("// * Localização do arquivo *");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(SearcherConstant.FilePath);
        Console.WriteLine();

        var word = SetSearchWord();
        var searcherType = SetSearcherType();

        GenerateReport(word, searcherType);

        Console.ReadKey();
    }

    private static void GenerateReport(string? word, SearcherType searcherType)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("// * Resumo *");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Palavra pesquisada: {word}");
        Console.WriteLine($"Tipo de pesquisa: {searcherType}");
        Console.WriteLine();

        ISearcher searcher;
        var hit = 0;

        switch (searcherType)
        {
            case SearcherType.Simple:
                searcher = new SimpleSearcher();
                hit = searcher.GetHitCount(word!);
                break;
            case SearcherType.RegularExpression:
                searcher = new RegularExpressionSearcher();
                hit = searcher.GetHitCount(word!);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(searcherType), searcherType, null);
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"A palavra '{word}' foi encontrada {hit} vez(es) no arquivo.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private static string? SetSearchWord()
    {
        string? word;
        var wordIsInvalid = true;

        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Entre com a palavra que deseja pesquisar:");
            Console.ForegroundColor = ConsoleColor.Gray;

            word = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(word))
                continue;

            wordIsInvalid = false;

        } while (wordIsInvalid);

        return word;
    }

    private static SearcherType SetSearcherType()
    {
        var searcherType = SearcherType.None;
        var searcherTypeIsInvalid = true;

        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Selecione o tipo de pesquisa que deseja usar:");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1 - Simples");
            Console.WriteLine("2 - Expressão Regular");

            var input = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
                continue;

            searcherType = (SearcherType)int.Parse(input);

            searcherTypeIsInvalid = false;

        } while (searcherTypeIsInvalid);

        return searcherType;
    }
}



