using FrontDeskApp.Application.Common.Pagination;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.RepositoryInterfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
         Task<PagedResult<Appointment>> GetPagedAppointmentsAsync(
        int pageNumber,
        int pageSize,
        string? sortBy = null,
        bool sortDescending = false,
        string? searchParam = null);
    }
}