using Puzzle.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.ConsoleApp
{
    public class Receipt
    {
        private List<Item> _items = new List<Item>();
        private const double _taxRate = 0.10;

        public void AddItem(int quantity, string description, double price)
        {
            _items.Add(new Item { Quantity = quantity, Description = description, Price = price });
        }

        public override string ToString()
        {
            double subTotal = 0.0;
            double tax = 0.0;
            double total = 0.0;
            var itemLines = _items.Select(item =>
            {
                double itemTotal = item.Quantity * item.Price;
                subTotal += itemTotal;
                return $"{item.Quantity} {item.Description} @ ${item.Price:F2} = ${itemTotal:F2}";
            }).ToList();

            tax = subTotal * _taxRate;
            total = subTotal + tax;

            var receiptLines = itemLines.Append($"SubTotal = ${subTotal:F2}")
                                       .Append($"Tax ({_taxRate:P0}) = ${tax:F2}")
                                       .Append($"Total = ${total:F2}");

            return string.Join(Environment.NewLine, receiptLines);
        }
    }
}
