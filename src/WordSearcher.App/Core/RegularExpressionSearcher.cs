using System.Text.RegularExpressions;

namespace WordSearcher.App.Core;

public class RegularExpressionSearcher : ISearcher
{
    public int GetHitCount(string word)
    {
        var pattern = $@"\b{word.ToLower()}\b";
        var text = File.ReadAllText(SearcherConstant.FilePath);

        var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        return regex.Matches(text).Count;
    }
}