using NFluent;
using NUnit.Framework;

namespace UsingResources
{
	[TestFixture]
	public class UsingResourcesTestCases
	{
		[Test]
		public void GettingFileResources()
		{
			var databaseCreationFileContent = Properties.Resources.database_creation;
			Check.That(databaseCreationFileContent).Equals("DROP DATABASE Cool\r\n" +
			                                               "GO\r\n" +
			                                               "CREATE DATABASE Cool\r\n" +
			                                               "GO");
		}

		[Test]
		public void GettingExcelFileFromResources()
		{
			var databaseCreationFileContent = Properties.Resources.database_creation;
			Check.That(databaseCreationFileContent).Equals("DROP DATABASE Cool\r\n" +
			                                               "GO\r\n" +
			                                               "CREATE DATABASE Cool\r\n" +
			                                               "GO");
		}

		[Test]
		public void GettingProperties()
		{
			var projectName = Properties.Resources.ProjectName;
			Check.That(projectName).Equals("Nom du projet dans une ressource de type string");
		}
	}
}