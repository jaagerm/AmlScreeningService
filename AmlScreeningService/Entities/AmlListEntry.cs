using AmlScreeningService.Common;

namespace AmlScreeningService.Entities;

public class AmlListEntry
{
    public AmlListEntry(string firstName, string lastName, string middleName, string fullName)
    {
        var longestNameValue = new [] { firstName, lastName, middleName, fullName }
            .OrderByDescending(x => x.Length).FirstOrDefault();

        FullNameParts = longestNameValue != null ? NameSplitter.Split(longestNameValue) : null;
    }

    public string[]? FullNameParts { get; }
}