using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice; Program obj = new Program(); choice = obj.MainMenu(); const int size = 1000; Cafe[] cafe = new Cafe[size]; for (int i = 0; i < size; i++) { cafe[i] = new Cafe(); }
            CompanyOutings[] companyOutings = new CompanyOutings[size]; for (int i = 0; i < size; i++) { companyOutings[i] = new CompanyOutings(); }
            Email[] email = new Email[size]; for (int i = 0; i < size; i++) { email[i] = new Email(); }
            if (choice == "1")
            {
                Console.Clear(); Cafe CafeObj = new Cafe(); string ItemChoice = "1"; int ItemCount = 0; while (ItemChoice != "0")
                {
                    Console.Clear(); ItemChoice = CafeObj.CafeMenu(); if (ItemChoice == "1") { cafe[ItemCount].InputDetail(); ItemCount++; }
                    else if (ItemChoice == "2")
                    {
                        string id; bool found = false; Console.Write("Meal ID: "); id = Console.ReadLine(); for (int i = 0; i < ItemCount; i++)
                        {
                            found = cafe[i].DeleteItem(id); if (found == true) { Console.WriteLine("Item Deleted!!"); Console.WriteLine(""); break; }
                        }
                        if (found == false) { Console.WriteLine("Item Not Found!!"); Console.WriteLine(""); }
                        Console.ReadLine();
                    }
                    else if (ItemChoice == "3") { Console.Clear(); for (int i = 0; i < ItemCount; i++) { cafe[i].DisplayDetail(); Console.WriteLine(""); } Console.ReadLine(); }
                }
            }
            else if (choice == "2")
            {
                Console.Clear(); string CompanyChoice; int EventCount = 0; CompanyOutings companyOutingsObj = new CompanyOutings(); do
                {
                    CompanyChoice = companyOutingsObj.CompanyOutingMainMenu(); Console.Clear(); if (CompanyChoice == "1") { companyOutings[EventCount].AddEvent(); EventCount++; }
                    else if (CompanyChoice == "2") { Console.Clear(); int Amount = 0; string year; Console.Write("Enter the Year: "); year = Console.ReadLine(); for (int i = 0; i < EventCount; i++) { Amount = companyOutings[i].getCostOfYear(year, Amount); } Console.Write("Total Cost of " + year + " is: " + Amount); Console.ReadLine(); }
                    else if (CompanyChoice == "3")
                    {
                        Console.Clear(); for (int i = 0; i < EventCount; i++)
                        {
                            companyOutings[i].ListOfOutings();
                        }
                        Console.ReadLine();
                    }
                } while (CompanyChoice != "0");
            }
            else if (choice == "3")
            {
                Console.Clear(); string EmailChoice; int EmailCount = 0; Email EmailObj = new Email(); do
                {
                    EmailChoice = EmailObj.EmailMainMenu(); Console.Clear(); if (EmailChoice == "1") { email[EmailCount].AddCustomer(); EmailCount++; }
                    else if (EmailChoice == "2") { string id; bool found = false; Console.Write("ID: "); id = Console.ReadLine(); for (int i = 0; i < EmailCount; i++) { found = email[i].UpdateMessage(id); if (found == true) { break; } } if (found == false) { Console.Write("No Customer with ID- " + id + " -Found"); Console.ReadLine(); } }
                    else if (EmailChoice == "3")
                    {
                        string id; bool found = false; Console.Write("ID: "); id = Console.ReadLine(); for (int i = 0; i < EmailCount; i++)
                        {
                            found = email[i].DeleteCustomer(id); if (found == true)
                            {
                                break;
                            }
                        }
                        if (found == false) { Console.Write("No Customer with ID- " + id + " -Found"); Console.ReadLine(); }
                    }
                } while (EmailChoice != "0");
            }
            Main(args);
        }
        public string MainMenu() { Console.Clear(); string choice; Console.WriteLine("1. Cafe"); Console.WriteLine("2. Company Outing"); Console.WriteLine("3. Email"); Console.WriteLine("0. Exit"); Console.Write("Enter Your Choice: "); choice = Console.ReadLine(); if (choice == "1" || choice == "2" || choice == "3" || choice == "0") { return choice; } Console.WriteLine("Wrong Input !!! "); Console.ReadLine(); return MainMenu(); }
    }
    class Cafe
    {
        string mealId; string MealName; string description; string ingredients; string price; bool visible = true; public Cafe() { mealId = "1"; MealName = "name"; description = "des"; ingredients = "ing"; price = "100"; visible = true; }
        public Cafe(string id, string name, string des, string ing, string pri)
        {
            mealId = id;
            MealName = name; description = des; ingredients = ing; price = pri; visible = true;
        }
        public string CafeMenu() { Console.Clear(); string choice; Console.WriteLine("1. Add Item"); Console.WriteLine("2. Delete Item"); Console.WriteLine("3. View All Item"); Console.WriteLine("0. Exit"); choice = Console.ReadLine(); if (choice == "1" || choice == "2" || choice == "3" || choice == "0") { return choice; } return CafeMenu(); }
        public void InputDetail() { Console.Clear(); Console.Write("Meal ID: "); mealId = Console.ReadLine(); Console.Write("Meal Name: "); MealName = Console.ReadLine(); Console.Write("Meal Description: "); description = Console.ReadLine(); Console.Write("Meal Ingredients: "); ingredients = Console.ReadLine(); Console.Write("Meal Price: "); price = Console.ReadLine(); visible = true; }
        public void DisplayDetail() { if (visible == true) { Console.WriteLine("Meal ID: " + mealId); Console.WriteLine("Meal Name: " + MealName); Console.WriteLine("Meal Description: " + description); Console.WriteLine("Meal Ingredients: " + ingredients); Console.WriteLine("Meal Price: " + price); } }
        public bool DeleteItem(string id)
        {
            if (id == mealId) { visible = false; return true; }
            else
            { return false; }
        }
    }
    class Date { string day, month, year; public Date() { day = "13"; month = "11"; year = "2000"; } public void InputDate() { Console.Write("Date: "); day = Console.ReadLine(); Console.Write("Month: "); month = Console.ReadLine(); Console.Write("Year: "); year = Console.ReadLine(); } public string getYear() { return year; } public void DisplayDate() { Console.WriteLine(day + "-" + month + "-" + year); } }
    class CompanyOutings
    {
        string Type; int NoOfPeople; Date date = new Date(); int CostPerPerson; int CostPerEvent; public CompanyOutings() { Type = "Daira"; NoOfPeople = 200; CostPerPerson = 2000; CostPerEvent = 200000; }
        public string CompanyOutingMainMenu()
        {
            Console.Clear(); string choice; Console.WriteLine("1. Add Event"); Console.WriteLine("2. View Yearly Cost"); Console.WriteLine("3. Total Events"); Console.WriteLine("0. Exit"); Console.Write("Enter The Choice: "); choice = Console.ReadLine();
            if (choice == "1" || choice == "2" || choice == "3" || choice == "0") { return choice; }
            return CompanyOutingMainMenu();
        }
        public string EventType() { string choice; Console.WriteLine("1. Golf"); Console.WriteLine("2. Bowling"); Console.WriteLine("3. Amusement Park"); Console.WriteLine("4. Concert"); Console.WriteLine("Enter the Type Of Event: "); choice = Console.ReadLine(); if (choice == "1" || choice == "2" || choice == "3" || choice == "4") { return choice; } else { Console.WriteLine("Wrong Input !!! "); Console.ReadLine(); return EventType(); } }
        public int getCostOfYear(string year, int Amount) { if (date.getYear() == year) { Amount += CostPerEvent; return Amount; } else { return Amount; } }
        public void AddEvent() { Type = EventType(); Console.Write("No Of Person: "); NoOfPeople = Convert.ToInt32(Console.ReadLine()); date.InputDate(); Console.Write("Cost Of Event: "); CostPerEvent = Convert.ToInt32(Console.ReadLine()); Console.Write("Cost Per Person: "); CostPerPerson = Convert.ToInt32(Console.ReadLine()); }
        public void ListOfOutings()
        {
            Console.Write("Event Name: "); if (Type == "1")
            {
                Console.WriteLine("Golf");
            }
            else if (Type == "2") { Console.WriteLine("Bowling"); } else if (Type == "3") { Console.WriteLine("Amusement PArk"); } else if (Type == "4") { Console.WriteLine("Concert"); }
            Console.WriteLine("No of Person: " + NoOfPeople); date.DisplayDate(); Console.WriteLine("Cost Per Person: " + CostPerPerson); Console.WriteLine("Cost Per Event: " + CostPerEvent); Console.WriteLine("");
        }
    }
    class Email
    {
        string id; string firstName; string lastName; string Type; string Message; bool visible = true; public Email() { id = "1"; firstName = "fName"; lastName = "lName"; Type = "Type"; Message = "Message"; }
        public string EmailMainMenu() { Console.Clear(); string choice; Console.WriteLine("1. Add Customer"); Console.WriteLine("2. Update Message"); Console.WriteLine("3. Delete Customer"); Console.WriteLine("0. Exit"); Console.Write("Enter your Choice: "); choice = Console.ReadLine(); if (choice == "1" || choice == "2" || choice == "3" || choice == "0") { return choice; } return EmailMainMenu(); }
        private string WhatType()
        {
            string choice; Console.WriteLine("1. Potential");
            Console.WriteLine("2. Current"); Console.WriteLine("3. Past"); Console.Write("Enter your Choice: "); choice = Console.ReadLine(); if (choice == "1" || choice == "2" || choice == "3") { return choice; }
            return WhatType();
        }
        private string defaultMessage() { if (Type == "1") { return "We currently have the lowest rates on Helicopter Insurance!"; } else if (Type == "2") { return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon."; } else { return "It's been a long time since we've heard from you, we want you back"; } }
        public void AddCustomer() { Type = WhatType(); Console.Write("ID: "); id = Console.ReadLine(); Console.Write("First Name: "); firstName = Console.ReadLine(); Console.Write("Last Name: "); lastName = Console.ReadLine(); Message = defaultMessage(); visible = true; }
        public bool UpdateMessage(string c_id) { if (c_id == id && visible == true) { Console.Write("New Message: "); Message = Console.ReadLine(); return true; } return false; }
        public bool DeleteCustomer(string c_id)
        {
            if (c_id == id && visible == true)
            {
                visible = false;
                return true;
            }
            return false;
        }
    }

}

