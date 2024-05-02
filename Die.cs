using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        // Instantiates private variable
        private int _value;

        // Getter and Setter used to pass private value to method.
        public int Value
        {
            get
            {
                return _value;
            }
            private set
            {
                _value = value;
            }
        }

        // Generates and returns an integer between 1 and 6 inclusive 
        public int Roll()
        {
            Random random = new Random();
            _value = random.Next(1, 7);
            return _value;
        }

    }
}