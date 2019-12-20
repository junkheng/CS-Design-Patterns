using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        public class Creature
        {
            public string name;
            public int Attack, Defense;

            public Creature(string name, int attack, int defense)
            {
                this.name = name;
                Attack = attack;
                Defense = defense;
            }

            public override string ToString()
            {
                return $"{nameof(name)}: {name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class CreatureModifier
        {
            protected Creature creature;
            protected CreatureModifier next; // linked list

            public CreatureModifier(Creature creature)
            {
                this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
            }

            public void Add(CreatureModifier cm)
            {
                if (next != null) next.Add(cm);
                else next = cm;
            }

            public virtual void Handle() => next?.Handle();
        }

        public class DoubleAttackModifier : CreatureModifier
        {
            public DoubleAttackModifier(Creature creature) : base(creature)
            {
            }

            public override void Handle()
            {
                Console.WriteLine($"Doubling {creature.name}'s attack");
                creature.Attack *= 2;
                base.Handle();
            }
        }

        public class NoBonusesModifier : CreatureModifier
        {
            public NoBonusesModifier(Creature creature) : base(creature)
            {
            }

            public override void Handle()
            {
                //
            }
        }

        static void Main(string[] args)
        {
            var goblin = new Creature("Goblin", 2, 2);
            Console.WriteLine(goblin);
            
            var root = new CreatureModifier(goblin);
            root.Add(new NoBonusesModifier(goblin));
            Console.WriteLine($"Attempting to double {goblin.name}'s attack!");
            root.Add(new DoubleAttackModifier(goblin));
            Console.WriteLine("Modifier nullified!");

            root.Handle(); // checks for modifiers
            Console.WriteLine(goblin);
        }
    }
}
