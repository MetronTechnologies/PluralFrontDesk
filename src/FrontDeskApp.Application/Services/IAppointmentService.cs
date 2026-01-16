using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.Common.Pagination;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Services
{
    public interface IAppointmentService
    {
         Task<ResponseInfo<Appointment> > CreateAppointmentAsync(AppointmentDto appointment);

         Task<ResponseInfo<PagedResult<Appointment>>> GetAppointmentsPagedAsync(
    int pageNumber,
    int pageSize,
    string? sortBy = null,
    bool sortDescending = false,
    string? searchParam = null);
    }
}