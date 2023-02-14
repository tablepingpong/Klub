using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Entitis;
using MotoApp.repozytoris;

var athleteRepositoris = new SqlRepository<Athlete>(new MotoAppDbContext());
AddAthletes(athleteRepositoris);
AddTrener(athleteRepositoris);
WriteAllToConsole(athleteRepositoris);


static void AddAthletes(IRepository<Athlete> athleteRepositoris)
{
    athleteRepositoris.Add(new Athlete { FirstName = "Adam", Birthyear = 2013, Phonenumber = 546789456, Pesel = 789547879});
    athleteRepositoris.Add(new Athlete { FirstName = "Piotr", Birthyear = 2010, Phonenumber = 546459456, Pesel = 789457879 } );
    athleteRepositoris.Add(new Athlete { FirstName = "Mateusz", Birthyear = 2010, Phonenumber = 546445456, Pesel = 789457879 });
    athleteRepositoris.Save();
    
}

static void AddTrener(Iwrite<Trener> trenerRepositoris)
{
    trenerRepositoris.Add(new Trener { FirstName = "Lukasz" });
    trenerRepositoris.Add(new Trener { FirstName = "Rafał" });
    trenerRepositoris.Add(new Trener { FirstName = "Jacek" });
    trenerRepositoris.Save();
}



static void WriteAllToConsole(IRead<IEntities> repositoris)
{
    var items = repositoris.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
   
 
}




