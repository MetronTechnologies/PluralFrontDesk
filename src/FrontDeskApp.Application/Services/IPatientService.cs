using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Services
{
    public interface IPatientService
    {
        Task<ResponseInfo<Patient>> CreatePatientAsync(CreatePatientDto dto);
    }
}