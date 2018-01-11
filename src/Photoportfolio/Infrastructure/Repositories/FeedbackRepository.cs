using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Repositories.Abstract;

namespace Photoportfolio.Infrastructure.Repositories
{
    public class FeedbackRepository : EntityBaseRepository<UserFeedback>, IFeedbackRepository
    {
        public FeedbackRepository(PhotoPortfolioDbContext context)
            : base(context)
        {
        }
    }
}
