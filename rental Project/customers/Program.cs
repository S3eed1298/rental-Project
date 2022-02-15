using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace rental_Project.customers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunUsingJson();
            Console.WriteLine("----------------------------------------------------------------------------------");
            RunUsingTxt();
            Console.WriteLine("----------------------------------------------------------------------------------");
            CreateJsonFile();
        }

        public static void RunUsingJson()
        {
            var fileName = "Data.json";
            string json = File.ReadAllText(fileName);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            List<Customer> deserializedList = JsonConvert.DeserializeObject<List<Customer>>(json, settings);
            Dictionary<string, int> values = CalculationsForPrinting(deserializedList);
            Printing(values);
        }

        public static void RunUsingTxt()
        {
            Dictionary<string, int> valuess = CalculationsForPrinting(ListOfCustomers());
            Printing(valuess);
        }

        public static void CreateJsonFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string json2 = JsonConvert.SerializeObject(ListOfCustomers(), Formatting.Indented, settings);
            Console.WriteLine(json2);
        }

        public static List<Customer> ListOfCustomers()
        {
            List<string> linesOfTheFile = ReadingTheFile();
            return ParsingLines(linesOfTheFile);
        }


        public static List<string> ReadingTheFile()
        {
            var filePath = @"customers.txt";
            return File.ReadAllLines(filePath).ToList();
        }

        public static List<Customer> ParsingLines(List<string> fileLines)
        {            
            var customers = new List<Customer>();
            foreach (string line in fileLines)
            {
                string[] customerInfo = line.Split(",");
                if (customerInfo[0].Equals("Individual"))
                {
                    if (customerInfo[1][0].Equals('M')) {

                        var customer = new IndividualCustomer<string>(
                            customerInfo[1],
                            Convert.ToInt32(customerInfo[2]),
                            customerInfo[3],
                            Convert.ToInt32(customerInfo[4]),
                            Convert.ToDouble(customerInfo[5]));
                        customers.Add(customer);

                    } else
                    {
                        var customer = new IndividualCustomer<int>(
                            (int)Convert.ToInt64(customerInfo[1]),
                            Convert.ToInt32(customerInfo[2]),
                            customerInfo[3],
                            Convert.ToInt32(customerInfo[4]),
                            Convert.ToDouble(customerInfo[5]));
                        customers.Add(customer);
                    } 
                }
                else
                {
                    if (customerInfo[1][0].Equals('S'))
                    {
                        var customer = new CommercialCustomers(
                            customerInfo[1],
                            Convert.ToInt32(customerInfo[2]),
                            customerInfo[3],
                            Convert.ToInt32(customerInfo[4]),
                            Convert.ToDouble(customerInfo[5]),
                            new SilverMember());
                        customers.Add(customer);
                    }
                    else if (customerInfo[1][0].Equals('G'))
                    {
                        var customer = new CommercialCustomers(
                            customerInfo[1],
                            Convert.ToInt32(customerInfo[2]),
                            customerInfo[3],
                            Convert.ToInt32(customerInfo[4]),
                            Convert.ToDouble(customerInfo[5]),
                            new GoldMember());
                        customers.Add(customer);
                    }
                    else if (customerInfo[1][0].Equals('P'))
                    {
                        var customer = new CommercialCustomers(
                            customerInfo[1],
                            Convert.ToInt32(customerInfo[2]),
                            customerInfo[3],
                            Convert.ToInt32(customerInfo[4]),
                            Convert.ToDouble(customerInfo[5]),
                            new PlatinumeMember());
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        public static Dictionary<string,int> DictonaryForCustomersData()
        {
            Dictionary<string,int> values =  new Dictionary<string, int>();
            values.Add("carsRentedNum", 0);
            values.Add("commercialRentalsNum", 0);
            values.Add("commercialRentalmonthNum", 0);
            values.Add("individualRentalNum", 0);
            values.Add("individualRentalDayNum", 0);
            values.Add("individualNonMemberNum", 0);
            values.Add("individualMemberNum", 0);
            values.Add("silverCommercialNum", 0);
            values.Add("goldCommercialNum", 0);
            values.Add("platinumCommercialNum", 0);
            return values;
        }
        public static Dictionary<string,int> CalculationsForPrinting(List<Customer> customers)
        {
            Dictionary<string, int> values = DictonaryForCustomersData();
            values["carsRentedNum"] = customers.Count;
            foreach (Customer customer in customers)
            {
                if (customer is IndividualCustomer<string> || customer is IndividualCustomer<int>)
                {
                    values["individualRentalNum"] = values["individualRentalNum"] + 1;
                    if (customer is IndividualCustomer<string>)
                    {
                        values["individualRentalDayNum"] = values["individualRentalDayNum"] += ((IndividualCustomer<string>)customer).NumberOfDays;
                        values["individualMemberNum"] = values["individualMemberNum"] + 1;
                    }
                    else
                    {
                        values["individualRentalDayNum"] = values["individualRentalDayNum"] += ((IndividualCustomer<int>)customer).NumberOfDays;
                        values["individualNonMemberNum"] = values["individualNonMemberNum"] + 1;
                    }
                }
                else
                {
                    values["commercialRentalsNum"] = values["commercialRentalsNum"] + 1;
                    values["commercialRentalmonthNum"] = values["commercialRentalmonthNum"] += ((CommercialCustomers)customer).NumberOfMonths;
                    if (((CommercialCustomers)customer).DiscountType is SilverMember)
                    {
                        values["silverCommercialNum"] = values["silverCommercialNum"] + 1;
                    }
                    else if (((CommercialCustomers)customer).DiscountType is GoldMember)
                    {
                        values["goldCommercialNum"] = values["goldCommercialNum"] + 1;
                    }
                    else
                    {
                        values["platinumCommercialNum"] = values["platinumCommercialNum"] + 1;
                    }
                }
            }
            return values;
        }
        public static void Printing(Dictionary<string, int> values)
        {
            Console.WriteLine("Welcome!");
            Console.Write(
                $"Total number of cars rented: {values["carsRentedNum"]}\n"
              + $"Total number of commercial rentals: {values["commercialRentalsNum"]}\n"
              + $"Total number of commercial rental-month: {values["commercialRentalmonthNum"]}\n"
              + $"Total number of individual rentals: {values["individualRentalNum"]}\n"
              + $"Total number of individual rental-day: {values["individualRentalDayNum"]}\n"
              + $"Total number of rentals of individual non-member customers: {values["individualNonMemberNum"]}\n"
              + $"Total number of rentals of individual member customers: {values["individualMemberNum"]}\n"
              + $"Total number of rentals of silver commercial customers: {values["silverCommercialNum"]}\n"
              + $"Total number of rentals of gold commercial customers: {values["goldCommercialNum"]}\n"
              + $"Total number of rentals of platinum commercial customers: {values["platinumCommercialNum"]}\n");
        }
    }
}