CREATE TABLE [auth].[Users]
(
	[Id]				CHAR(24)		NOT NULL,
	[Username]			VARCHAR(200)	NOT NULL,
	[FirstName]			VARCHAR(250)	NULL,
	[LastName]			VARCHAR(250)	NULL,
	[Email]				VARCHAR(250)	NULL,
	[Password]			VARCHAR(250)	NOT NULL,
	[IsActive]			BIT				NULL,
	[LastLogin]			DATETIME		NULL,
	[IsAuthenticated]	BIT				NULL,
	[CreatedAt]			DATETIME		NOT NULL,
	[UpdatedAt]			DATETIME		NULL
) ON [PRIMARY]
GO

ALTER TABLE [auth].[Users]
	ADD CONSTRAINT DF_Users_UpdatedAt
		DEFAULT GETUTCDATE() FOR [UpdatedAt]
