using Autodesk.Revit.DB;
using NUnit.Framework;
using System;

namespace RevitTest.Sample
{
    public class Tests_Utils
    {
        private const double Tolerance = 1.0e-6;

        [TestCase(1.0, 0.3048)]
        [TestCase(2.0, 0.6096)]
        [TestCase(3.0, 0.9144)]
        [TestCase(4.2, 1.28016)]
        [TestCase(5.3, 1.61544)]
        [TestCase(6.4, 1.95072)]
        public void RevitTests_FromInternalUnits_Meters(double meters, double internalMeters)
        {
            var convert = UnitUtils.ConvertFromInternalUnits(meters, UnitTypeId.Meters);
            Console.WriteLine($"{meters} to {convert}");
            
            var almostEqual = Math.Abs(internalMeters - convert) < Tolerance;
            Assert.IsTrue(almostEqual);
        }
    }
}