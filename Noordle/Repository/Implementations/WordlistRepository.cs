using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Noordle.Services.Implementations;

public partial class WordlistRepository : IWordlistRepository
{
    public async IAsyncEnumerable<string> GetWordsOfLength(int wordLength)
    {
        var re = WordRegex();
        var ijre = IJRegex();
        
        var assembly = Assembly.GetExecutingAssembly();
        await using var stream = assembly.GetManifestResourceStream("Noordle.Data.basiswoorden-gekeurd.txt");
        if (stream == null) throw new InvalidOperationException();
        using var reader = new StreamReader(stream, Encoding.UTF8);
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (line == null) continue;
            
            var ijCount = ijre.Matches(line).Count;            
            if (re.IsMatch(line) && line.Length == wordLength + ijCount)
            {
                yield return line;
            }
        }
    }

    [GeneratedRegex("[a-z]*")]
    private static partial Regex WordRegex();

    [GeneratedRegex(".*(ij).*")]
    private static partial Regex IJRegex();
}