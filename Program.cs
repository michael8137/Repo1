using System;
using System.Collections.Generic;
using System.IO;

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
            List<InputDetails> lstInputDetails = new List<InputDetails>();

        }

        private static void LoadHumphries()
        {
            string[] humphriesFileDetails = File.ReadAllLines("C:\\Users\\micha\\OneDrive\\Documents\\Jobs_2021_2\\BuildXact\\Coding Test\\buildxact-supplies-price-lister-830fc692c659");

        }

        private class InputDetails
        {
            private string _providerId = string.Empty;
            private string _description = string.Empty;
            private decimal _price = 0M;

            private string ProviderId
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

            private string Description
            {
                get
                {
                    return _description;
                }
                set
                {
                    _description = value;
                }
            }

            private decimal Price
            {
                get
                {
                    return _price;
                }
                set
                {
                    _price = value;
                }
            }
        }
    }
}
