using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Repositories.Abstract;

namespace Photoportfolio.Infrastructure.Repositories
{
    public class LoggingRepository : EntityBaseRepository<Error>, ILoggingRepository
    {
        public LoggingRepository(PhotoPortfolioDbContext context)
            : base(context)
        { }

        public override void Commit()
        {
            try
            {
                base.Commit();
            }
            catch { }
        }
    }
}
