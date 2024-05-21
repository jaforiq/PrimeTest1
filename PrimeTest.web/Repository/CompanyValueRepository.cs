using PrimeTechTest.Models;
using PrimeTechTest.Interfaces;
using PrimeTechTest.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace PrimeTechTest.Repository;

public class CompanyValueRepository : ICompanyValueRepository
{
    private readonly CompanyDbContext _companyDbContext;

    public CompanyValueRepository(CompanyDbContext companyDbContext)
    {
        _companyDbContext = companyDbContext;
    }

    public async Task<ColumnMetaData> CreateColumnAsync(ColumnMetaData columnMetaData)
    {
        _companyDbContext.ColumnMetaDatas.Add(columnMetaData);
        await _companyDbContext.SaveChangesAsync();
        return columnMetaData;
    }

    public async Task<ColumnValue> CreateColumnValueAsync(ColumnValue columnValue)
    {
         _companyDbContext.ColumnValues.Add(columnValue);
        await _companyDbContext.SaveChangesAsync();
        return columnValue;
    }

	//public async Task<ColumnMetaData> UpdateAsync(Guid id)
 //   {
	//	var existingCompany = await _companyDbContext.ColumnMetaDatas.FirstOrDefaultAsync(x => x.Id == id);
	//	if (existingCompany == null)
	//	{
	//		return null;
	//	}
	//	return existingCompany;
	//}
	//public async Task<ColumnMetaData> UpdateColumnAsync(Guid id,ColumnMetaData columnMetaData)
	//{
	//	var existingCompany = await _companyDbContext.ColumnMetaDatas.FirstOrDefaultAsync(x => x.Id == id);
	//	if (existingCompany == null)
	//	{
	//		return null;
	//	}
 //       existingCompany.CompanyUniqueId = columnMetaData.CompanyUniqueId;
 //       existingCompany.ColumnInfo = columnMetaData.ColumnInfo;
 //       existingCompany.CompanyId = columnMetaData.CompanyId;
 //       return existingCompany;
	//}

	//public async Task<ColumnValue> UpdateColumnValueAsync(Guid id,ColumnValue value)
	//{
	//	var existingCompany = await _companyDbContext.ColumnValues.FirstOrDefaultAsync(x => x.Id == id);
	//	if (existingCompany == null)
	//	{
	//		return null;
	//	}

 //       existingCompany.CompanyUniqueId = value.CompanyUniqueId;
 //       existingCompany.Value = value.Value;
 //       existingCompany.CompanyId = value.CompanyId;
 //       return existingCompany;

	//}
}
