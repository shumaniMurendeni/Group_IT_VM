using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vending_Machine.Models
{
    public class Item
    {
        public int ID;
        public string Name;
        public double Price;
        public string Image;
        public int Units;
        public double balance = 0;
        private static double Balance = 0;
        
        public Item(int iD, string name, double price, string image, int units)
        {
            ID = iD;
            Name = name;
            Price = price;
            Image = image;
            Units = units;
            balance = 0;
        }

        internal int getID()
        {
            return ID;
        }

        internal int getUnits()
        {
            return Units;
        }

        public string AddUnits(int nUnits) {
            if (Units + nUnits >= 0) {
                Units += nUnits;
                return "Done";
            }
            return "Not enough stock";
        }

        public double getCost(int nUnits) {
            return nUnits * Price;
        }
        public double getBalance()
        {
            balance = Balance;
            return balance;
        }
        public void setBalance(double value)
        {
            Balance = value;
            balance = value;
        }
        public bool equals(Item item) {
            return ID == item.ID;
        }
        public bool equals(string name) {
            return Name == name;
        }
        public bool equals(int id)
        {
            return ID == id;
        }
        public string toString() {
            string res = Name + " (costs R" + Price+" )";
            //if (Units <= 0) { return res + " and is out of stock)"; }
            //else { return res + " and has " + Units + " left)"; }
            return res;
        }
        public double getPrice() {
            if (Units <= 0) { return 0; }
            else { return Price; }
        }
        public void UpdateBalance(double value) {
            Balance += value;
            balance += value;
            balance = Balance;
        }
    }
}