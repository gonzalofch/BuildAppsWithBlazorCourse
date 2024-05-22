﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccessBlazor
{
    /// <summary>
    /// Represents a customized pizza as part of an order
    /// </summary>
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public int Id { get; set; }

        [ForeignKey("Order")]

        public int OrderId { get; set; }

        public PizzaSpecial Special { get; set; }

        public int SpecialId { get; set; }

        public int Size { get; set; }

        public List<PizzaTopping> Toppings { get; set; }

        public string GetToppingsText()
        {
            return String.Join(", ", Toppings.Select(t => t.Topping));
        }
        public decimal GetBasePrice()
        {
            if (Special == null)
                throw new NullReferenceException($"{nameof(Special)} was null when calculating Base Price.");
            return ((decimal)Size / (decimal)DefaultSize) * Special.BasePrice;
        }

        public decimal GetTotalPrice()
        {
            if (Toppings.Any(t => t.Topping is null))
                throw new NullReferenceException($"{nameof(Toppings)} contained null when calculating the Total Price.");
            return GetBasePrice() + Toppings.Sum(t => t.Topping!.Price);
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}
