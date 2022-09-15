using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYP_Day16_Task.Entities;
using PYP_Day16_Task.Services.Abstract;

namespace PYP_Day16_Task.Services.Concrete
{
    public class QrService:IQrService
    {
        public string GetVCardText(VCard card)
        {
            return $"Begin:VCARD \n" +
                   $"N:{card.FirstName};{card.Surname};\n" +
                   $"EMAIL:{card.Email}\n" +
                   $"TEL;TYPE=work,VOICE:{card.Phone}\n" +
                   $"ADR;TYPE=WORK, :;; {card.Country} , {card.City}\n" +
                   $"END:VCARD";

        }
    }
}
