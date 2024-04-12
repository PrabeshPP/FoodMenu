using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu;

public class MenuController:Controller
{
    private readonly ILogger<MenuContext> _logger;
    private readonly MenuContext menuContext;

    public MenuController(ILogger<MenuContext> _logger, MenuContext menuContext ){
        this._logger = _logger;
        this.menuContext = menuContext;
    }

    public IActionResult Index(){
        List<Dish> dishes = menuContext.Dishes.ToList();
        return View("Index",dishes);
    }

    public async Task<IActionResult> Detail(int? itemid){
        Dish? dish = await menuContext.Dishes.Include(di => di.DishIngredients).ThenInclude(i => i.Ingredient).FirstOrDefaultAsync(x => x.Id == itemid);
        
        return View("Detail",dish);
    }

    public IActionResult CreateItem(){
        return View("CreateItem");
    }
}
