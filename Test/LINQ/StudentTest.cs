using NUnit.Framework;
using System.Linq;
using System;

namespace Tests.LINQ
{
     [TestFixture]
    public class StudentTest
    {
        [Test]
        public void TestGroupBySingleProperty()
        {
            var queryLastNames =
                from student in StudentClass.students
                group student by student.LastName
                into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine("Key: {0}", nameGroup.Key);
                foreach (var student in nameGroup)
                {
                    Console.WriteLine("\t{0}, {1}", student.LastName, student.FirstName);
                }
            }
        }
    }
}