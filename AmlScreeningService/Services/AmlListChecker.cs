using System.Text.RegularExpressions;
using AmlScreeningService.Common;
using AmlScreeningService.Entities;

namespace AmlScreeningService.Services;

public interface IAmlListChecker
{
    bool IsMatched(string nameToMatch);
}

public class AmlListChecker : IAmlListChecker
{
    private readonly IAmlListCache amlListCache;

    public AmlListChecker(IAmlListCache amlListCache)
    {
        this.amlListCache = amlListCache;
    }
    
    public bool IsMatched(string nameToMatch)
    {
        var amlListEntriesWithScore = amlListCache.GetAll().Where(x => x.FullNameParts != null).Select(x => new AmlListEntryWithScore(x)).ToArray();
        var matchNameParts = NameSplitter.Split(nameToMatch);

        foreach (var amlListEntryWithScore in amlListEntriesWithScore)
        {
            foreach (var matchNamePart in matchNameParts)
            {
                if (amlListEntryWithScore.AmlListEntry.FullNameParts!.Any(x => x == matchNamePart))
                {
                    amlListEntryWithScore.MatchCount += 1;
                }
            }
        }

        var fullMatchFound = amlListEntriesWithScore.Any(x => x.MatchCount == matchNameParts.Length);

        return fullMatchFound;
    }
}

public class AmlListEntryWithScore
{
    public AmlListEntryWithScore(AmlListEntry amlListEntry)
    {
        AmlListEntry = amlListEntry;
    }
    
    public int MatchCount { get; set; }
    
    public AmlListEntry AmlListEntry { get; }
}