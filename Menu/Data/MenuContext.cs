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

        modelBuilder.Entity<Dish>().HasData(
            new Dish{Id=1,Name="Butter Chicken",ImageUrl="https://www.indianhealthyrecipes.com/wp-content/uploads/2023/04/butter-chicken-recipe.jpg",Price=19.99}
        );

        modelBuilder.Entity<Ingredients>().HasData(new Ingredients{Id=1,Name="Chicken"},
        new Ingredients{Id=2,Name="Chicken Masala"});

        modelBuilder.Entity<DishIngredients>().HasData(
            new DishIngredients{DishId=1,IngretientId=1},
            new DishIngredients{DishId=1,IngretientId=2}
        );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Dish> Dishes{get;set;}
    public DbSet<DishIngredients> DishIngredients{get;set;}
    public DbSet<Ingredients> Ingredients{get;set;}

}
