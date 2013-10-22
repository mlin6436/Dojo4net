﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class Task
    {
        public string Name { get; set; }
        public Task Dependency { get; set; }

        public Task(string name)
        {
            Name = name;
        }
    }
}
