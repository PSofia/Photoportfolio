using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Repositories.Abstract;

namespace Photoportfolio.Infrastructure.Repositories
{
    public class UserRoleRepository 
        : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(PhotoPortfolioDbContext context)
            : base(context)
        { }
    }
}
