﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClassLibrary
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }           
    }
}
