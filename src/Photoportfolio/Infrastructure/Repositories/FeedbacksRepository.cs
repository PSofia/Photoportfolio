using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Repositories.Abstract;

namespace Photoportfolio.Infrastructure.Repositories
{
    public class FeedbacksRepository : EntityBaseRepository<UserFeedback>, IFeedbackRepository
    {
        public FeedbacksRepository(PhotoPortfolioDbContext context)
            : base(context)
        {
        }
    }
}
