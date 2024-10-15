CREATE TABLE [auth].[UserPermissions]
(
	[Id]			INT IDENTITY(1,1)	NOT NULL,
	[UserId]		INT					NOT NULL,
	[PermissionId]	INT					NOT NULL,
	[CreatedAt]		DATETIME			NOT NULL
) ON [PRIMARY]
GO
