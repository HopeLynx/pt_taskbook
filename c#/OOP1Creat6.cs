// File: "OOP1Creat6"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        /*
        Для языка C# задачник Programming Taskbook выполняет тестирование
        при ОДНОКРАТНОМ запуске программы путем МНОГОКРАТНОГО вызова
        ее функции Solve. Так как между вызовами функции Solve содержимое
        статических полей классов сохраняется, в случае данного задания
        это приведет к ошибочным результатам, начиная со ВТОРОГО тестового
        испытания. Чтобы избежать сообщения об ошибке, следует реализовать
        в классах Singleton, Doubleton и Tenton вспомогательный статический
        метод Reset, который ОБНУЛЯЕТ все статические ссылки (uniqueInstance
        для класса Singleton, элементы массива instances для классов Doubleton
        и Tenton), и вызывать методы Reset для этих классов после вывода
        всех результирующих данных.
        */

        public abstract class BaseClass
        {
            int data;
            public void IncData(int increment)
            {
                data += increment;
            }
            public int GetData()
            {
                return data;
            }

            public abstract void Reset();
        }

        public class Singleton : BaseClass
        {
            static Singleton uniqueInstance;
            Singleton() {}
            public override void Reset()
            {
                uniqueInstance = null;
            }

            public static Singleton getInstance() {
                if (uniqueInstance == null)
                    uniqueInstance = new Singleton();
                return uniqueInstance;
            }
    
            public static int instanceCount(){
                return (uniqueInstance != null) ? 1 : 0;
            }
            // ЗАВЕРШИТЕ РЕАЛИЗАЦИЮ КЛАССА Singleton
        }

        public class Doubleton : BaseClass
        {
            static Doubleton[] instances = new Doubleton[2];
            Doubleton() {}
            public override void Reset()
            {
                instances[0] = instances[1] = null;
            }

            public static Doubleton getInstance(int ind) {
                if (ind < 2 ) {
                    if(instances[ind] == null){
		        		//for (int i=0;i<2;i++)
                        instances[ind] = new Doubleton();
                    }
                    return instances[ind];
                }
                return null;
            }

            public static int instanceCount(){
                int ans = 0;
                for (int i=0;i<2;i++) if (instances[i] != null) ans++;
                return ans;
            }
                // ЗАВЕРШИТЕ РЕАЛИЗАЦИЮ КЛАССА Doubleton
            }

        public class Tenton : BaseClass
        {
            static Tenton[] instances = new Tenton[10];
            Tenton() {}
            public override void Reset()
            {
                for (int i = 0; i < instances.Length; i++)
                    instances[i] = null;
            }

            public static Tenton getInstance(int ind) {
                Show("!!"); Show(ind);
                if (ind < 10 ) {
                    if(instances[ind] == null){
                        instances[ind] = new Tenton();
                        Show("_");Show(ind);
                    }
                    return instances[ind];
                }
                return null;
            }

            public static int instanceCount(){
                int ans = 0;
                for (int i=0;i<10;i++) if (instances[i] != null) ans++;
                return ans;
            }
            // ЗАВЕРШИТЕ РЕАЛИЗАЦИЮ КЛАССА Tenton
        }

        public static void Solve()
        {
            Task("OOP1Creat6");

            int n = GetInt();
            BaseClass[] ans = new BaseClass [n];
            for (int i=0;i<n;i++){
                string tmp = GetString();
                if (tmp[0]=='S')  ans[i] = Singleton.getInstance();
                else if (tmp[0]=='D') ans[i] = Doubleton.getInstance(tmp[1]-'0'-1);
                else if (tmp[0]=='T') ans[i] = Tenton.getInstance(tmp[1]-'0');
            }
            Put(Singleton.instanceCount(), Doubleton.instanceCount(), Tenton.instanceCount());
            Show("i'm alive");

            int k = GetInt();
            for (int i=0;i<k;i++){
                int tmp1 = GetInt();
                int tmp2 = GetInt();
                Show(tmp1);Show(tmp2);
                ans[tmp1].IncData(tmp2);
            }

            for (int i=0;i<n;i++) {
                Put(ans[i].GetData());
                ans[i].Reset();
            }
        }
    }
}
