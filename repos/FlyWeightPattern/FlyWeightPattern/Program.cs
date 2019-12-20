using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace FlyWeightPattern
{
    public class User
    {
        private string fullName;

        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }

    [TestFixture]
    public class Demo
    {
        static void Main(string[] args)
        {
            
        }

        [Test]
        public void TestUser()
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User>();
            foreach (var firstName in firstNames)
            foreach (var lastName in lastNames)
                users.Add(new User($"{firstName} {lastName}"));
            ForceGC();
            dotMemory.Check(memory =>
            {
                Console.WriteLine(memory.SizeInBytes);
            });
        }

        private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString()
        {
            Random rand = new Random();
            return new string(
                Enumerable.Range(0, 10)
                    .Select(i => (char) ('a' + rand.Next(26)))
                    .ToArray());
        }
    }
}
