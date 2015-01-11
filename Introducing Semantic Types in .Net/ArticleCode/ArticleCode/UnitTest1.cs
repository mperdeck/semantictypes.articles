using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace ArticleCode
{
    public class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }

    public struct s1
    {
        public string F1 { get; set; }
    }

    public struct s2
    {
        public string F2 { get; set; }
    }




    public class EmailAddress : IEquatable<EmailAddress>
    {
        public string Value { get; private set; }

        public EmailAddress(string emailAddress)
        {
            if (!IsValid(emailAddress)) { throw new ArgumentException(string.Format("Invalid email address: {0}", emailAddress)); }
            Value = emailAddress;
        }

        public static bool IsValid(string emailAddress)
        {
            return Regex.IsMatch(emailAddress,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase);
        }

#region equality

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if ((obj == null) || (!(obj is EmailAddress)))
            {
                return false;
            }

            return (Value.Equals(((EmailAddress)obj).Value));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(EmailAddress other)
        {
            if (other == null) { return false; }

            return (Value.Equals(other.Value));
        }

        public static bool operator ==(EmailAddress a, EmailAddress b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            // Have to cast to object, otherwise you recursively call this == operator.
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(EmailAddress a, EmailAddress b)
        {
            return !(a == b);
        }

#endregion
    }

    // Doesn't compile
    //public class EmailAddress : string
    //{
    //}



    [TestClass]
    public class UnitTest1
    {
        public int myfunction(Person person)
        {
            return 0;
        }

        public double GetDistance()
        {
            return 0;
        }

        public double GetTemperature()
        {
            return 0;
        }

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="emailAddress">
        /// ------ Hopefully this is a valid email address -------
        /// But there is no way to be sure. We could be getting anything here really.
        /// 
        /// If someone passes a phone number by mistake, the compiler will
        /// happily compile this, and we'll get a run time exception. Happy debugging.
        /// </param>
        /// <param name="message">
        /// Message to send.
        /// </param>
        public void SendEmail(string emailAddress, string message)
        {
        }


        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="emailAddress">
        /// ------ Compiler ensures this is a valid email address --------
        /// 
        /// The compiler won't let you pass anything but a valid email address here.
        /// Once you have an EmailAddress, you are 100% sure it is valid.
        /// </param>
        /// <param name="message">
        /// Message to send.
        /// </param>
        public void SendEmail(EmailAddress emailAddress, string message)
        {
        }


        [TestMethod]
        public void TestMethod10()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            double d = GetDistance();
            double t = GetTemperature();

            // ... Many complicated lines further ...

            // Adding a temperature to a distance doesn't make sense, 
            // but the compiler won't warn you.
            double probablyWrong = d + t;

            // ==============================================================

            bool isValidEmailAddress = EmailAddress.IsValid("kjones@megacorp.com"); // true
            var validEmailAddress = new EmailAddress("kjones@megacorp.com");

            bool isValidEmailAddress2 = EmailAddress.IsValid("not a valid email address"); // false
            var validEmailAddress2 = new EmailAddress("not a valid email address"); // throws exception

            SendEmail(validEmailAddress, "message"); // can only pass an valid email address




            string emailAddressString = validEmailAddress.Value; // "kjones@megacorp.com"
            {
                string emailAddress1 = "kjones@megacorp.com";
                string emailAddress2 = "kjones@megacorp.com";
                bool equal = (emailAddress1 == emailAddress2); // true
            }
            {
                var emailAddress1 = new EmailAddress("kjones@megacorp.com");
                var emailAddress2 = new EmailAddress("kjones@megacorp.com");
                bool equal = (emailAddress1 == emailAddress2); // true
            }

        }
    }
}
