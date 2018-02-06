using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFrameworkDz02
{
    class Program
    {
        static McsDB db = new McsDB();
        static void Main(string[] args)
        {
            //Task1();
            Task2();
        }

        static void Task1()
        {
            //Связать таблицы newEquipment и TablesModel с TablesManufacturer. 
            //Вывести на экран следующую информацию: Гаражный номер машины, наименование модели машины, 
            //серийный номер машины, наименование производителя. 
            //a.Написать метод где используется «Метод прямой загрузки»
            //b.Написать метод где используется «Метод явной загрузки»
            //c.Написать метод где используется «Метод отложенной загрузки


            //var query = db.newEquipment.Select(s => new
            //{
            //    s.intGarageRoom,
            //    s.strManufYear,
            //    s.TablesManufacturer.strName

            //}).ToList();


            //foreach(var item in query)
            //{
            //    Console.WriteLine(item.intGarageRoom + " - " + item.strManufYear);
            //}

            //var query2 = db.newEquipment.Include(w => w.TablesModel).Select(s => new
            //{
            //    s.strSerialNo,
            //    s.strManufYear,
            //    s.TablesManufacturer.strName

            //}).ToList();

            var query3 = db.TablesManufacturer.FirstOrDefault(w => w.intManufacturerID == 8);

            db.Entry(query3).Collection(col => col.newEq).Load();


            foreach(newEquipment item in query3.newEq)
            {
                Console.WriteLine(item.strSerialNo);
            }
        }

        static void Task2()
        {
            //Используя инициализацию базы данных, создать таблицу, если ее нет, 
            //«UserHistory», затем произвести запись о посещении пользователя, 
            //указать время входа, IPадрес, время выхода с программы.

            foreach(var item in db.newEquipment)
            {
                Console.WriteLine(item.strSerialNo + " , " + item.strManufYear + "  ");
            }
            
        }
    }
}
