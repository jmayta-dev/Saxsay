USE MWSAXSAYDB;
GO

-- TABLA DE INGREDIENTES
IF EXISTS ( SELECT object_id FROM sys.objects
            WHERE object_id = OBJECT_ID(N'recipe.Ingredient', N'U')   )
BEGIN
    DROP TABLE recipe.Ingredient
END
GO

CREATE TABLE Ingredient (
    [IngredientId]      INT IDENTITY(1,1)   NOT NULL,
    [Name]              VARCHAR(254)        NOT NULL
) ON [recipe]
GO

ALTER TABLE recipe.Ingredient
    ADD CONSTRAINT Ingredient_IngredientId_CPK
        PRIMARY KEY ([IngredientId])
            ON [RECIPE];
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Ingredients table',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Ingredient';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Ingredient identifier',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Ingredient',
    @level2type = N'COLUMN',    @level2name = N'IngredientId';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Ingredient name',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Ingredient',
    @level2type = N'COLUMN',    @level2name = N'Name';
GO