namespace PrimeTechTest.Models;

public class ColumnValue
{
    public Guid Id { get; set; }
    public int CompanyUniqueId { get; set; }
    public string Value { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}
