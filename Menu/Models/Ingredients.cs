namespace Menu;

public class Ingredients
{
    public int id{get;set;}
    public string Name{get;set;}
    
    public ICollection<DishIngredients> dishIngredients;
}
