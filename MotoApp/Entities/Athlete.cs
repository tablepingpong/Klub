using MotoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Entitis
{
    public class Athlete : EntitiesBase
    {
        public string FirstName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}, Birthday {Birthyear},Pesel: {Pesel},Phonenumber: {Phonenumber}, {Category}";

       

        public int Birthyear { get; set; }

        public int Pesel { get; set; }

        public int Phonenumber { get; set; }

        public string Category
        {
            get
            {
                switch (Birthyear)
                {
                    case var d when d >= 2014:
                        return "Skrzat";

                    case var d when d >= 2012:
                        return "Żak";

                    case var d when d >= 2010:
                        return "Mlodzik";

                    case var d when d >= 2008:
                        return "Kadet";

                    case var d when d >= 2005:
                        return "Junior";

                    case var d when d >= 1983:
                        return "Senior";

                    default:
                        return "Oldboy";

                }
            }

        }
    }
}

