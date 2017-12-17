using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Repositories.Abstract;

namespace Photoportfolio.Infrastructure.Repositories
{
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(PhotoPortfolioDbContext context)
            : base(context)
        { }
    }
}
