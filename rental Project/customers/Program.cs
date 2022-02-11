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
                string filePath = @"C:\Users\s3eed\Source\Repos\S3eed1298\rental-Project\rental Project\customers\customers.txt";
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines)
                {
                    try
                    {
                        string[] customerInfo = line.Split(",");
                        if (customerInfo[0].Equals("Individiual"))
                        {
                            if (customerInfo[1][0].Equals('M'))
                            {
                                IndividualCustomer<String> customer = new IndividualCustomer<string>(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]));
                                customers.Add(customer);
                            }
                            else
                            {
                                IndividualCustomer<int> customer = new IndividualCustomer<int>((int)Convert.ToInt64(customerInfo[1]), Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]));
                                customers.Add(customer);
                            }
                        }
                        else
                        {
                            if (customerInfo[1][0].Equals('S'))
                            {
                                CommercialCustomers customer = new CommercialCustomers(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]), new SilverMember());
                                customers.Add(customer);
                            }
                            else if (customerInfo[1][0].Equals('G'))
                            {
                                CommercialCustomers customer = new CommercialCustomers(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]), new GoldMember());
                                customers.Add(customer);
                            }
                            else if (customerInfo[1][0].Equals('P'))
                            {
                                CommercialCustomers customer = new CommercialCustomers(customerInfo[1], Convert.ToInt32(customerInfo[2]), customerInfo[3], Convert.ToInt32(customerInfo[4]), Convert.ToInt32(customerInfo[5]), new PlatinumeMember());
                                customers.Add(customer);
                            }
                            else
                                throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("The customer id is not in an appropriate form");
                    }
                }

                int commercialRentalsNum = 0, commercialRentalmonthNum = 0, individualRentalNum = 0,
                    individualRentalDayNum = 0, individualNonMemberNum = 0, individualMemberNum = 0,
                    silverCommercialNum = 0, goldCommercialNum = 0, platinumCommercialNum = 0;
                foreach (var customer in customers)
                {
                    if (customer is IndividualCustomer<string> || customer is IndividualCustomer<int>)
                    {
                        individualRentalNum++;
                        if (customer is IndividualCustomer<string>)
                        {
                            individualMemberNum++;
                            individualRentalDayNum += ((IndividualCustomer<string>)customer).numberOfDays;
                        }
                        else
                        {
                            individualNonMemberNum++;
                            individualRentalDayNum += ((IndividualCustomer<int>)customer).numberOfDays;
                        }

                    }
                    else
                    {
                        commercialRentalsNum++;
                        commercialRentalmonthNum += ((CommercialCustomers)customer).numberOfMonths;
                        if (((CommercialCustomers)customer).discountType is SilverMember)
                            silverCommercialNum++;
                        else if (((CommercialCustomers)customer).discountType is GoldMember)
                            goldCommercialNum++;
                        else
                            platinumCommercialNum++;
                        
                    }
                }

                Console.WriteLine("Welcome!");
                Console.Write($"Total number of cars rented: {customers.Count}\n" +
                              $"Total number of commercial rentals: {commercialRentalsNum}\n" +
                              $"Total number of commercial rental-month: {commercialRentalmonthNum}\n" +
                              $"Total number of individual rentals: {individualRentalNum}\n" +
                              $"Total number of individual rental-day: {individualRentalDayNum}\n" +
                              $"Total number of rentals of individual non-member customers: {individualNonMemberNum}\n" +
                              $"Total number of rentals of individual member customers: {individualMemberNum}\n" +
                              $"Total number of rentals of silver commercial customers: {silverCommercialNum}\n" +
                              $"Total number of rentals of gold commercial customers: {goldCommercialNum}\n" +
                              $"Total number of rentals of platinum commercial customers: {platinumCommercialNum}\n");
            }
            catch
            {
                Console.WriteLine("Error occures while running");
            }
        }
    }
}
