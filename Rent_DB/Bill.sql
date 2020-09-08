Create Table [dbo].[Bill]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(20) NOT NULL,
	[Amount] INT NOT NULL,
	[LastModified] DateTime NOT NULL,

	CONSTRAINT AK_Name UNIQUE(Name) 
)	