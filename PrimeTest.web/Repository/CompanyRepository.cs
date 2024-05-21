using PrimeTechTest.Models;
using Microsoft.AspNetCore.Mvc;
using PrimeTechTest.Interfaces;
using Microsoft.EntityFrameworkCore;
using PrimeTechTest.ApplicationDbContext;

namespace PrimeTechTest.Repository;

public class CompanyRepository : ICompanyRepository
{
    private readonly CompanyDbContext _companyDbContext;

    public CompanyRepository(CompanyDbContext companyDbContext)
    {
        _companyDbContext = companyDbContext;
    }

    public async Task<Company> CreateAsync(Company company)
    {
        _companyDbContext.Companies.Add(company);
        await _companyDbContext.SaveChangesAsync();
        return company;
    }

    public async Task<List<Company>> GetAllAsync(int? companyUniqueId)
    {
        var company = _companyDbContext.Companies.Include("ColumnMetaDatas").Include("ColumnValues").AsQueryable();      
        
        if(companyUniqueId != null)
        {           
            company = company.Where(x => x.CompanyUniqueId.Equals(companyUniqueId));            
        }    
                              
        return await company.ToListAsync();
    }

    public async Task<Company> UpdateAsync(Guid id, Company company)
    {
        var existingCompany = await _companyDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);  
        if(existingCompany == null)
        {
            return null;
        }
        existingCompany.CompanyUniqueId = company.CompanyUniqueId;
        existingCompany.Name = company.Name;
        existingCompany.Address = company.Address;
        await _companyDbContext.SaveChangesAsync();

        return existingCompany;
    }

    public async Task<Company> UpdateCompanyAsync(Guid id)
    {
        var existingCompany = await _companyDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if( existingCompany == null)
        {
            return null;
        }
        return existingCompany;
    }
    public async Task<Company> DeleteAsync(Guid id)
    {
        var existingCompany = await _companyDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCompany == null)
        {
            return null;
        }

        _companyDbContext.Companies.Remove(existingCompany); 
        await _companyDbContext.SaveChangesAsync();
        return existingCompany;
    }

    public async Task<Company?> GetByIdAsync(Guid id)
    {
        return await _companyDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
    }
}
