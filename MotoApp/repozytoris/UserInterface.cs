﻿using Microsoft.EntityFrameworkCore.Metadata;
using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Entitis;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;



namespace MotoApp.repozytoris;

public class UserInterface
{
    public static void Run()
    {

        bool isRun = true;
        var athleteRepositoris = new SqlRepository<Athlete>(new MotoAppDbContext(), AthleteAdd, AthleteRemove);
        var trenerRepositoris = new SqlRepository<Trener>(new MotoAppDbContext());
        athleteRepositoris.ItemAdded += AthleteRepositoryOnItemAdded;
        athleteRepositoris.ItemRemove += AthleteRepostoryOnItemRemove;

        while (isRun)
        {
            Console.WriteLine(
                "Program obsługuje członków klubu sportowego\n" +
                "W - Add player \n" +
                "X - Dodaj trenerów\n" +
                "S - Usuń członka klubu\n" +
                "A - Pokaż wszystkich członków klubu\n" +
                "Q - Close app\n");

            var input = Console.ReadLine();

            switch (input)
            {
                case "w" or "W":
                    Console.Clear();
                    Athlete athlete = CreateAthlete();
                    AddPlayers(athleteRepositoris, athlete);
                   
                    break;

                case "x" or "X":
                    Console.Clear();
                    Trener trener = CreateTrener();
                    AddTreners(trenerRepositoris, trener);
                    break;

                case "S" or "s":
                    Console.Clear();
                    int id = GetAthleteId();
                    Athlete? athleteToRemove = athleteRepositoris.GetById(id);
                    if (athleteToRemove != null)
                        RemovePlayer(athleteRepositoris, athleteToRemove);
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Athlete not exist");
                    }
                    break;

                case "A" or "a":
                    Console.Clear();
                    WriteAllToConsole(athleteRepositoris);
                    break;

                case "q" or "Q":
                    isRun = false;
                    break;

                default:
                    Console.Clear();
                    Console.Write("Wrong key!\n");
                    break;
            }
            if (isRun)
            {
                Console.Write("Press <Enter> to continue");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                Console.Clear();
            }
        }

        static void AthleteRepositoryOnItemAdded(object? sender, Athlete e)
        {
            string playerSerialized = JsonConvert.SerializeObject(sender);
            File.WriteAllText(@"Athlete.json", playerSerialized);
        }

        static void AthleteRepostoryOnItemRemove(object? sender, Athlete e)
        {
            using (StreamWriter sw = new("athlete.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + $" - Athlete added:\n" +
                    $"{e}\n");
            }
        }

        static void AthleteAdd(Athlete item)
        {
            var athlete = (Athlete)item;
            Console.WriteLine($"{item.ToString} is added");
        }

        static void AthleteRemove(Athlete item)
        {
            Console.WriteLine($"{item.ToString}is remove");
        }

        static void AddPlayers<T>(Iwrite<T> repositoris, T item) where T : class, IEntities
        {
            repositoris.Add(item);
            repositoris.Save();
        }

        static void AddTreners<T>(Iwrite<T> repositoris, T item) where T : class, IEntities
        {
            repositoris.Add(item);
            repositoris.Save();
        }

        static void RemovePlayer<T>(Iwrite<T> repositoris, T item) where T : class, IEntities
        {
            repositoris.Remove(item);
            repositoris.Save();
        }

        static Trener CreateTrener()
        {
            while (true)
            {
                Console.WriteLine("FirstName :");
                var firstname = Console.ReadLine();
                Console.WriteLine("Birthyear :");
                var birthyear = Console.ReadLine();
                Console.WriteLine("pesel :");
                var pesel = Console.ReadLine();
                Console.WriteLine("phonenumber :");
                var phonenumber = Console.ReadLine();
                Console.WriteLine("category :");
                var category = Console.ReadLine();

                if (!String.IsNullOrEmpty(firstname)
                && !String.IsNullOrEmpty(birthyear)
                && !String.IsNullOrEmpty(pesel)
                && !String.IsNullOrEmpty(phonenumber)
                && !String.IsNullOrEmpty(category))
                {
                    switch (category)
                    {
                        case "1":
                            return new Trener
                            {
                                FirstName = firstname,
                                Birthyear = birthyear,
                                Pesel = pesel,
                                Phonenumber = phonenumber,
                                Category = Category.Mlodzik
                            };

                        case "Kadet":
                            return new Trener
                            {
                                FirstName = firstname,
                                Birthyear = birthyear,
                                Pesel = pesel,
                                Phonenumber = phonenumber,
                                Category = Category.Kadet
                            };

                        case "Junior":
                            return new Trener
                            {
                                FirstName = firstname,
                                Birthyear = birthyear,
                                Pesel = pesel,
                                Phonenumber = phonenumber,
                                Category = Category.Junior
                            };
                        default:
                            break;
                    }
                }
            }
        }

        static Athlete CreateAthlete()
        {
            while (true)
            {
                Console.WriteLine("FirstName :");
                var firstname = Console.ReadLine();
                Console.WriteLine("Birthyear :");
                var birthyear = Console.ReadLine();
                Console.WriteLine("pesel :");
                var pesel = Console.ReadLine();
                Console.WriteLine("phonenumber :");
                var phonenumber = Console.ReadLine();
                Console.WriteLine("category :");
                var category = Console.ReadLine();
                
                if (!String.IsNullOrEmpty(firstname)
                && !String.IsNullOrEmpty(birthyear)
                && !String.IsNullOrEmpty(pesel)
                && !String.IsNullOrEmpty(phonenumber)
                && !String.IsNullOrEmpty(category))
                {
                    switch(category)
                    {
                        case "1":
                            return new Athlete
                            {
                                FirstName = firstname,
                                Birthyear = birthyear,
                                Pesel = pesel,
                                Phonenumber = phonenumber,
                                Category = Category.Mlodzik
                            };

                        case "Kadet":
                            return new Athlete
                            {
                                FirstName = firstname,
                                Birthyear = birthyear,
                                Pesel = pesel,
                                Phonenumber = phonenumber,
                                Category = Category.Kadet
                            };

                        case "Junior":
                            return new Athlete
                            {
                                FirstName = firstname,
                                Birthyear = birthyear,
                                Pesel = pesel,
                                Phonenumber = phonenumber,
                                Category = Category.Junior
                            };
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Fields must not be empty!");
                }
            }
        }

        static int GetAthleteId()
        {
             while (true)
             {
                      Console.WriteLine("To delete a player enter its id: ");
                        var input = Console.ReadLine();
                        if (int.TryParse(input, out int id))
                            return id;
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Incorrect data was given! Positive integer numbers are required!");
                        }
             }
        }

        static void WriteAllToConsole(IRead<IEntities> athleteRepositoris)
        {
                    var items = athleteRepositoris.GetAll();
                    foreach (var item in items)
                    {
                        Console.WriteLine(item);
                    }
        }

    }
}

