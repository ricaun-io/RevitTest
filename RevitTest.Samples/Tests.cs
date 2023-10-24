using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using NUnit.Framework;
using System;

namespace RevitTest.Sample
{
    public class Tests
    {
        [Test]
        public void RevitTests_VersionName(UIApplication uiapp)
        {
            Assert.IsNotNull(uiapp);
            Console.WriteLine(uiapp.Application.VersionName);
        }

        [Test]
        public void RevitTests_VersionName(Application application)
        {
            Assert.IsNotNull(application);
            Console.WriteLine(application.VersionName);
        }

        [Test]
        public void RevitTests_VersionName(UIControlledApplication uiControlledApplication)
        {
            Assert.IsNotNull(uiControlledApplication);
            Console.WriteLine(uiControlledApplication.ControlledApplication.VersionName);
        }

        [Test]
        public void RevitTests_VersionName(ControlledApplication controlledApplication)
        {
            Assert.IsNotNull(controlledApplication);
            Console.WriteLine(controlledApplication.VersionName);
        }
    }
}