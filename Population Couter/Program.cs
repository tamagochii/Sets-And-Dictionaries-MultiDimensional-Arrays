using System;
using System.Collections.Generic;
using System.Linq;
namespace Population_Couter
{
    class Program
    {
        static void Main()
        {
            var CountriesAndCities = new Dictionary<string, Dictionary<string, long>>();
            var CountriesTotalPopulation = new Dictionary<string, long>();
            var Input = Console.ReadLine();

            while (Input != "report")
            {
                var FirstPipe = Input.IndexOf('|');
                var SecondPipe = Input.LastIndexOf('|');

                var City = Input.Substring(0, FirstPipe);
                var Country = Input.Substring(FirstPipe + 1, SecondPipe - FirstPipe -1 );
                var Population = long.Parse(Input.Substring(SecondPipe + 1));

                if (!CountriesAndCities.ContainsKey(Country))
                {
                    CountriesAndCities.Add(Country, new Dictionary<string, long>());
                    CountriesAndCities[Country].Add(City, Population);
                    CountriesTotalPopulation.Add(Country, Population);

                }
                else
                {
                    if (!CountriesAndCities[Country].ContainsKey(City))
                    {
                        CountriesAndCities[Country][City] = 0;
                    }

                    CountriesAndCities[Country][City] += Population;
                    CountriesTotalPopulation[Country] += Population;
                }

                Input = Console.ReadLine();
            }

            //Countries should be ordered by their total population descending order 
            CountriesTotalPopulation = CountriesTotalPopulation
                                       .OrderByDescending(x => x.Value)
                                       .ToDictionary(x => x.Key, x => x.Value);


            //the cities should be ordered by the same criterion. If two countries/cities have 
            //the same population, keep them in the order in which they were entered.

            foreach (var country in CountriesTotalPopulation.Keys)
            {
                Console.WriteLine($"{country} (total population: {CountriesTotalPopulation[country]})");


                CountriesAndCities[country] = CountriesAndCities[country]
                                              .OrderByDescending(x => x.Value)
                                              .ToDictionary(x => x.Key, x => x.Value);

                foreach (var city in CountriesAndCities[country].Keys)
                {
                    Console.WriteLine($"=>{city}: {CountriesAndCities[country][city]}");
                }
            }

        }
    }
}
