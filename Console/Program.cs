using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        rentalManager.Add(new Rental { Id=1,CarId=1,CustomerId=1,RentDate=new DateTime(2022, 08, 19, 11, 15, 00) });
        rentalManager.Update(new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 08, 19, 11, 15, 00),ReturnDate=DateTime.Now });
    }
}