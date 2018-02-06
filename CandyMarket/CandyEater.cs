using System;
using System.Collections.Generic;
using System.Text;

namespace CandyMarket
{
    class CandyEater
    {
        readonly DatabaseContext _db;

        public string Name { get; set; }

        public CandyEater(string name, DatabaseContext db)
        {
            Name = name;
            _db = db;
        }

        public void AddCandy(CandyType typeOfCandy, int howMany)
        {
            _db.SaveNewCandy(Name, typeOfCandy, howMany);
        }

        public void GiveCandy(CandyType type, string receiver)
        {
            _db.RemoveCandy(Name, type);
            _db.SaveNewCandy(receiver, type, 1);
        }

        public void EatCandy(CandyType type, string receiver)
        {
            _db.RemoveCandy(Name, type);
            _db.SaveNewCandy(receiver, type, 1);
        }
    }
}
