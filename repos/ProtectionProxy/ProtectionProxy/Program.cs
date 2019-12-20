using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is being driven");
        }
    }

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            Age = age;
        }
    }

    public class CarProxy : ICar
    {
        private Driver driver;
        private Car car = new Car();
        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }
        public void Drive()
        {
            if(driver.Age >= 16) car.Drive();
            else
            {
                Console.WriteLine("Too young");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(16));
            car.Drive();
        }
    }
}
