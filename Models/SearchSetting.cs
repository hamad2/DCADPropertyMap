namespace DCADPropertyMap.Models;

public class SearchSetting
{
    public string Key { get; set; }
    public string Label { get; set; }
    public string Name { get; set; }
    public bool IsParcelLayer { get; set; }
    public string InfoWindowHeader { get; set; }
    public string InfoWindowContent { get; set; }
    public int LayerId { get; set; }
    public bool ParcelIdUnique { get; set; }
    public bool LoginRequired { get; set; }
    public string QueryTaskUrl { get; set; }
    public List<QueryField> QueryFields { get; set; }
    public string ServiceURL { get; set; }
    public int SearchId { get; set; }
    public bool SubSearch { get; set; }
    public string Instructions { get; set; }
    public string OutFields { get; set; }
    public string ParcelQuery { get; set; }
    public string ParcelAddressQueryUpdate { get; set; }
    public bool AddressQuery { get; set; }
    public bool ReturnParcelList { get; set; }
    public string LocateParcelListItemQuery { get; set; }
    public string LocateParcelQuery { get; set; }
    public List<string> DisplayFields { get; set; }
    public int PrimaryDisplayField { get; set; }
    public List<string> DisplayNames { get; set; }
    public bool UseColor { get; set; }
    public string Color { get; set; }
    public double Alpha { get; set; }
    public List<Field> Fields { get; set; }
    public List<Example> Examples { get; set; }
    public List<SearchField> SearchFields { get; set; }
}

public class QueryField
{
    public string Field { get; set; }
    public string AddressField { get; set; }
}

public class Field
{
    public string DisplayText { get; set; }
    public string FieldName { get; set; }
    public string DataType { get; set; }
    public bool IsLink { get; set; }
    public string Href { get; set; }
    public string StaffHref { get; set; }
}

public class Example
{
    public string FieldName { get; set; }
    public string Syntax { get; set; }
    public string ExampleText { get; set; }
}

public class SearchField
{
    public string Field { get; set; }
    public string SubField { get; set; }
}