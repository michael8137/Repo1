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
            LoadHumphries(ref lstInputDetails);

        }

        private static void LoadHumphries(ref List<InputDetails> lstInputDetails)
        {
            string[] humphriesFileDetails = File.ReadAllLines("C:\\Users\\micha\\OneDrive\\Documents\\Jobs_2021_2\\BuildXact\\Coding Test\\buildxact-supplies-price-lister-830fc692c659");
            int lineCount = humphriesFileDetails.Length;
            
            if (lineCount > -1)
            { 
                for (int iLoop = 1; iLoop < lineCount; iLoop++)
                {
                    InputDetails inputLoop = new InputDetails();
                    string humphriesLine = humphriesFileDetails[iLoop];
                    string[] humphriesLineParsed = humphriesLine.Split();
                    string providerId = humphriesLineParsed[0];
                    string description = humphriesLineParsed[1];
                    string sPrice = humphriesLineParsed[3];
                    decimal dPrice = 0M;
                    bool bTestConvert = decimal.TryParse(sPrice, out dPrice);

                    inputLoop.ProviderId = providerId;
                    inputLoop.Description = description;
                    inputLoop.Price = dPrice;

                    lstInputDetails.Add(inputLoop);
                }
            } 
        }

        protected class InputDetails
        {
            /*private string _providerId = string.Empty;
            private string _description = string.Empty;
            private decimal _price = 0M;*/

           /* private string ProviderId
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
            }*/
        }


    }
}
