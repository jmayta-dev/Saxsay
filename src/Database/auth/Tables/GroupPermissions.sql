CREATE TABLE [auth].[GroupPermissions]
(
	[Id]			INT IDENTITY(1, 1) NOT NULL,
	[GroupId]		INT NOT NULL,
	[PermissionId]	INT NOT NULL,
	[CreatedAt]		DATETIME NOT NULL
) ON [PRIMARY]
GO
