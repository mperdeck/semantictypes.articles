using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArticleCode
{
    public class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }

    [TestClass]
    public class UnitTest1
    {
        public int myfunction(Person person)
        {
            return 0;
        }

        [TestMethod]
        public void TestMethod1()
        {




        }
    }
}
