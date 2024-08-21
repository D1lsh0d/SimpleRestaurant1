using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SimpleRestaurant1.Models
{
    public class Employee
    {
        private object _order;
        private int _requestsCount = 0;
        public Employee()
        {
            
        }
        public object NewRequest(int quantity, string meal)
        {
            _requestsCount++;

            // simulating employee forgetting 1/3 of the time
            if (_requestsCount % 3 == 0) 
            {
                // reversing switch
                switch (meal)
                {
                    case "Egg":
                        _order = new ChickenOrder(quantity);
                        return _order;

                    case "Chicken":
                        _order = new EggOrder(quantity);
                        return _order;

                    default:
                        throw new Exception("No such meal");
                }
            }
            else
            {
                // correct switch
                switch (meal)
                {
                    case "Egg":
                        _order = new EggOrder(quantity);
                        return _order;

                    case "Chicken":
                        _order = new ChickenOrder(quantity);
                        return _order;

                    default:
                        throw new Exception("No such meal");
                }
            }   

        }
        public object Inspect(object order)
        {
            if (order is EggOrder)
            {
                EggOrder eggOrder = (EggOrder)order;

                if (eggOrder.GetQuality() is null)
                {
                    return "Employee forgot the quality";
                }
                else { return eggOrder.GetQuality(); }
                
            }
            else if (order is ChickenOrder)
            {
                return "No inspection required on chicken";
            }
            else { throw new ArgumentNullException(); }     // if order is null - there were'nt any requests yet

        }
        public object CopyRequest() 
        {
            if (_order is EggOrder)
            {
                EggOrder eggOrder = (EggOrder)_order;
                return eggOrder;
            }
            else if (_order is ChickenOrder)
            {
                ChickenOrder chickenOrder = (ChickenOrder)_order;
                return chickenOrder;
            }
            else { throw new ArgumentNullException(); }     // if order is null - there were'nt any requests yet

        }

        public string PrepareFood()
        {
            if (_order is EggOrder)
            {
                EggOrder eggOrder = (EggOrder)_order;

                for (int i = 0; i < eggOrder.GetQuantity(); i++)
                {
                    eggOrder.Crack();
                    eggOrder.DiscardShell();
                }

                eggOrder.Cook();

                return "The eggs have just been cooked, " 
                    + eggOrder.RottenEggsCount.ToString() + " rotten eggs were found";
            }
            else if (_order is ChickenOrder)
            {
                ChickenOrder chickenOrder = (ChickenOrder)_order;

                for (int i = 0; i < chickenOrder.GetQuantity(); i++)
                {
                    chickenOrder.CutUp(); 
                }

                chickenOrder.Cook();

                return "Chicken order is ready!";
            }
            else { throw new ArgumentNullException(); }     // if order is null - there were'nt any requests yet
        }

    }
}
