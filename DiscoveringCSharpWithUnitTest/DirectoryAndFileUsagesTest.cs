using System;
using System.Collections;
using System.IO;
using NFluent;
using NUnit.Framework;

namespace MesPremiersUnitTestProject
{
    [TestFixture]
    public class DirectoryAndFileUsagesTest
    {
        [Test]
        public void Folder_Repertoire_Directory()
        {
            //créer un répertoire localement au build
            var currentDirectory = Directory.GetCurrentDirectory();
            var tmpDir = Directory.CreateDirectory("tmp");
            Check.That(tmpDir.Exists).IsTrue();
            Check.That(tmpDir.Name).IsEqualTo("tmp");
            Check.That(tmpDir.FullName).IsEqualTo($@"{currentDirectory}\tmp");

            var tmpOnC = Directory.CreateDirectory(@"c:\tmp");
            Check.That(tmpOnC.Name).IsEqualTo(@"tmp");
            Check.That(tmpOnC.FullName).IsEqualTo(@"c:\tmp");
            //supprimer un répertoire

            //informations sur un répertoire
            Check.That(Directory.GetCurrentDirectory())
                 .IsOneOfThese(@"C:\Users\Regis\Dropbox\mes_projets\explorationDotNet\MesPremiersUnitTestProject\bin\Debug", //VS 2017
                               @"C:\Program Files\JetBrains\Rider 2017.2\lib\ReSharperHost" //Rider
                              );
            IDictionary environmentVariables = Environment.GetEnvironmentVariables();

            Check.That(environmentVariables.Count).IsStrictlyGreaterThan(40);
            Check.That(environmentVariables["COMPUTERNAME"]).IsEqualTo("GABRIELLE-PC");
            Check.That((string) environmentVariables["CommonProgramFiles"]).IsOneOfThese(@"C:\Program Files (x86)\Common Files",
                                                                                         @"C:\Program Files\Common Files"
                                                                                        );
            Check.That(environmentVariables["HOMEPATH"]).IsEqualTo(@"\Users\Regis");
            Check.That(environmentVariables["TMP"]).IsEqualTo(@"C:\Users\Regis\AppData\Local\Temp");
            Check.That(environmentVariables["TEMP"]).IsEqualTo(@"C:\Users\Regis\AppData\Local\Temp");
            Check.That(environmentVariables["USERNAME"]).IsEqualTo(@"Regis");
            Check.That(environmentVariables["USERNAME"]).IsEqualTo(@"Regis");

            var tmpDirFileInfo = new FileInfo(@"c:\tmp");
            Check.That(tmpDirFileInfo.DirectoryName).IsEqualTo(@"c:\");
            Check.That(tmpDirFileInfo.Directory.Name).IsEqualTo(@"c:\");

            //Juste à titre d'information
            var index = 1;
            foreach (DictionaryEntry environmentVariable in environmentVariables)
            {
                Console.WriteLine($"{index++:00}:{environmentVariable.Key}={environmentVariable.Value}");
            }
        }

        [Test]
        public void File_Fichier()
        {
            var fileInfo = new FileInfo(@"c:\tmp\fichierDeTest.txt"); //
            Check.That(fileInfo.Extension).IsEqualTo(".txt");
            Check.That(fileInfo.DirectoryName).IsEqualTo(@"c:\tmp");
            Check.That(fileInfo.Name).IsEqualTo("fichierDeTest.txt");
            Check.That(fileInfo.FullName).IsEqualTo(@"c:\tmp\fichierDeTest.txt");

            Check.That(Path.GetPathRoot(@"c:\tmp\fichierDeTest.txt")).IsEqualTo(@"c:\");
            Check.That(Path.GetDirectoryName(@"c:\tmp\fichierDeTest.txt")).IsEqualTo(@"c:\tmp");
            Check.That(Path.GetDirectoryName(@"GeneratedCode/Resources\AAA.Data.Resources.csproj")).IsEqualTo(@"GeneratedCode\Resources");
            Check.That(Path.GetExtension(@"c:\tmp\fichierDeTest.txt")).IsEqualTo(@".txt");
            Check.That(Path.GetFileName(@"c:\tmp\fichierDeTest.txt")).IsEqualTo("fichierDeTest.txt");
            Check.That(Path.GetFileNameWithoutExtension(@"c:\tmp\fichierDeTest.txt")).IsEqualTo("fichierDeTest");
            Check.That(Path.GetFullPath(@"c:\tmp\fichierDeTest.txt")).IsEqualTo(@"c:\tmp\fichierDeTest.txt");
            Check.That(Path.HasExtension(@"c:\tmp\fichierDeTest.txt")).IsTrue();
            Check.That(Path.IsPathRooted(@"c:\tmp\fichierDeTest.txt")).IsTrue();
            Check.That(Path.IsPathRooted(@"GeneratedCode/Resources\AAA.Data.Resources.csproj")).IsFalse();
        }

        [Test]
        [Ignore("car ne fonctionne pas à tous les coups")] //car ne fonctionne pas à tous les coups
        public void WriteInContinue()
        {
            using (Stream stream2 = File.Open("c:/tmp/FileUsagesTest.WriteInContinue.txt", FileMode.OpenOrCreate))
            using (StreamWriter sWriter1 = new StreamWriter(stream2))
            {
//                if (recievdata.Contains("UCAST") && recievdata.Contains("=g"))
//                {
//                    sWriter1.Write(DateTime.Now.ToString("HH:mm:ss"));
//                    sWriter1.Write(" ; ");
//                    sWriter1.WriteLine(1);
//                    if (SleepMovChar.InvokeRequired)
//                    {
//                        SleepMovChar.Invoke(new MethodInvoker(delegate
//                        { SleepMovChar.Series["Bevægelse"].Points.AddXY(xValue = DateTime.Now.ToString("HH:mm:ss"), 1); }));
//                        SleepMovChar.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
//                    }
//                }
//                else
//                {
//                    sWriter1.Write(DateTime.Now.ToString("HH:mm:ss"));
//                    sWriter1.Write(" ; ");
//                    sWriter1.WriteLine(0);
//                    timer1.Tick += new EventHandler(timer1_Tick);
//                }
            }
        }
    }
}