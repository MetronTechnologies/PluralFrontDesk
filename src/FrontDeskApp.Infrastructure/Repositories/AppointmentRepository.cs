using FrontDeskApp.Application.Common.Pagination;
using FrontDeskApp.Application.RepositoryInterfaces;
using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrontDeskApp.Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {

        private readonly DbContext _context;
        public AppointmentRepository(FrontDeskAppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<PagedResult<Appointment>> GetPagedAppointmentsAsync(
        int pageNumber,
        int pageSize,
        string? sortBy = null,
        bool sortDescending = false,
        string? searchParam = null)
        {
            var query = _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Clinic)
                .AsQueryable();

            // Apply search
            if (!string.IsNullOrWhiteSpace(searchParam))
            {
                var lowerSearch = searchParam.ToLower();
                query = query.Where(a =>
                    (a.Patient.FirstName + " " + a.Patient.LastName).ToLower().Contains(lowerSearch)
                    || a.Patient.Code.ToLower().Contains(lowerSearch)
                    || a.Patient.PhoneNumber.ToLower().Contains(lowerSearch)
                );
            }

            // Pagination
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Appointment>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }

}



