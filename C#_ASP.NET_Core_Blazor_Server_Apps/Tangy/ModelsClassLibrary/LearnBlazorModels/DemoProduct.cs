﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClassLibrary.LearnBlazorModels
{
    public class DemoProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public bool isActive { get; set; }
        public List<DemoProductProp> ProductProperties { get; set; }
    }
}
