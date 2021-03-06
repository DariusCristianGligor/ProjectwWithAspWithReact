using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IWrapperStringPathReviewRepository
    {
        IQueryable<WrapperStringPathReview> GetAll(Guid reviewId);
        void Add(WrapperStringPathReview wrapperStringPathReview);
    }
}
