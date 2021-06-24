using System;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your solution begins here
            GatherInputs();
        }

        private static void GatherInputs()
        {


        }

        private class InputDetails
        {
            private decimal _providerId = 0M;

            private decimal ProviderId
            {
                get
                {
                    return _providerId;
                }
                set
                {
                    _providerId = value;
                }
            }

        }
    }
}
