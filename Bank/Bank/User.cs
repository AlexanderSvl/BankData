using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class User
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string EGN { get; set; }
        public string phoneNumber { get; set; }
        public decimal balance { get; set; }
        public string email { get; set; }

        public User(int ID, string name, int age, string EGN, string phoneNumber, decimal balance, string email)
        {
            this.ID = ID;
            this.name = name;
            this.age = age;
            this.EGN = EGN;
            this.phoneNumber = phoneNumber;
            this.balance = balance;
            this.email = email;
        }

        public void UpdateName(string newName)
        {
            this.name = newName;
        }

        public void UpdateAge(int newAge)
        {
            this.age = newAge;
        }

        public void UpdateEmail(string newEmail)
        {
            this.email = newEmail;
        }

        public void AddMoney(decimal money)
        {
            this.balance += money;
        }

        public void RemoveMoney(decimal money)
        {
            this.balance -= money;
        }

        public override string ToString()
        {
            return "ID: " + this.ID +
                    " Name: " + this.name +
                    " Age: " + this.age +
                    " EGN: " + this.EGN +
                    " Phone number: " + this.phoneNumber +
                    " Balance: " + this.balance +
                    " Email: " + this.email;
        }
    }
}
