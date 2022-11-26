using System.Collections.Immutable;
using AmlScreeningService.Entities;

namespace AmlScreeningService.Services;

public interface IAmlListCache
{
    void RenewCache();
    ImmutableArray<AmlListEntry> GetAll();
}

public class AmlListCache : IAmlListCache
{
    private readonly IAmlListCaptureService amlListCaptureService;
    private ImmutableArray<AmlListEntry> amlList;

    public AmlListCache(IAmlListCaptureService amlListCaptureService)
    {
        this.amlListCaptureService = amlListCaptureService;
        amlList = amlListCaptureService.GetFromCsv().ToImmutableArray();
    }


    public void RenewCache()
    {
        amlList = amlListCaptureService.GetFromCsv().ToImmutableArray();
    }

    public ImmutableArray<AmlListEntry> GetAll()
    {
        return amlList;
    }
}