using System;
using System.IO;
using LibGit2Sharp;
using NFluent;
using NUnit.Framework;

namespace Git
{
	[TestFixture]
	public class UseGitProgrammatically
	{
	    //https://libgit2.github.com/
	    //https://github.com/libgit2/libgit2sharp
		[Test]
		[Ignore("System.AccessViolationException : Tentative de lecture ou d'écriture de mémoire protégée. Cela indique souvent qu'une autre mémoire est endommagée.")]
		public void AddFilesToIndex()
		{
			var folder = @"c:\tmp\explorationDotNet\tests";
			if (!Directory.Exists(folder))
			{
				Directory.CreateDirectory(folder);
			}

			//var cloningSshAuthentication = cloningSSHAuthentication();
			var cloningSshAuthentication = CloneSshAgent();

			string clonedRepoPath = Repository.Clone("git@github.com:regisroy/explorationDotNet.git", folder, cloningSshAuthentication);

			using (var repo = new Repository(clonedRepoPath))
			{
				string dir = repo.Info.Path;
				Assert.True(Path.IsPathRooted(dir));
				Assert.True(Directory.Exists(dir));

				Assert.NotNull(repo.Info.WorkingDirectory);
				//Assert.Equal(Path.Combine(folder, ".git" + Path.DirectorySeparatorChar), repo.Info.Path);
				Assert.False(repo.Info.IsBare);

				Assert.True(File.Exists(Path.Combine(folder, "master.txt")));
				//Assert.Equal("master", repo.Head.FriendlyName);
				//Assert.Equal("49322bb17d3acc9146f98c97d078513228bbf3c0", repo.Head.Tip.Id.ToString());
			}
		}
		
		public CloneOptions cloningSSHAuthentication()
		{
			var sshDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh");

		
			CloneOptions options = new CloneOptions();
			SshUserKeyCredentials credentials = new SshUserKeyCredentials
			{
				Username = "git",
				PublicKey = Path.Combine(sshDir, "id_rsa.pub"),
				PrivateKey = Path.Combine(sshDir, "id_rsa"),
				Passphrase = "ce n'est rien..."
			};
			var handler = new LibGit2Sharp.Handlers.CredentialsHandler((url, usernameFromUrl, types) => credentials);
			options.CredentialsProvider = handler;			
			return options;
		}

		private CloneOptions CloneSshAgent(){
			CloneOptions options = new CloneOptions();
			SshAgentCredentials credentials = new SshAgentCredentials {Username = "git"};
			var handler = new LibGit2Sharp.Handlers.CredentialsHandler((url, usernameFromUrl, types) => credentials);
			options.CredentialsProvider = handler;
			return options;

		}
	}
}