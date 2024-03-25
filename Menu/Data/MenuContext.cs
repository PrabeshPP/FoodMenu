using Microsoft.EntityFrameworkCore;

namespace Menu;

public class MenuContext:DbContext
{
    public MenuContext(DbContextOptions<MenuContext> options):base(options){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredients>().HasKey(e=>new{
            e.DishId,
            e.IngretientId
        });

        modelBuilder.Entity<DishIngredients>().HasOne(e=>e.Ingredient);
        modelBuilder.Entity<DishIngredients>().HasOne(e=>e.Dish).WithMany(e=>e.DishIngredients).HasForeignKey(d=>d.DishId);
        modelBuilder.Entity<DishIngredients>().HasOne(i=>i.Ingredient).WithMany(DI=>DI.DishIngredients).HasForeignKey(i=>i.IngretientId);
        base.OnModelCreating(modelBuilder);
    }

}
