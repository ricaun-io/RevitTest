using Autodesk.Revit.UI;
using NUnit.Framework;
using System;

namespace RevitTest.Sample
{
    public class Tests_UIApplication : UIApplicationTests
    {
        [Test]
        public void RevitTests_VersionName()
        {
            Assert.IsNotNull(uiapp);
            Console.WriteLine(uiapp.Application.VersionName);
        }
    }

    public abstract class UIApplicationTests
    {
        protected UIApplication uiapp;

        [OneTimeSetUp]
        public void Setup(UIApplication uiapp)
        {
            this.uiapp = uiapp;
        }
    }
}