using Microsoft.Identity.Client;
using MotoApp.Data;
using MotoApp.DataProvider;
using MotoApp.Entities;
using MotoApp.Entitis;
using MotoApp.Repozytory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp;

public class App : IApp
{
    private readonly IRepository<Athlete> _athleteRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;
    public App(
        IRepository<Athlete> athleteRepository, 
        IRepository<Car> carsRepository,
        ICarsProvider carsProvider) 
    {
        _athleteRepository = athleteRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
    }

    public void Run()
    {
        Console.WriteLine("My methode LinQ");

        var athletes = new[]
        {
            new Athlete {FirstName = "Adam"},
            new Athlete {FirstName = "Mateusz"},
            new Athlete {FirstName = "Piotr"},
            new Athlete {FirstName = "Tadeusz"}
        };

        foreach (var athlete in athletes)
        {
            _athleteRepository.Add(athlete);
        }

        _athleteRepository.Save();

        var items = _athleteRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        var cars = GenerateSampleCars();
        foreach (var item in cars)
        {
            _carsRepository.Add(item);
        }

        Console.WriteLine();
        Console.WriteLine("GetUniquwCar Colors");
        foreach(var item in _carsProvider.GetUniqueCarColors())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("AnonymousClass");
        Console.WriteLine(_carsProvider.AnonymousClass());

        Console.WriteLine();
        Console.WriteLine("GetMinimumPriceOfAllCars");
        Console.WriteLine(_carsProvider.GetMinimumPriceOfAllCars());


        Console.WriteLine();
        Console.WriteLine("GetSpecificColumns");
        foreach(var item in _carsProvider.GetSpecificColumns())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("OrderByName");
        foreach (var item in _carsProvider.OrderByName())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("OrderByNameDescending");
        foreach (var item in _carsProvider.OrderByNameDescending())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("OrderByColorAndName");
        foreach (var item in _carsProvider.OrderByColorAndName())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("OrderByColorAndNameDesc");
        foreach (var item in _carsProvider.OrderByColorAndNameDesc())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("WhereStartsWith T");
        foreach (var item in _carsProvider.WhereStartsWith("t"))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("WhereStartsWithAndCostIsGreaterThan t and 1000");
        foreach (var item in _carsProvider.WhereStartsWithAndCostIsGreaterThan("t", 1000))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("WhereColorIs yellow");
        foreach (var item in _carsProvider.WhereColorIs("yellow"))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("FirstByColor yellow");
        Console.WriteLine(_carsProvider.FirstByColor("Pink"));

        Console.WriteLine();
        Console.WriteLine("FirstOrDefaultByColorWithDefault red");
        Console.WriteLine(_carsProvider.FirstOrDefaultByColorWithDefault("Red"));

        Console.WriteLine();
        Console.WriteLine("LastByColor black");
        Console.WriteLine(_carsProvider.LastByColor("Black"));

        Console.WriteLine();
        Console.WriteLine("FirstOrDefaultByColor blue");
        Console.WriteLine(_carsProvider.FirstOrDefaultByColor("Blue"));

        Console.WriteLine();
        Console.WriteLine("SingleById");
        Console.WriteLine(_carsProvider.SingleById(4));

        Console.WriteLine();
        Console.WriteLine("SingleOrDefaultById");
        Console.WriteLine(_carsProvider.SingleOrDefaultById(2));

        Console.WriteLine();
        Console.WriteLine("TakeCars 3");
        foreach (var item in _carsProvider.TakeCars(3))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("TakeCars ");
        foreach (var item in _carsProvider.TakeCars(2..4))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("TakeCarsWhileNameStartsWith F");
        foreach (var item in _carsProvider.TakeCarsWhileNameStartsWith("F"))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("SkipCars 2");
        foreach (var item in _carsProvider.SkipCars(2))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("SkipCarsWhileNameStartsWith t");
        foreach (var item in _carsProvider.SkipCarsWhileNameStartsWith("t"))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("DistinctAllColors");
        foreach (var item in _carsProvider.DistinctAllColors())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("DistinctByColors");
        foreach (var item in _carsProvider.DistinctByColors())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("ChunkCars ");
        foreach (var item in _carsProvider.ChunkCars(3))
        {
            Console.WriteLine($"Chank:");
            foreach (var i in item)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("###");
        }


    }
    public static List<Car> GenerateSampleCars()
    {
            return new List<Car>
            {
                new Car
                {
                    Id = 45,
                    Name = "toyota",
                    Color = "Black",
                    StandardCost = 1020.32M,
                    ListPrice = 1431.50M,
                    Type = "Sedan",
                },
                new Car
                {
                    Id = 44,
                    Name = "Ferrari",
                    Color = "Blue",
                    StandardCost = 1045.32M,
                    ListPrice = 1451.50M,
                    Type = "Combi",
                },
                new Car
                {
                    Id = 43,
                    Name = "toyota",
                    Color = "Blue",
                    StandardCost = 1025.32M,
                    ListPrice = 1471.50M,
                    Type = "Sedan",
                },
                new Car
                {
                    Id = 42,
                    Name = "Ferrari",
                    Color = "Red",
                    StandardCost = 1028.32M,
                    ListPrice = 1433.50M,
                    Type = "Sedan",
                },
                new Car
                {
                    Id = 41,
                    Name = "Ferrari",
                    Color = "Black",
                    StandardCost = 1125.32M,
                    ListPrice = 1531.50M,
                    Type = "Bus",
                },
                new Car
                {
                    Id = 40,
                    Name = "toyota",
                    Color = "Red",
                    StandardCost = 1525.32M,
                    ListPrice = 1631.50M,
                    Type = "Combi",
                },
                new Car
                {
                    Id = 46,
                    Name = "Ferrari",
                    Color = "Yellow",
                    StandardCost = 1425.32M,
                    ListPrice = 1131.50M,
                    Type = "Sedan",
                },
                new Car
                {
                    Id = 47,
                    Name = "toyota",
                    Color = "Yellow",
                    StandardCost = 1525.32M,
                    ListPrice = 1831.50M,
                    Type = "Combi",
                },
                new Car
                {
                    Id = 48,
                    Name = "Ferrari",
                    Color = "Pink",
                    StandardCost = 1055.32M,
                    ListPrice = 1461.50M,
                    Type = "Bus",
                }
            };
        
    }

    
}

