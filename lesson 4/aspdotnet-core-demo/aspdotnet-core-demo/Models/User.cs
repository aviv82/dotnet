﻿using System;
namespace aspdotnet_core_demo.Models
{
    public class User
    {
        public User(int age, string name)
        {
            Age = age;
            Name = name;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}

