
using FastFitProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;

namespace FastFitProject.Data
{
    public class MaleShoeSizeData
    {

        static private string DATA_FILE = "Data/MaleShoeData.csv";

        static bool IsDataLoaded;

        static List<Country> AllCountrySizes;

        static private List<Shoe> TheUs = new List<Shoe>();
        static private List<Shoe> TheUk = new List<Shoe>();
        static private List<Shoe> TheEu = new List<Shoe>();
        static private List<Shoe> Australia = new List<Shoe>();
        static private List<Shoe> China = new List<Shoe>();
        static private List<Shoe> Japan = new List<Shoe>();

        static public List<Country> FindAll()
        {
            LoadData();
            return new List<Country>(AllCountrySizes);
        }

        static public List<Country> FindByCountryAndSize(string countryName, string size)
        {
            LoadData();

            List<Country> countryList = new List<Country>();

            if (size.ToLower().Equals("all"))
            {
                return FindAll();
            }

            if (countryName != null)
            {
                countryList = FindByValue(size);
                return countryList;
            }

            for (int i = 0; i < AllCountrySizes.Count; i++)
            {
                Country country = AllCountrySizes[i];
                string aValue = GetFieldValue(country, countryName);

                if (aValue != null && aValue.ToLower().Equals(size.ToLower()))
                {
                    countryList.Add(country);
                }
            }

            return countryList;
        }


        static public string GetFieldValue(Country country, string countryName)
        {
            string theValue;
            if (countryName.Equals("us"))
            {
                theValue = country.Us.ToString();
            }
            else if (countryName.Equals("uk"))
            {
                theValue = country.Uk.ToString();
            }
            else if (countryName.Equals("eu"))
            {
                theValue = country.Eu.ToString();
            }
            else if (countryName.Equals("australia"))
            {
                theValue = country.Australia.ToString();
            }
            else if (countryName.Equals("china"))
            {
                theValue = country.China.ToString();
            }
            else
            {
                theValue = country.Japan.ToString();
            }

            return theValue;
        }


        static public List<Country> FindByValue(string value)
        {

            // load data, if not already loaded
            LoadData();

            List<Country> countriesSizes = new List<Country>();

            for (int i = 0; i < AllCountrySizes.Count; i++)
            {

                if (AllCountrySizes[i].Us.ToString().Equals(value))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                /*else if (AllCountrySizes[i].Uk.ToString().ToLower().Equals(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].Eu.ToString().ToLower().Equals(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].Australia.ToString().ToLower().Equals(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].China.ToString().ToLower().Equals(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }
                else if (AllCountrySizes[i].Japan.ToString().ToLower().Equals(value.ToLower()))
                {
                    countriesSizes.Add(AllCountrySizes[i]);
                }*/

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
                string inUs = row[0];
                string inUk = row[1];
                string inEu = row[2];
                string inAu = row[3];
                string inCn = row[4];
                string inJp = row[5];

                Us newSizeUs = (Us)FindExistingObjects(TheUs, inUs);
                Uk newSizeUk = (Uk)FindExistingObjects(TheUk, inUk);
                Eu newSizeEu = (Eu)FindExistingObjects(TheEu, inEu);
                Australia newSizeAu = (Australia)FindExistingObjects(Australia, inAu);
                China newSizeChina = (China)FindExistingObjects(China, inCn);
                Japan newSizeJapan = (Japan)FindExistingObjects(Japan, inJp);
                if (newSizeUs == null)
                {
                    newSizeUs = new Us(inUs);
                    TheUs.Add(newSizeUs); 
                }

                if (newSizeUk == null)
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

                Country newCountry = new Country(newSizeJapan, newSizeEu, newSizeUk, newSizeAu, newSizeChina, newSizeUs);

                AllCountrySizes.Add(newCountry);
            }
            IsDataLoaded = true;
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