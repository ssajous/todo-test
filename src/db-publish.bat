sqlcmd -Q "IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'TodoTest') CREATE DATABASE [TodoTest]" -S. -E

packages\FluentMigrator.1.6.2\tools\Migrate.exe /connection "Server=.;Database=TodoTest;Integrated Security=True" /db SqlServer2014 /target TodoTest.DataMigrations\bin\Debug\TodoTest.DataMigrations.dll