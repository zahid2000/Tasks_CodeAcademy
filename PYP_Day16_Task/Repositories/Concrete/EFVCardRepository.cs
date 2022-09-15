using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYP_Day16_Task.Core.Repositories.Concrete;
using PYP_Day16_Task.Entities;
using PYP_Day16_Task.Repositories.Abstract;

namespace PYP_Day16_Task.Repositories.Concrete
{
    public class EFVCardRepository:EFRepositoryBase<VCard,VCardContext>,IVCardRepository
    {
    }
}
