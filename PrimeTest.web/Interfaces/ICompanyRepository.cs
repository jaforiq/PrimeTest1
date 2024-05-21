using Microsoft.AspNetCore.Mvc;
using PrimeTechTest.Models;

namespace PrimeTechTest.Interfaces;

public interface ICompanyRepository
{
    Task<Company> CreateAsync(Company primeTech);
    Task<List<Company>> GetAllAsync(int? companyUniqueId);
    Task<Company?>GetByIdAsync(Guid id);
    Task<Company> UpdateAsync(Guid id, Company primeTech);
    Task<Company> UpdateCompanyAsync(Guid id);
    Task<Company> DeleteAsync(Guid id);
}
