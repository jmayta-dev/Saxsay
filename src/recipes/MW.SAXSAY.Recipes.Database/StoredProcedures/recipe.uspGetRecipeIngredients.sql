USE [MWSAXSAYDB];
GO

IF EXISTS ( SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.uspGetRecipeIngredients', N'P') )
BEGIN
    DROP PROCEDURE [recipe].[uspGetRecipeIngredients];
END
GO
/*
|------------------------------------------------------------------------------
| uspGetRecipeIngredients
|------------------------------------------------------------------------------
| Get recipe ingredients
| Example:
|
    EXEC [recipe].[uspGetRecipeIngredients]
        @RecipeId = 1;
|
|------------------------------------------------------------------------------
*/
CREATE PROCEDURE [recipe].[uspGetRecipeIngredients]
    @RecipeId   INT
AS
BEGIN
    SELECT
        [ING].[IngredientId],
        [ING].[RawMaterialId],
        [ING].[RecipeId],
        [ING].[Quantity],
        [RMA].[Name] AS [RawMaterialName],
        [REC].[Name] AS [RecipeName]
    FROM [recipe].[Ingredient] [ING]
        INNER JOIN [recipe].[RawMaterial] [RMA]
            ON [ING].[RawMaterialId] = [RMA].[RawMaterialId]
        INNER JOIN [recipe].[Recipe] [REC]
            ON [ING].[RecipeId] = [REC].[RecipeId]
    WHERE [ING].[RecipeId] = @RecipeId
END
GO
