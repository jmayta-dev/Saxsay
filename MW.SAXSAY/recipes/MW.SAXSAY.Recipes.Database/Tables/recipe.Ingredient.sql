USE MWSAXSAYDB;
GO

-- TABLA INTERMEDIA INGREDIENTES-RECETAS
IF EXISTS ( SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.Ingredient', N'U')   )
BEGIN
    DROP TABLE [recipe].[Ingredient]
END
GO

CREATE TABLE [recipe].[Ingredient] (
    [IngredientId]      INT IDENTITY(1,1)   NOT NULL,
    [RawMaterialId]     INT                 NOT NULL, 
    [RecipeId]          INT                 NOT NULL,
    [Quantity]          FLOAT               NOT NULL
)
GO

ALTER TABLE [recipe].[Ingredient]
    ADD CONSTRAINT Ingredient_IngredientId_CPK
        PRIMARY KEY NONCLUSTERED ([IngredientId],[RecipeId]);
GO

ALTER TABLE [recipe].[Ingredient]
    ADD CONSTRAINT Ingredient_RawMaterialId_RecipeId_CUQ
        UNIQUE ([RawMaterialId],[RecipeId]);
GO

ALTER TABLE [recipe].[Ingredient]
    ADD CONSTRAINT Ingredient_Quantity_CDF
        DEFAULT 1.0 FOR [Quantity];
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Ingredients table',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Ingredient';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Linked Ingredient identifier',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Ingredient',
    @level2type = N'COLUMN',    @level2name = N'IngredientId';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Linked Recipe identifier',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Ingredient',
    @level2type = N'COLUMN',    @level2name = N'RecipeId';
GO