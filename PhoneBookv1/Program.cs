using PhoneBookv1.Models;
using System;
using System.Collections.Generic;

namespace PhoneBookv1
{
    class Program
    {
        static void Main(string[] args)
        {
            PBUtils pb = new PBUtils();

           ListAllRecords(pb);

            Console.WriteLine("QueryOne()...");
            PhoneBookEntry pbe = pb.QueryOne("222");
            if (pbe !=null)
            {
                Console.WriteLine("Found it: "+pbe.ToString());
            }
            else
            {
                Console.WriteLine("QueryOne() found no record!");
            }


            Console.WriteLine("QueryByName()...");
            List<PhoneBookEntry> nameRecords = (List<PhoneBookEntry>)pb.QueryByName("Jim");

            if (nameRecords.Count > 0)
            {
                foreach (PhoneBookEntry p in nameRecords)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("QueryByName() found no record!");
            }

            PhoneBookEntry pbeUpdate = new PhoneBookEntry() { Number = "222", Name = "Mary", Address="Galway" };
            pb.Update(pbeUpdate);
            ListAllRecords(pb);
        }

        private static void ListAllRecords(PBUtils pb)
        {
            Console.WriteLine("QueryAll()...");
            List<PhoneBookEntry> records = (List<PhoneBookEntry>)pb.QueryAll();

            if (records.Count > 0)
            {
                foreach (PhoneBookEntry p in records)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("QueryAll() found no records!");
            }
            Console.WriteLine();
        }

        
    }
}
