using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests.System.Collections.Generic
{
    public class ListTest
    {
        /// <summary>
        /// RemoveRange
        /// Remove a range of elements, and all the elements following them
        /// have their indexes reduced by count.
        /// 
        /// InsertRange
        /// Inserts the elements of a collection into the list at the specified index
        /// 
        /// GetRange
        /// Creates a shallow copy of a range of elements in the source List
        /// </summary>
        [Test]
        public void TestRemoveRange()
        {
            string[] input = { "Brachiosaurus", "Amargasaurus", "Mamenchisaurus" };

            List<string> dinosaurs = new List<string>(input);
            Assert.AreEqual(3, dinosaurs.Capacity);

            dinosaurs.AddRange(dinosaurs);
            Assert.That(dinosaurs, Is.EquivalentTo(new string[]{"Brachiosaurus", "Amargasaurus", "Mamenchisaurus",
                                                                "Brachiosaurus", "Amargasaurus", "Mamenchisaurus"}));
            dinosaurs.RemoveRange(2, 2);
            Assert.That(dinosaurs, Is.EquivalentTo(new string[] { "Brachiosaurus", "Amargasaurus", "Amargasaurus", "Mamenchisaurus" }));

            input = new string[] { "Tyrannosaurus", "Deinonychus", "Velociraptor" };
            dinosaurs.InsertRange(3, input);
            Assert.That(dinosaurs, Is.EquivalentTo(new string[]{"Brachiosaurus", "Amargasaurus", "Amargasaurus", "Tyrannosaurus",
                                                                    "Deinonychus", "Velociraptor" ,"Mamenchisaurus" }));

            string[] output = dinosaurs.GetRange(2, 3).ToArray();
            Assert.That(output, Is.EquivalentTo(new string[] { "Amargasaurus", "Tyrannosaurus", "Deinonychus" }));
        }

        /// <summary>
        /// Inserts an element into the List<T> at the specified index.
        /// </summary>
        [Test]
        public void TestInsert()
        {
            List<string> dinosaurs = new List<string>();
            Assert.AreEqual(dinosaurs.Capacity, 0);

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");

            Assert.That(dinosaurs, Is.EquivalentTo(new string[] { "Tyrannosaurus", "Amargasaurus", "Mamenchisaurus",
                                                                    "Deinonychus", "Compsognathus" }));
            Assert.AreEqual(dinosaurs.Capacity, 8);
            Assert.AreEqual(dinosaurs.Count, 5);
            Assert.That(dinosaurs, Has.Member("Deinonychus"));

            dinosaurs.Insert(2, "Compsognathus");
            Assert.That(dinosaurs, Is.EquivalentTo(new string[]{"Tyrannosaurus", "Amargasaurus", "Compsognathus",
                                                                "Mamenchisaurus","Deinonychus", "Compsognathus"}));
            Assert.That(dinosaurs[3], Is.EqualTo("Mamenchisaurus"));

            dinosaurs.Remove("Compsognathus");
            Assert.That(dinosaurs, Is.EquivalentTo(new string[]{"Tyrannosaurus", "Amargasaurus",
                                                                "Mamenchisaurus","Deinonychus", "Compsognathus"}));
            dinosaurs.TrimExcess();
            Assert.That(dinosaurs.Capacity, Is.EqualTo(5));
            Assert.That(dinosaurs.Count, Is.EqualTo(5));

            dinosaurs.Clear();
            Assert.That(dinosaurs.Capacity, Is.EqualTo(5));
            Assert.That(dinosaurs.Count, Is.EqualTo(0));
        }
    }
}