using System.ComponentModel.DataAnnotations;

namespace Menu;

public class DishIngredients
{   
    public int DishId{get;set;}
    public Dish dish{get;set;}

    public int IngretientId{get;set;}
    public Ingredients ingredients{get;set;}
    
    

}
