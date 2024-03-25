using System.ComponentModel.DataAnnotations;

namespace Menu;

public class DishIngredients
{   
    public int DishId{get;set;}
    public Dish Dish{get;set;}

    public int IngretientId{get;set;}
    public Ingredients Ingredient{get;set;}
    
    

}
