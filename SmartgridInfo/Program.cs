using System;
using SmartgridInfo.Models;
using SmartgridInfo.Repository;
using SmartgridInfo.UnitOfWork;

namespace SmartgridInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SmartGridRepository();

            var testitem = new SmartGrid()
            {
                SmartGridId = "Village",
                TotalGeneratedPower = 14, //KiloWatthora
                TotalUsedPower = 9
            };


            var unitofwork = new UnitOfWork.UnitOfWork(db);

            unitofwork.AddSmartGridInfo(testitem);

            

            Console.WriteLine("SmartGrid: " + testitem.SmartGridId);
            Console.WriteLine("SmartGrid GeneratedPower: " + unitofwork.GetSmartGridGeneratedPower(testitem.SmartGridId));
            Console.WriteLine("SmartGrid UsedPower: " + unitofwork.GetSmartGridUsedPower(testitem.SmartGridId));

            Console.ReadKey();

            unitofwork.UpdatedSmartGridGeneratedPower(testitem.SmartGridId,15);

            Console.WriteLine("SmartGrid GeneratedPower: " + unitofwork.GetSmartGridGeneratedPower(testitem.SmartGridId));

            Console.ReadKey();

            unitofwork.UpdatedSmartGridUsedPower(testitem.SmartGridId,15);


            Console.WriteLine("SmartGrid GeneratedPower: " + unitofwork.GetSmartGridUsedPower(testitem.SmartGridId));

            Console.ReadKey();


            var readstring = unitofwork.GetSmartGridInfo(testitem.SmartGridId).ToString();

            Console.WriteLine(readstring);

            Console.WriteLine("End of test");
            Console.ReadKey();
        }

        
    }
}
