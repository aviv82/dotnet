using System;
//using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace aspdotnet_core_demo.Models
{
    public class User
    {
        public User(int age, string name, string address, Gender gender)
        {
            Age = age;
            Name = name;
            Address = address;
            Gender = gender;
        }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}

