using ArbusTest.Logic;

var dishes = new List<string>
{
    "Матча",
    "Латте",
    "Смузи",
    "Джин",
    "Эскимо"
};

var menuMaster = new MenuMaster(dishes, 2);

Console.WriteLine($"Dishes count: {menuMaster.Count}");
Console.WriteLine($"Page Count: {menuMaster.PageCount}");
Console.WriteLine($"Dishes count per page: {menuMaster.DishesCountPerPage(1)}\n");

Console.WriteLine("----- List of Dishes per Page -----");
foreach (var dish in menuMaster.GetDishesByPage(3))
{
    Console.WriteLine(dish);
}

Console.WriteLine();

Console.WriteLine("----- List of top dishes -----");
foreach (var dish in menuMaster.GetTopDishes())
{
    Console.WriteLine(dish);
}