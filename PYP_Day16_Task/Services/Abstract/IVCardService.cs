using PYP_Day16_Task.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PYP_Day16_Task.Entities;

namespace PYP_Day16_Task.Services.Abstract
{
    public interface IVCardService
    {
        Task<IEnumerable<VCard>> GetAllAsync(Expression<Func<VCard, bool>> filter = null);
        Task<VCard> GetAsync(Expression<Func<VCard, bool>> filter);
        Task<VCard> AddAsync(VCard card);
        Task<VCard> UpdateAsync(VCard card);
        Task<VCard> DeleteAsync(VCard card);
    }
}
