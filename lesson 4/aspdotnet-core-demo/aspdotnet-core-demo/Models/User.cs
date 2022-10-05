using System;
namespace aspdotnet_core_demo.Models
{
    public class User
    {
        public User(int age)
        {
            Age = age;
        }
        public int Age { get; set; }
    }
}

