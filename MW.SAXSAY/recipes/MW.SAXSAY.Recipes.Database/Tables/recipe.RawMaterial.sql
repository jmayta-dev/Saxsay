USE MWSAXSAYDB;
GO

-- TABLA DE INGREDIENTES
IF EXISTS ( SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.RawMaterial', N'U')   )
BEGIN
    DROP TABLE [recipe].[RawMaterial]
END
GO

CREATE TABLE [recipe].[RawMaterial] (
    [RawMaterialId]     INT IDENTITY(1,1)   NOT NULL,
    [Name]              VARCHAR(254)        NOT NULL
)
GO

ALTER TABLE [recipe].[RawMaterial]
    ADD CONSTRAINT RawMaterial_RawMaterialId_CPK
        PRIMARY KEY ([RawMaterialId]);
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Raw Material table',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'RawMaterial';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Raw material identifier',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'RawMaterial',
    @level2type = N'COLUMN',    @level2name = N'RawMaterialId';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Raw material name',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'RawMaterial',
    @level2type = N'COLUMN',    @level2name = N'Name';
GO