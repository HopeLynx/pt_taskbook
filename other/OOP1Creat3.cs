// File: "OOP1Creat3"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public abstract class Animal
        {
            public abstract string GetInfo();
        }

        public class Lion : Animal
        {
            string name;
            public Lion(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Lion " + name;
            }
        }

        public class Tiger : Animal
        {
            string name;
            public Tiger(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Tiger " + name;
            }
        }

        public class Leopard : Animal
        {
            string name;
            public Leopard(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Leopard " + name;
            }
        }

        public class Gorilla : Animal
        {
            string name;
            public Gorilla(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Gorilla " + name;
            }
        }

        public class Chimpanzee : Animal
        {
            string name;
            public Chimpanzee(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Chimpanzee " + name;
            }
        }

        public class Orangutan : Animal
        {
            string name;
            public Orangutan(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Orangutan " + name;
            }
        }

        // Implement the Tiger, Leopard, Gorilla,
        //   Orangutan and Chimpanzee descendant classes

        public abstract class AnimalCreator
        {
            protected abstract Animal CreateAnimal(int ind, string name);
            public Animal[] GetZoo(int[] inds, string[] names)
            {
                Animal[] zoo = new Animal[inds.Length];
                for (int i = 0; i < zoo.Length; i++)
                    zoo[i] = CreateAnimal(inds[i], names[i]);
                return zoo;
            }
        }

        public class CatCreator: AnimalCreator {
            protected override Animal CreateAnimal(int ind, string name) {
                if (ind == 0)
                    return new Lion(name);
                else if (ind == 1)
                    return new Tiger(name);
                else
                    return new Leopard(name);
            }
        }

        public class ApeCreator: AnimalCreator {
            protected override Animal CreateAnimal(int ind, string name) {
                if (ind == 0)
                    return new Gorilla(name);
                else if (ind == 1)
                    return new Orangutan(name);
                else
                    return new Chimpanzee(name);
            }
        }

        // Implement the CatCreator and ApeCreator descendant classes

        public static void Solve()
        {
            Task("OOP1Creat3");

            int[] indxs = new int[4];
            string[] names = new string[4];

            for(int i = 0; i < 4; ++i){
                indxs[i] = GetInt();
                names[i] = GetString();
            }

            Animal[] cats = new CatCreator().GetZoo(indxs, names);
            Animal[] apes = new ApeCreator().GetZoo(indxs, names);

            for (int i = 0; i < 4; ++i) {
                Put(cats[i].GetInfo());
            }

            for (int i = 0; i < 4; ++i) {
                Put(apes[i].GetInfo());
            }
        }
    }
}
