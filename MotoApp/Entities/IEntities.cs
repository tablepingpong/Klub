﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Entities
{
    public interface IEntities
    {
        int Id { get; set; }

        string ToString();
    }
}
