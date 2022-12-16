﻿using FastFitProject.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FastFitProject.Data
{
    public class MemberData
    {
        static private Dictionary<int, Members> Member = new Dictionary<int, Members>();

        // GetAll
        public static IEnumerable<Members> GetAll()
        {
            return Member.Values;
        }

        // Add
        public static void Add(Members newMember)
        {
            Member.Add(newMember.Id, newMember);
        }

        // Remove
        public static void Remove(int id)
        {
            Member.Remove(id);
        }

        // GetById
        public static Members GetById(int id)
        {
            return Member[id];
        }
    }
}

