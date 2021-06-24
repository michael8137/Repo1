using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your solution begins here
            List<InputDetails> lstInputDetails = new List<InputDetails>();

            GatherInputs(ref lstInputDetails);
            WriteInputs(lstInputDetails);
        }

        private static void WriteInputs(List<InputDetails> lstInputDetails)
        {
            int iCount = lstInputDetails.Count;

            for (int iLoop = 0; iLoop < iCount; iLoop++)
            {
                InputDetails inputLoop = lstInputDetails[iLoop];
                StringBuilder sbDetails = new StringBuilder();
                string details = string.Empty;

                sbDetails.Append(inputLoop.ProviderId);
                sbDetails.Append(", ");
                sbDetails.Append(inputLoop.Description);
                sbDetails.Append(", $");
                sbDetails.Append(inputLoop.Price);

                details = sbDetails.ToString();
                Console.WriteLine(details);
            }

        }

        private static void GatherInputs(ref List<InputDetails> lstInputDetails)
        {
            LoadHumphries(ref lstInputDetails);
            LoadMegaCorp(ref lstInputDetails);
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
                    string sPrice = humphriesLineParsed[2];
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
            InputDetails inputLoop = new InputDetails();
            string megaCorpDetails = File.ReadAllText("C:\\Users\\micha\\OneDrive\\Documents\\Jobs_2021_2\\BuildXact\\Coding Test\\buildxact-supplies-price-lister-830fc692c659\\megacorp.json");
            List<Partners> lstMegaCorpDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Partners>>(megaCorpDetails);
            foreach (Partners partner in lstMegaCorpDetails)
            {
                Supplies[] suppliesLoop = partner.suppliesDetails;
                int iCount = suppliesLoop.Length;
                if (iCount > -1)
                {
                    for (int iLoop = 0; iLoop < iCount; iCount++)
                    {
                        Supplies suppLoop = suppliesLoop[iLoop];
                        inputLoop.ProviderId = suppLoop.providerId;
                        inputLoop.Description = suppLoop.description;
                        int iPrice = suppLoop.priceInCents;
                        decimal dPrice = iPrice / 100;
                        inputLoop.Price = dPrice;

                        lstInputDetails.Add(inputLoop);
                    }
                }
            }
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
            public Supplies[] suppliesDetails { get; set; }
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
