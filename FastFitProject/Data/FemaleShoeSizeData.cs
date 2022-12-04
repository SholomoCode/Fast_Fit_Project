using Fast_Fit_Final_Project.Model;
using Fast_Fit_Final_Project.Models;
using FastFitProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FastFit_Final_Project.Data
{
    public class FemaleShoeSizeData
    {

        static private string DATA_FILE = "Data/WomanShoeData.csv";

        static bool IsDataLoaded;

        static List<Country> AllCountrySizes;

        static private List<Shoe> TheUs = new List<Shoe>();
        static private List<Shoe> TheUk = new List<Shoe>();
        static private List<Shoe> TheEu = new List<Shoe>();
        static private List<Shoe> Australia = new List<Shoe>();
        static private List<Shoe> China = new List<Shoe>();
        static private List<Shoe> Japan = new List<Shoe>();



        static public List<Country> FindByValue(string value)
        {

            // load data, if not already loaded
            LoadData();

            List<Country> countriesSizes = new List<Country>();

            for (int i = 0; i < AllCountrySizes.Count; i++)
            {

                if (AllCountrySizes[i].Us.ToString().ToLower().Contains(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].Uk.ToString().ToLower().Contains(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].Eu.ToString().ToLower().Contains(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].Australia.ToString().ToLower().Contains(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].China.ToString().ToLower().Contains(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].Japan.ToString().ToLower().Contains(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }

            }

            return countriesSizes;
        }


        static private object FindExistingObjects(List<Shoe> countryList, string value) // this syntax migh be wrong
        {
            for (int i = 0; i < countryList.Count; i++)
            {
                object item = countryList[i];
                if (item.ToString().ToLower().Equals(value.ToLower()))
                {
                    return item;
                }
            }
            return null;
        }


        static private void LoadData()
        {
            if (AllCountrySizes == null || AllCountrySizes.Count == 0)
            {
                IsDataLoaded = false;
            }

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();


            using (StreamReader reader = File.OpenText(DATA_FILE))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArray = CSVRowToStringArray(line);
                    if (rowArray.Length > 0)
                    {
                        rows.Add(rowArray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            AllCountrySizes = new List<Country>();


            for (int i = 0; i < rows.Count; i++)
            {
                string[] row = rows[i];
                string inUsS5 = row[0];
                string inUk = row[1];
                string inEu = row[2];
                string inAu = row[3];
                string inCn = row[4];
                string inJp = row[5];

                Us newSizeUs = (Us)FindExistingObjects(TheUs, inUsS5);
                Uk newSizeUk = (Uk)FindExistingObjects(TheUk, inUk);
                Eu newSizeEu = (Eu)FindExistingObjects(TheEu, inEu);
                Australia newSizeAu = (Australia)FindExistingObjects(Australia, inAu); // fix these errors tomorrow
                China newSizeChina = (China)FindExistingObjects(China, inCn);
                Japan newSizeJapan = (Japan)FindExistingObjects(Japan, inJp);
                if (newSizeUs == null)
                {
                    newSizeUs = new Us(inUsS5);
                    TheUs.Add(newSizeUs); // fix errors tomorrow.
                }

                if(newSizeUk == null)
                {
                    newSizeUk = new Uk(inUk);
                    TheUk.Add(newSizeUk);
                }

                if (newSizeAu == null)
                {
                    newSizeAu = new Australia(inAu);
                    Australia.Add(newSizeAu);
                }

                if (newSizeEu == null)
                {
                    newSizeEu = new Eu(inEu);
                    TheEu.Add(newSizeEu);
                }

                if (newSizeChina == null)
                {
                    newSizeChina = new China(inCn);
                    China.Add(newSizeChina);
                }

                
                if (newSizeJapan == null)
                {
                    newSizeJapan = new Japan(inJp);
                    Japan.Add(newSizeJapan);
                }

                Country newCountry = new Country(newSizeJapan, newSizeEu, newSizeUk, newSizeAu, newSizeChina, newSizeUs );

                AllCountrySizes.Add(newCountry);
            }
            IsDataLoaded= true;
        }

        private static string[] CSVRowToStringArray(string row, char countrySeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            for (int i = 0; i < row.ToCharArray().Length; i++) // (char c in row.ToCharArray())
            {
                char c = row.ToCharArray()[i];

                if ((c == countrySeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();                                                            //THIS WHOLE CODE BLOCK!! Could be wrong.
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }
    }
}
