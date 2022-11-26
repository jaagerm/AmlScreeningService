using AmlScreeningService.Entities;

namespace AmlScreeningService.Services;

public interface IAmlListCaptureService
{
    List<AmlListEntry> GetFromCsv();
}

public class AmlListCaptureService : IAmlListCaptureService
{
    public List<AmlListEntry> GetFromCsv()
    {
        var amlListRaw = File.ReadAllLines("20221118-FULL-1_1.csv");
        var amlEntries = new List<AmlListEntry>();
             
        foreach(var line in amlListRaw)
        {
            var splitRow = line.Split(';');
            amlEntries.Add(new AmlListEntry(splitRow[19], splitRow[18], splitRow[20], splitRow[21]));
        }

        return amlEntries;
    }

}