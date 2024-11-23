namespace L.Heritage.Admin.Desktop.Shared.Lib;

public class MetadataList<T> : List<T>
{
    public MetadataList(IEnumerable<T> values, MetaData metaData)
    {
        AddRange(values);
        MetaData = metaData;
    }

    public MetadataList() 
    {
        MetaData = new();
    }

    public MetaData MetaData { get; set; }
}

public class MetaData
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; } = true;
}