using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Repositories.Abstract;

namespace Photoportfolio.Infrastructure.Repositories
{
    public class AlbumRepository : EntityBaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(PhotoPortfolioDbContext context)
            : base(context)
        {
        }
    }
}
