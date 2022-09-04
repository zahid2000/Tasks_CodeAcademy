using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day9_Task.IServices;
using Day9_Task.Models;

namespace Day9_Task.Services
{
    public class OrderService : IOrderService
    {
        private Order _order;
        public OrderService(Order order)
        {
            _order = order;
        }
        public void OrderBook(Book book)
        {
            _order.Books.Add(book);
            _order.TotalPrice += book.Price;
            Console.WriteLine($" Ordered Book -> Name : {book.Name} AuthorName : {book.AuthorName} Price:{book.Price}  PageCount : {book.PageCount} Code : {book.GetCode()}");

        }

        public double GetTotalPrice()
        {
            var result = _order.TotalPrice;
            Console.WriteLine($"Total Price {result}");
            return result;

        }

        public double GetTotalPriceByDiscount()
        {
            double price = GetTotalPrice();
            if (price >= 100 && price <= 200)
            {
                price = price - ((price * 20) / 100);
                Console.WriteLine($"Order Price {price} by 10% discount");
            }
            else if (price > 200)
            {
                price = price - ((price*10)/100);
                Console.WriteLine($"Order Price {price} by 20% discount");

            }
            else
            {

                Console.WriteLine($"Order Price {price}");
            }
            return price;
        }


    }
}
