using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Bank :IEnumerable
    {
        private CustomArrayList<User> users;

        public Bank(CustomArrayList<User> usersForBank)
        {
            this.users = usersForBank;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (User user in users)
            {
                yield return "ID: " + user.ID + 
                    " Name: " + user.name + 
                    " Age: " + user.age + 
                    " EGN: " + user.EGN + 
                    " Phone number: " + user.phoneNumber + 
                    " Balance: " + user.balance + 
                    " Email: " + user.email;
            }
        } 

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
