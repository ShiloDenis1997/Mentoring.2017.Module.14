﻿using System.Collections.Generic;
using FindWay.Interfaces.Models;

namespace FindWay.Infrastructure.Models
{
    public class Node : INode
    {
        public ICollection<IRoute> Routes { get; set; }
    }
}