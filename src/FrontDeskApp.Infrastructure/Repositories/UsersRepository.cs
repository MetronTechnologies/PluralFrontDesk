using FrontDeskApp.Application.RepositoryInterfaces;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Infrastructure.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {

        public UsersRepository(FrontDeskAppDbContext context) : base(context) { }
        
    }
}