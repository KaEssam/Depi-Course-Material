

using Day1_EF;

var context = new AppDbContext();

//var category = new Category() { Name = "tv"};

//context.categories.Add(category);
//context.SaveChanges();

//Console.WriteLine(category.CategoryCode);
//Console.WriteLine(category.Name);


context.products.AddRange(
    new Product { Name = "samsung", CategoryId = 1, Price = 20000 },
    new Product { Name = "apple", CategoryId = 1, Price = 505050 },
    new Product { Name = "lg", CategoryId = 1, Price = 20052 }
    );

context.SaveChanges();

var tvs = context.products.ToList();
foreach ( var item in tvs)
{
    Console.WriteLine(item.Name);
}