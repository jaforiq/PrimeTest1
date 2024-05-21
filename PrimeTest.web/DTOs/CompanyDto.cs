using PrimeTechTest.Models;

namespace PrimeTechTest.DTOs;

public class CompanyDto
{
    public Guid Id { get; set; }
    public int CompanyUniqueId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public List<ColumnValueDto> ColumnValues { get; set; }
    public List<ColumnMetaDataDto> ColumnMetaDatas { get; set; }
}
