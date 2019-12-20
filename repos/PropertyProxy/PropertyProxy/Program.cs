using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyProxy
{
    class Program
    {
        public class Property<T> : IEquatable<Property<T>> where T : new()
        {
            private T value;

            public T Value
            {
                get => value;
                set
                {
                    if (Equals(this.value, value)) return;
                    Console.WriteLine($"Assigning value to {value}");
                    this.value = value;
                }
            }
            public Property() : this(default(T))
            {
                
            }

            public Property(T value)
            {
                this.value = value;
            }

            public static implicit operator T(Property<T> property)
            {
                return property.value;
            }

            public static implicit operator Property<T>(T value)
            {
                return new Property<T>(value);
            }

            public bool Equals(Property<T> other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return EqualityComparer<T>.Default.Equals(value, other.value);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Property<T>) obj);
            }

            public override int GetHashCode()
            {
                return value.GetHashCode();
            }

            public static bool operator ==(Property<T> left, Property<T> right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Property<T> left, Property<T> right)
            {
                return !Equals(left, right);
            }
        }

        public class Creature
        {
            private Property<int> agility = new Property<int>();

            public int Agility
            {
                get => agility.Value;
                set => agility.Value = value;
            }
        }
        static void Main(string[] args)
        {
            var c = new Creature();
            c.Agility = 10;
            c.Agility = 20;

        }
    }
}
