﻿using FastFitProject.Controllers;
using FastFitProject.Models;
using System;

namespace FastFitProject.Models
{
    public class Members
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public string ShoeSize { get; set; }
        public MemberGender Gender { get; set; }

        public Members()
        {
        }

        public Members( string name, int age, string shoeSize, MemberGender gender)
        {
            Name = name;
            Age = age;
            ShoeSize = shoeSize;
            Gender = gender;

        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Members members &&
                Id == members.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
