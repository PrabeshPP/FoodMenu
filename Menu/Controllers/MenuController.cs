using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Detail(int? itemid){
        Dish? dish = menuContext.Dishes.FirstOrDefault(u=>u.Id == itemid);
        return View("Detail",dish);
    }
}
