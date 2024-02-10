USE MWSAXSAYDB;
GO

-- TABLA INTERMEDIA INGREDIENTES-RECETAS
IF EXISTS ( SELECT object_id FROM sys.objects
            WHERE object_id = OBJECT_ID(N'recipe.Ingredient', N'U')   )
BEGIN
    DROP TABLE recipe.Ingredient
END
GO

CREATE TABLE IngredientRecipe (
    [IngredientId]      INT IDENTITY(1,1)   NOT NULL,
    [RecipeId]          VARCHAR(254)        NOT NULL
) ON [recipe]
GO

ALTER TABLE recipe.IngredientRecipe
    ADD CONSTRAINT IngredientRecipe_IngredientId_RecipeId_CPK
        PRIMARY KEY NONCLUSTERED ([IngredientId],[RecipeId])
            ON [RECIPE];
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Raw Material table',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'IngredientRecipe';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Linked Ingredient identifier',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'IngredientRecipe',
    @level2type = N'COLUMN',    @level2name = N'IngredientId';
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Linked Recipe identifier',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'IngredientRecipe',
    @level2type = N'COLUMN',    @level2name = N'RecipeId';
GO