CREATE TABLE [auth].[UserGroups]
(
	[Id]		INT IDENTITY(1,1)	NOT NULL,
	[UserId]	INT					NOT NULL,
	[GroupId]	INT					NOT NULL,
	[CreatedAt]	DATETIME			NOT NULL
) ON [PRIMARY]
GO