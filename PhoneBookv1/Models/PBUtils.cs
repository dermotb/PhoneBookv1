using System.Collections.Generic;
using System.Linq;

namespace PhoneBookv1.Models
{
    class PBUtils
    {
        PhoneBookContext db;

        public PBUtils()
        {
            db = new PhoneBookContext();
            db.Database.EnsureCreated();
            if (db.PhoneBook.Count() == 0)
            {
                SeedDB();
            }
        }

        public void Add(PhoneBookEntry entry)
        {
            db.PhoneBook.Add(entry);
            db.SaveChanges();
        }

        public void Update(PhoneBookEntry newValues)
        {
            var record = db.PhoneBook.Find(newValues.Number);
            if (record != null)
            {
                record.Address = newValues.Address;
                record.Name = newValues.Name;
                db.SaveChanges();
            }
        }

        public void Delete(string number)
        {
            var record = db.PhoneBook.Find(number);
            if (record != null)
            {
                db.PhoneBook.Remove(record);
                db.SaveChanges();
            }
        }

        public PhoneBookEntry QueryOne(string number)
        {
            var record = db.PhoneBook.Find(number);
            if (record != null)
            {
                return record;
            }
            return null;
        }

        public List<PhoneBookEntry> QueryAll()
        {
            return db.PhoneBook.ToList();
        }

        public List<PhoneBookEntry> QueryByName(string name)
        {
            return db.PhoneBook.Select(p => p).Where(p => p.Name.Contains(name)).ToList();
        }

        private void SeedDB()
        {
            PhoneBookEntry pbe = new PhoneBookEntry() { Number = "222", Name = "Jane", Address = "Das" };
            PhoneBookEntry pbe1 = new PhoneBookEntry() { Number = "222444", Name = "Jimmy", Address = "Das Kapital" };
            PhoneBookEntry pbe2 = new PhoneBookEntry() { Number = "555", Name = "Jemmy", Address = "Dublin" };
            PhoneBookEntry pbe3 = new PhoneBookEntry() { Number = "123", Name = "James", Address = "Australia" };
            PhoneBookEntry pbe4 = new PhoneBookEntry() { Number = "7789", Name = "Jose", Address = "West Central" };
            db.Add(pbe);
            db.Add(pbe1);
            db.Add(pbe2);
            db.Add(pbe3);
            db.Add(pbe4);
            db.SaveChanges();
        }
    }
}
