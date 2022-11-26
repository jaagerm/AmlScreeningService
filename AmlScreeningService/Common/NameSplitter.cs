using System.Text.RegularExpressions;

namespace AmlScreeningService.Common;

public static class NameSplitter
{
    public static string[] Split(string fullName)
    {
        Regex rgx = new Regex("[^a-z ]");
        
        var splitNameParts = rgx.Replace(fullName.ToLower(), " ").Split(" ").Select(x => x.Trim());

        var wordsToIgnore = new[] { "the", "to", "an", "mrs", "mr", "and" };

        var filteredNameParts = splitNameParts.Where(x => x != string.Empty && wordsToIgnore.All(y => y != x)).ToArray();

        return filteredNameParts;
    }
}