using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CSharp.Resources
{
    [TestClass]
    public class UsingResourcesTestCases
    {
        [TestMethod]
        public void GettingFileResources()
        {
            var databaseCreationFileContent = UsingResources.Properties.Resources.database_creation;
            Check.That(databaseCreationFileContent).Equals("DROP DATABASE Cool\r\n" +
                                                           "GO\r\n" +
                                                           "CREATE DATABASE Cool\r\n" +
                                                           "GO");
        }

        [TestMethod]
        public void GettingProperties()
        {
            var projectName = UsingResources.Properties.Resources.ProjectName;
            Check.That(projectName).Equals("Nom du projet dans une ressource de type string");
        }
    }
}