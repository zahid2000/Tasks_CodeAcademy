using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PYP_Day16_Task.Entities;
using PYP_Day16_Task.Repositories.Abstract;
using PYP_Day16_Task.Services.Abstract;

namespace PYP_Day16_Task.Services.Concrete
{
    public class VCardService:IVCardService
    {
        protected  readonly  IVCardRepository _cardRepository;

        public VCardService(IVCardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<VCard>> GetAllAsync(Expression<Func<VCard, bool>> filter = null)
        {
            return await _cardRepository.GetAllAsync(filter);
        }

        public async Task<VCard> GetAsync(Expression<Func<VCard, bool>> filter)
        {
            return await  _cardRepository.GetAsync(filter);
        }

        public async Task<VCard> AddAsync(VCard card)
        {
          return  await  _cardRepository.AddAsync(card);
        }

        public async Task<VCard> UpdateAsync(VCard card)
        {
            return await _cardRepository.UpdateAsync(card);
        }

        public async Task<VCard> DeleteAsync(VCard card)
        {
            return await _cardRepository.DeleteAsync(card);
        }
    }
}
