﻿using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Admanistrator
    {
        public int Id { get; set; }

        [MaxLength(5)]
        public int password { get; set; }
        public string name { get; set; }
    }
}
