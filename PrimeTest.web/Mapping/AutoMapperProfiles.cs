using AutoMapper;
using PrimeTechTest.DTOs;
using PrimeTechTest.Models;

namespace PrimeTechTest.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AddCompanyInfoDto, Company>().ReverseMap();
        CreateMap<CompanyDto, Company>().ReverseMap();
        CreateMap<UpdateCompanyInfoDto, Company>().ReverseMap();
        CreateMap<AddColumnMetaDataDto, ColumnMetaData>().ReverseMap();
        CreateMap<ColumnMetaDataDto, ColumnMetaData>().ReverseMap();
        CreateMap<ColumnValueDto, ColumnValue>().ReverseMap();
        CreateMap<AddColumnValueDto, ColumnValue>().ReverseMap();
    }
}
