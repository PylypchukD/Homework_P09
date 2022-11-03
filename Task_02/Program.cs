using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            * Создайте свой класс, объекты которого будут занимать много места в памяти (например, в коде класса будет присутствовать большой массив) и реализуйте для этого класса формализованный шаблон очистки.
            */

            MyClass myClass = new MyClass();
            Console.WriteLine($"Поколение объекта {GC.GetGeneration(myClass)}");

            // Delay.
            Console.ReadKey();

        }

        class MyClass : IDisposable
        {
            Array myArray = new int[100_000_000];
            public MyClass()
            {
                Console.WriteLine(this.GetHashCode());
            }
            ~MyClass()
            {
                Dispose(false);
                Console.WriteLine("Объект " + this.GetHashCode() + " удален");
            }

            private bool disposed = false;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (disposed) return;
                
                if (disposing)
                {
                    
                }
                disposed = true;
            }
        }
    }
}
