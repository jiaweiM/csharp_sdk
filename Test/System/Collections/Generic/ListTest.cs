using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests.System.Collections.Generic
{
    public class ListTest
    {
        /// <summary>
        /// Remove a range of elements, and all the elements following them
        /// have their indexes reduced by count.
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

            input = new string[] { "Tyrannosaurus",
                               "Deinonychus",
                               "Velociraptor"};

            Console.WriteLine("\nInsertRange(3, input)");
            dinosaurs.InsertRange(3, input);

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\noutput = dinosaurs.GetRange(2, 3).ToArray()");
            string[] output = dinosaurs.GetRange(2, 3).ToArray();

            Console.WriteLine();
            foreach (string dinosaur in output)
            {
                Console.WriteLine(dinosaur);
            }
        }
    }
}