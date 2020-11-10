using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group_IT_VM.Models
{
    public class Denominations
    {
        public int ID { set; get; }
        public double Value { set; get; }

        public Denominations()
        {
            ID = -1;
            Value = 0;
        }

        public Denominations(int iD, double value)
        {
            ID = iD;
            Value = value;
        }
        public string toString() {
            return "Load R" + Value;
        }
    }
}