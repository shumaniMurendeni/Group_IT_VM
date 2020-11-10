using Group_IT_VM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vending_Machine.Models; 

namespace Group_IT_VM.Controllers
{
    public class VMController : Controller
    {
        List<Item> ItemsList;
        Account Credits;
        List<Group_IT_VM.Models.Denominations> denominations;

        public VMController() {
            Credits = new Account();
            ItemsList = new List<Item>();
            ItemsList.Add(new Item(0, "KitKat", 10.5, "", 15));
            ItemsList.Add(new Item(1, "Dark KitKat", 11.00, "", 10));
            ItemsList.Add(new Item(2, "White KitKat", 10.5, "", 5));
            ItemsList.Add(new Item(3, "Coke", 18.00, "", 8));
            ItemsList.Add(new Item(4, "Coke Zero", 15.00, "", 20));
            ItemsList.Add(new Item(5, "Diet Coke", 15.00, "", 15));
            ItemsList.Add(new Item(6, "Peanuts", 20.00, "", 5));
            ItemsList.Add(new Item(7, "Peanuts with Raisins", 25, "", 3));
            ItemsList.Add(new Item(8, "Raisins", 15, "", 15));
            ItemsList.Add(new Item(9, "Balance", 0, "", 0));
            denominations = new List<Group_IT_VM.Models.Denominations>();
            denominations.Add(new Group_IT_VM.Models.Denominations(0, 0.5));
            denominations.Add(new Group_IT_VM.Models.Denominations(1, 1));
            denominations.Add(new Group_IT_VM.Models.Denominations(2, 2));
            denominations.Add(new Group_IT_VM.Models.Denominations(3, 5));

        }

        // GET: VM
        public ActionResult Index()
        {
            Tuple<List<Item>, Item> tuple;
            tuple = new Tuple<List<Item>, Item>(ItemsList, ItemsList[1]);
            return View("Items1", tuple);
        }
        [HttpPost]
        public ActionResult OnSelectItem(string ItemNumer)
        {
            BuyItem(Int32.Parse(ItemNumer));
            return PartialView("~/Views/VM/Balance.cshtml",ItemsList[9]);
        }
        [HttpPost]
        public ActionResult OnclickItem(string DenomNumer) {
            UpdateCredits(denominations[Int32.Parse(DenomNumer)].Value);
            return PartialView("~/Views/VM/Balance.cshtml",ItemsList[9]);
        }

        private void UpdateCredits(double value)
        {
            ItemsList[9].UpdateBalance(value);
        }

        private void BuyItem(int itemNumber) {
            if (Credits.Balance >= ItemsList[itemNumber].Price)
            {
                ItemsList[9].setBalance(ItemsList[9].getBalance()-ItemsList[itemNumber].Price);
                ItemsList[itemNumber].setBalance(ItemsList[9].getBalance());
                ItemsList[itemNumber].AddUnits(-1);
            }
        }
    }
}