using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Создайте класс, который позволит выполнять мониторинг ресурсов, используемых программой. 
             * Используйте его в целях наблюдения за работой программы, а именно: 
             * пользователь может указать приемлемые уровни потребления ресурсов (памяти), а методы класса позволят выдать предупреждение, 
             * когда количество реально используемых ресурсов приблизиться к максимально допустимому уровню. 
             */

            Console.Write("Укажите максимальный размер памяти в Кб для вывода сообщения: ");
            int.TryParse(Console.ReadLine(), out int memoryItem);

            Thread thread = new Thread(MyMethod);
            thread.Start();

            while (true)
            {
                var totalMemory = GC.GetTotalMemory(false) / 1024;
                if (totalMemory > memoryItem)
                {
                    Console.WriteLine("Ресурсы на исходе!");
                    thread.Abort();
                    break;
                }
                else
                {
                    Console.WriteLine("Потребление памяти {0} KB", totalMemory);
                    Thread.Sleep(100);
                }

            }

            Console.ReadKey();
        }

        static void MyMethod()
        {
            OtherObject[] objects = new OtherObject[10000];

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = new OtherObject();

                Thread.Sleep(10);
            }
        }
    }

    class OtherObject
    {
        byte[] array = new byte[1024 * 10];
    }




}
