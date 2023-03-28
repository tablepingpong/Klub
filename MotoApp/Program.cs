
using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.DataProvider;
using MotoApp.Entities;
using MotoApp.Entitis;
using MotoApp.Repozytory;
using System.ComponentModel.DataAnnotations;

var servises = new ServiceCollection();
servises.AddSingleton<IApp, App>();
servises.AddSingleton<IRepository<Athlete>, ListRepository<Athlete>>();
servises.AddSingleton<IRepository<Trener>, ListRepository<Trener>>();
servises.AddSingleton<IRepository<Car>, ListRepository<Car>>();
servises.AddSingleton<ICarsProvider, CarsProvider>();

var serviceProvider = servises.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();



//using MotoApp.repozytoris;


//UsKlubApp.Run();




