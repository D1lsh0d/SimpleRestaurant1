using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant1.Models
{
    public class ChickenOrder
    {
        private int _quantity;
        private bool _cooked;
        private int _cutUpCount;

        public ChickenOrder(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Quantity must be more than 0");
            }

            _quantity = quantity;
        }

        public int GetQuantity() => _quantity;

        public void CutUp()
        {
            if (_cutUpCount >= _quantity)
            {
                throw new Exception("Chickens ran out");
            }

            _cutUpCount++;
        }
        public void Cook()
        {
            if (_cooked)
            {
                throw new Exception("The chicken was already cooked");
            }

            _cooked = true;
        }
        
    }
}
