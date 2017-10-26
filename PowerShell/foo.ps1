



$x = Get-ChildItem -Path "C:\inetpub\wwwroot\GenerativeObjectsApplications\Development\v1.24\H3C_2017-04-25_11h18.zip"

$x.BaseName

cd C:\Projects\GOForH3C

if((git name-rev --name-only HEAD) -ne "master") {
   "pas master"
   git checkout master
} else {
  "master"
}
Support Inscriptions Incohérentes Import

Copy-Item -Path c:\tmp\exportAssocies-page1.png -Destination \\h3c-dev.generativeobjects.com\c$\tmp\test.png

(Get-Content file.txt) | 
Foreach-Object {$_ -replace '\[MYID\]','MyValue'}  | 
Out-File file.txt

$content = [System.IO.File]::ReadAllText("c:\bla.txt").Replace("[MYID]","MyValue")
[System.IO.File]::WriteAllText("c:\bla.txt", $content)

Get-ChildItem 'C:yourfile*.xml' -Recurse | ForEach {
     (Get-Content $_ | ForEach  { $_ -replace '[MYID]', 'MyValue' }) |
     Set-Content $_
}


###### Remplacer texte on multiple files entre 2 balises
$path = "C:\tmp\preprod web.config"
$text=@"
<add key="DatabaseName" value="H3C-Prod_999" />
	<add key="Main.ConnectionString.SQL Server (SqlClient)" value="data source=tcp:h3cpreprodsqlw.westeurope.cloudapp.azure.com;Initial Catalog=H3C-Prod_04-13;Persist Security Info=False;User ID=goroot;Password=go2016go2016!!;Connection Timeout=30;" />
	<add key="ChangeTrackingMode" value="Disabled"/>
	<add key="BaseURL" value="https://sim.recette.h3c.org/"/>
	<add key="InstanceName" value=""/>
	<add key="ProjectName" value="" />
	<add key="Version" value="1679" />

	<add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=h3cpreprodfiles;AccountKey=mEtiizV7X623KZnGEz8LGCK4+rtpa2nCZ88gOlnHzRaXR5Gn6M6RlV4clCucvJiHPbIBnNXR7EWic++z8xb5QA=="/>
	<add key="LogMoteIssuer" value="h3c.org"/>
	<add key="LogMoteDestination" value="https://h3c.logmote.net"/>
	<!-- SessionTokenTimeout: lifetime of tokens issued with security provider, in minutes -->
	<add key="SessionTokenTimeout" value="12000" />
	<!-- SessionTokenRenewalTimeout: timeout after which the server will automatically renew the user token -->
	<add key="SessionTokenRenewalTimeout" value="60" />
	<!-- SessionNoActivityMessageDelay: delay after which the client will display a "no activity" warning message to users -->
	<add key="SessionNoActivityMessageDelay" value="100" />
 
	<add key="IsInDebug"
"@
$regex=@"
<add key="DatabaseName"([\s\S]*?)<add key=\"IsInDebug"
"@

(Get-Content $path | Out-String) -replace $regex, $text | out-file $path 
# => ca marche


####### récupérer texte entre 2 balises
$path = "C:\tmp\preprod web.config"
$regex=@"
(<add key="DatabaseName"[\s\S]*?<add key=\"IsInDebug")
"@
(Get-Content $path | Out-String) -match "$regex"
$content=$matches[1]
$content


#### supprimer texte entre 2 balises 
# faire un replace avec du vide




#<add key="DatabaseName"([\s\S]*?)<add key="IsInDebug"



