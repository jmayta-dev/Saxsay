USE [MWSAXSAYDB];
GO

IF EXISTS(  SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.uspGetAllRecipes', N'P')    )
BEGIN
    DROP PROCEDURE [recipe].[uspGetAllRecipes]
END
GO

/*
|------------------------------------------------------------------------------
| uspGetAllRecipes
|------------------------------------------------------------------------------
| Get recipes
| Example:
|
|   EXEC [recipe].[uspGetAllRecipes];
|
|------------------------------------------------------------------------------
*/
CREATE PROCEDURE [recipe].[uspGetAllRecipes]
AS
BEGIN
    SELECT
        [RecipeId],
        [Name],
        [PreparationTime],
        [Portions],
        [ImageUrl],
        [Preparation],
        [Calories],
        [CommentSuggestion]
    FROM
        [recipe].[Recipe]

END
GO

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Procedure to get all recipes',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'PROCEDURE',     @level1name = N'uspGetAllRecipes';
GO
