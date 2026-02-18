using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal partial class User
    {
        public userPass _userPass;
        public void GetName()
        {
            Console.WriteLine(Name);
        }

        public class userPass
        {
            public string Name;
            public string Password;
        }
    }

}
