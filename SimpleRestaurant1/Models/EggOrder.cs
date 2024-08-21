using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant1.Models
{
    public class EggOrder
    {
        private int _quantity;
        private int? _quality = null;
        private int _callCount = 0;
        private bool _cooked;
        private int rottenEggsCount = 0;
        public int RottenEggsCount { get => rottenEggsCount; }

        public EggOrder(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Quantity must be more than 0");
            }

            _quantity = quantity;

            Random rnd = new();
            _quality = rnd.Next(101);
        }

        public int GetQuantity() => _quantity;

        public int? GetQuality() 
        {
            _callCount++;

            if (_callCount % 2 == 0)
            {
                return null;
            }

            return _quality;
        }

        public void Crack()
        {
            if (GetQuality() < 25)
            {
                rottenEggsCount++;
                throw new Exception("Rotten egg");
            }
        }

        public void DiscardShell()
        {

        }

        public void Cook()
        {
            if (_cooked)
            {
                throw new Exception("The order was already cooked");
            }

            _cooked = true;
        }

    }
}
