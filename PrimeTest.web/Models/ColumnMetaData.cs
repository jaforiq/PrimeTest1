namespace PrimeTechTest.Models;

public class ColumnMetaData
{
    public Guid Id { get; set; }
    public int CompanyUniqueId { get; set; }
    public string ColumnInfo { get; set; }

    public Guid CompanyId { get; set; }    
    public Company Company { get; set; }
}
