using rental_Project.customers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace rental_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                string filePath = @"C:\Users\Win 10\Source\Repos\rental-Project\rental Project\customers.txt";
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines)
                {
                    string[] customerInfo = line.Split(",");
                    if (customerInfo[0].Equals("Individiual"))
                    {
                        if (customerInfo[1][0].Equals("M"))
                        {
                            IndividualCustomer<String> customer = new IndividualCustomer<string>(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]));
                            customers.Add(customer);
                        }
                        else
                        {
                            IndividualCustomer<int> customer = new IndividualCustomer<int>(Convert.ToInt32(customerInfo[1]), Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]));
                            customers.Add(customer);
                        }
                    }
                    else
                    {
                        if (customerInfo[1][0].Equals("S"))
                        {
                            CommercialCustomers customer = new CommercialCustomers(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]), new SilverMember());
                        }else if (customerInfo[1][0].Equals("G"))
                        {
                            CommercialCustomers customer = new CommercialCustomers(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]), new GoldMember());
                        }else
                        {
                            CommercialCustomers customer = new CommercialCustomers(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]), new PlatinumeMember());
                        }
                    }
                }
                Console.WriteLine("Welcome!");
                Console.Write($"Total number of cars rented: {numb}\n" +
                              $"Total number of commercial rentals: {numb}\n" +
                              $"Total number of commercial rental-month: {numb}\n" +
                              $"Total number of individual rentals: {numb}\n" +
                              $"Total number of individual rental-day: {numb}\n" +
                              $"Total number of rentals of individual non-member customers: {numb}\n" +
                              $"Total number of rentals of individual member customers: {numb}\n" +
                              $"Total number of rentals of silver commercial customers: {numb}\n" +
                              $"Total number of rentals of gold commercial customers: {numb}\n" +
                              $"Total number of rentals of platinum commercial customers: {numb}\n");

            }
            catch {
                Console.WriteLine("error");
            }
        }
    }
}
