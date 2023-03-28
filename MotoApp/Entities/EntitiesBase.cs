using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MotoApp.Entities
{
    public abstract class EntityBase : IEntities
    {
        public int Id { get; set; }

        public string FirstName { get; set; }


       
    }
}
