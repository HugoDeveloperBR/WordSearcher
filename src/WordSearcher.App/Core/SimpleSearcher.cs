namespace WordSearcher.App.Core;

public class SimpleSearcher : ISearcher
{
    public int GetHitCount(string word)
    {
        var text = File.ReadAllText(SearcherConstant.FilePath);

        return text.Split(' ').Count(w => w.Contains(word));
    }
}