using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Noordle.Services.Implementations;

public partial class WordlistRepository : IWordlistRepository
{
    private readonly Dictionary<int, List<string>> _cache = new();
    
    [GeneratedRegex("^[a-z]*$")]
    private static partial Regex WordRegex();
    
    public WordlistRepository()
    {
        BuildCache();
    }
    
    public IEnumerable<string> GetWordsOfLength(int wordLength)
        => _cache.TryGetValue(wordLength, out var words)
            ? words
            : Enumerable.Empty<string>();
    
    private void BuildCache()
    {
        var re = WordRegex();
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("Noordle.Data.basiswoorden-gekeurd.txt");
        if (stream == null) throw new InvalidOperationException();
        using var reader = new StreamReader(stream, Encoding.UTF8);
        while (!reader.EndOfStream)
        {
            var word = reader.ReadLine();
            if (word == null || !re.IsMatch(word))
            {
                continue;
            }

            word = word.Replace("ij", "y");
            var length = word.Length;
            if (_cache.TryGetValue(length, out var wordlist))
            {
                wordlist.Add(word);
            }
            else
            {
                _cache.Add(length, new List<string> {word});
            }
        }
    }
}