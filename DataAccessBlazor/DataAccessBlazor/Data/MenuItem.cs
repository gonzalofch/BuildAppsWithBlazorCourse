using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MenuItem
{
    public int PizzaId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Vegetarian { get; set; }
    public bool Vegan { get; set; }

    public string Category { get; set; }
    public List<string> Topping { get; set; }
    public int Rank { get; set; }






    public void InitializeDescription()
    {
        StringBuilder stringBuilder = new StringBuilder();

        Topping.ForEach(s => stringBuilder.Append(s).Append(", "));
        stringBuilder.Length -= 2;
        Description = stringBuilder.ToString();
    }
}