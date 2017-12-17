using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Repositories.Abstract;

namespace Photoportfolio.Infrastructure.Repositories
{
    public class PhotoRepository : EntityBaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(PhotoPortfolioDbContext context)
            : base(context)
        { }
    }
}
