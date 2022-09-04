using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day9_Task.Models;

namespace Day9_Task.IServices;

    public interface IOrderService
    {
        void OrderBook(Book book);
        double GetTotalPrice();
        double GetTotalPriceByDiscount();

    }
