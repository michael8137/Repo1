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
            string[] humphriesFileDetails = File.ReadAllLines("C:\\Users\\micha\\OneDrive\\Documents\\Jobs_2021_2\\BuildXact\\Coding Test\\buildxact-supplies-price-lister-830fc692c659\\humphries.csv");
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

        private static void LoadMegaCorp(ref List<InputDetails> lstInputDetails)
        {
            string megaCorpDetails = File.ReadAllText("C:\\Users\\micha\\OneDrive\\Documents\\Jobs_2021_2\\BuildXact\\Coding Test\\buildxact-supplies-price-lister-830fc692c659\\humphries.csv");
            //var lstMegaCorp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Partners>>(megaCorpDetails);
            List<Partners> lstMegaCorpDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Partners>>(megaCorpDetails);

        }

        protected class InputDetails
        {

            public string ProviderId { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
           
        }

        protected class Partners 
        {
            public string name { get; set; }
            public string partnerType { get; set; }
            public string partnerAddress { get; set; }
            public Supplies suppliesDetails { get; set; }
        }

        protected class Supplies
        {
            public int id { get; set; }
            public string description { get; set; }
            public string uom { get; set; }
            public int priceInCents { get; set; }
            public string providerId { get; set; }
            public string materialType { get; set; }
        }
    }
}
