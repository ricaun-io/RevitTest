using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using NUnit.Framework;
using System;

namespace RevitTest.Sample
{
    public class Tests_AllSetUp
    {
        UIApplication uiapp;
        Application application;
        UIControlledApplication uiControlledApplication;
        ControlledApplication controlledApplication;

        [OneTimeSetUp]
        public void Setup(
            UIApplication uiapp,
            Application application,
            UIControlledApplication uiControlledApplication,
            ControlledApplication controlledApplication)
        {
            this.uiapp = uiapp;
            this.application = application;
            this.uiControlledApplication = uiControlledApplication;
            this.controlledApplication = controlledApplication;
        }

        [Test]
        public void RevitTests_UIApplication_VersionName()
        {
            Assert.IsNotNull(uiapp);
            Console.WriteLine(uiapp.Application.VersionName);
        }

        [Test]
        public void RevitTests_Application_VersionName()
        {
            Assert.IsNotNull(application);
            Console.WriteLine(application.VersionName);
        }

        [Test]
        public void RevitTests_UIControlledApplication_VersionName()
        {
            Assert.IsNotNull(uiControlledApplication);
            Console.WriteLine(uiControlledApplication.ControlledApplication.VersionName);
        }

        [Test]
        public void RevitTests_ControlledApplication_VersionName()
        {
            Assert.IsNotNull(controlledApplication);
            Console.WriteLine(controlledApplication.VersionName);
        }
    }
}