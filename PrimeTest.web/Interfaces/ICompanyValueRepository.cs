using PrimeTechTest.Models;

namespace PrimeTechTest.Interfaces;

public interface ICompanyValueRepository
{
    Task<ColumnMetaData> CreateColumnAsync(ColumnMetaData columnMetaData);
    Task<ColumnValue> CreateColumnValueAsync(ColumnValue columnValue);
    //Task<ColumnValue> UpdateColumnValueAsync(Guid id,ColumnValue value);
}
