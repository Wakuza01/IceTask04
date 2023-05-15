using System;
using System.Collections.Generic;

namespace DonorManagementSystem
{
    class Donor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Donation> Donations { get; set; }

        public Donor(string name, string surname, string phone, string email)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            Donations = new List<Donation>();
        }

        public decimal TotalDonations()
        {
            decimal total = 0;
            foreach (var donation in Donations)
            {
                total += donation.Amount;
            }
            return total;
        }
    }

    class Donation
    {
        public decimal Amount { get; set; }
        public string Cause { get; set; }

        public Donation(decimal amount, string cause)
        {
            Amount = amount;
            Cause = cause;
        }
    }

    class Program
    {
        static List<Donor> donors = new List<Donor>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Donor Management System, Please select an option from the list below:");
                Console.WriteLine("1. Add Donor");
                Console.WriteLine("2. Capture Donation");
                Console.WriteLine("3. View Donor's Donations");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDonor();
                        break;
                    case "2":
                        CaptureDonation();
                        break;
                    case "3":
                        ViewDonations();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Your choice was invalid. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddDonor()
        {
            Console.WriteLine("=== Add A Donor ===");
            Console.Write("Enter donor's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the donor's surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter the donor's phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter the donor's email address: ");
            string email = Console.ReadLine();

            var donor = new Donor(name, surname, phone, email);
            donors.Add(donor);

            Console.WriteLine("Donor added successfully!");
        }

        static void CaptureDonation()
        {
            Console.WriteLine("=== Capture A Donation ===");
            Console.Write("Enter the donor's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the donor's surname: ");
            string surname = Console.ReadLine();

            var donor = FindDonor(name, surname);
            if (donor == null)
            {
                Console.WriteLine("Donor not found!");
                return;
            }

            Console.Write("Enter donation amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter donation cause: ");
            string cause = Console.ReadLine();

            var donation = new Donation(amount, cause);
            donor.Donations.Add(donation);

            Console.WriteLine("Donation captured successfully!");
        }

        static void ViewDonations()
        {
            Console.WriteLine("=== View Donor's Donations ===");
            Console.Write("Enter donor's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter donor's surname: ");
            string surname = Console.ReadLine();

            var donor = FindDonor(name, surname);
            if (donor == null)
            {
                Console.WriteLine("Donor not found!");
                return;
            }

            Console.WriteLine("Donor: {0} {1}", donor.Name, donor.Surname);
            Console.WriteLine("Total Donations: {0:C}", donor.TotalDonations());
            Console.WriteLine("Donation Details:");
            foreach (var donation in donor.Donations)
            {
                Console.WriteLine("Amount: {0:C}\tCause: {1}", donation.Amount, donation.Cause);
            }
        }
    }
}
        

