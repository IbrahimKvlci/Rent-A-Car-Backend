using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());

        carManager.Add(new Car { Id = 4, BrandId = 1, ColorId = 2, DailyPrice = 50, ModelYear = 2018, Description = "Iyi" });
        carManager.Delete(new Car { Id = 1 });
        carManager.Update(new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 5, ModelYear = 1999, Description = "Kotu" });

        //foreach (var car in carManager.GetAll())
        //{
        //    Console.WriteLine(car.ModelYear+" "+car.Description);
        //}

        foreach (var car in carManager.GetByBrandId(1))
        {
            Console.WriteLine(car.ModelYear);
        }
    }
}