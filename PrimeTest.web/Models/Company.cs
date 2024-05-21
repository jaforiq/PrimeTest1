namespace PrimeTechTest.Models;

public class Company
{
    public Guid Id { get; set; }
    public int CompanyUniqueId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public IList<ColumnValue> ColumnValues { get; set; }
    public IList<ColumnMetaData> ColumnMetaDatas { get; set; }
}
