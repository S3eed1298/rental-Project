using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rental_Project.customers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
                List<string> linesOfTheFile = readingTheFile();
                List<Customer> customers = parsingLines(linesOfTheFile);
                Dictionary<string, int> values = calculationsForPrinting(customers);
                Printing(values);

        }

        public static void Printing(Dictionary<string,int> values)
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
        public static List<string> readingTheFile()
        {
            var filePath = @"customers/customers.txt";
            var lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();
            return lines;
        }

        public static List<Customer> parsingLines(List<string> fileLines)
        {            
            var customers = new List<Customer>();
            foreach (string line in fileLines)
            {
                string[] customerInfo = line.Split(",");
                if (customerInfo[0].Equals("Individual"))
                {
                    if (customerInfo[1][0].Equals('M'))
                    {
                        var customer = new IndividualCustomer<string>(
                            customerInfo[1],
                            Convert.ToInt32(customerInfo[2]),
                            customerInfo[3],
                            Convert.ToInt32(customerInfo[4]),
                            Convert.ToDouble(customerInfo[5]));
                        customers.Add(customer);
                    }
                    else
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

        public static Dictionary<string,int> calculationsForPrinting(List<Customer> customers)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            values.Add("carsRentedNum", customers.Count);
            values.Add("commercialRentalsNum", 0);
            values.Add("commercialRentalmonthNum", 0);
            values.Add("individualRentalNum", 0);
            values.Add("individualRentalDayNum", 0);
            values.Add("individualNonMemberNum", 0);
            values.Add("individualMemberNum", 0);
            values.Add("silverCommercialNum", 0);
            values.Add("goldCommercialNum", 0);
            values.Add("platinumCommercialNum", 0);
            foreach (Customer customer in customers)
            {
                if (customer is IndividualCustomer<string> || customer is IndividualCustomer<int>)
                {

                    values["individualRentalNum"] = values["individualRentalNum"] + 1;
                    if (customer is IndividualCustomer<string>)
                    {
                        values["individualMemberNum"] = values["individualMemberNum"] + 1;
                        values["individualRentalDayNum"] = values["individualRentalDayNum"] += ((IndividualCustomer<string>)customer).numberOfDays;
                    }
                    else
                    {
                        values["individualNonMemberNum"] = values["individualNonMemberNum"] + 1;
                        values["individualRentalDayNum"] = values["individualRentalDayNum"] += ((IndividualCustomer<int>)customer).numberOfDays;
                    }
                }
                else
                {
                    values["commercialRentalsNum"] = values["commercialRentalsNum"] + 1;
                    values["commercialRentalmonthNum"] = values["commercialRentalmonthNum"] += ((CommercialCustomers)customer).numberOfMonths;
                    if (((CommercialCustomers)customer).discountType is SilverMember)
                    {
                        values["silverCommercialNum"] = values["silverCommercialNum"] + 1;
                    }
                    else if (((CommercialCustomers)customer).discountType is GoldMember)
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
    }
}