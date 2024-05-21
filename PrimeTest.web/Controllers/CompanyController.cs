using AutoMapper;
using PrimeTechTest.DTOs;
using PrimeTechTest.Models;
using Microsoft.AspNetCore.Mvc;
using PrimeTechTest.Interfaces;
using PrimeTechTest.Repository;

namespace PrimeTest.web.Controllers;


[Route("{controller}/{action}")]
public class CompanyController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyValueRepository _companyValueRepository;

    public CompanyController(IMapper mapper, ICompanyRepository companyRepository, 
        ICompanyValueRepository companyValueRepository)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _companyValueRepository = companyValueRepository;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddCompanyInfoDto addCompanyInfoDto)
    {
        var primeTechModel = _mapper.Map<Company>(addCompanyInfoDto);

        await _companyRepository.CreateAsync(primeTechModel);
        var companyInfo = _mapper.Map<CompanyDto>(primeTechModel);
        return RedirectToAction("GetAll", "Company");
        //return View();
    }
    
    // GetAll Value and also ID
    [HttpGet("{companyUniqueId:int?}")]
    public async Task<IActionResult> GetAll(int? companyUniqueId)
    {
        var primeDomain = await _companyRepository.GetAllAsync(companyUniqueId);
        var companyInfo = _mapper.Map<List<CompanyDto>>(primeDomain);

        return View(companyInfo);
    }

    // GetById with metadata and it's value
    [HttpGet("{companyUniqueId:int?}")]
    public async Task<IActionResult> GetById(int companyUniqueId)
    {
        var primeDomain = (await _companyRepository.GetAllAsync(companyUniqueId)).FirstOrDefault();
        var companyInfo = _mapper.Map<CompanyDto>(primeDomain);

        return View(companyInfo);
    }

    [HttpGet]
    public IActionResult AddMetaData()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddMetaData(AddColumnMetaDataDto addColumnMetaDataDto)
    {
        var metaData = _mapper.Map<ColumnMetaData>(addColumnMetaDataDto);
        await _companyValueRepository.CreateColumnAsync(metaData);
        return View();
    }

    [HttpGet]
    public IActionResult AddValue()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddValue(AddColumnValueDto addColumnValueDto)
    {
        var DataValue = _mapper.Map<ColumnValue>(addColumnValueDto);
        await _companyValueRepository.CreateColumnValueAsync(DataValue);
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var company = await _companyRepository.UpdateCompanyAsync(id);
        
        return View(company);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Company viewModel)
    {
        await _companyRepository.UpdateAsync(viewModel.Id, viewModel);
        return RedirectToAction("GetAll", "Company");
        //return View() ;
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Company viewModel)
    {
        await _companyRepository.DeleteAsync(viewModel.Id);
		return RedirectToAction("GetAll", "Company");
		//return View();
    }
}
