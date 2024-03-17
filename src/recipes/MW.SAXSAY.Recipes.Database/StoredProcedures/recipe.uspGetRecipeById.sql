USE [MWSAXSAYDB];
GO


IF EXISTS(  SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.uspGetRecipeById', N'P')    )
BEGIN
    DROP PROCEDURE [recipe].[uspGetRecipeById]
END
GO

/*
|------------------------------------------------------------------------------
| uspGetRecipeById
|------------------------------------------------------------------------------
| Get recipes
| Example:
|
    EXEC [recipe].[uspGetRecipeById]
        @RecipeId = 1;
|
|------------------------------------------------------------------------------
*/
CREATE PROCEDURE [recipe].[uspGetRecipeById]
    @RecipeId INT
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
        [recipe].[Recipe] [REC]
    WHERE
        [REC].[RecipeId] = @RecipeId
END
GO

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Procedure to get a recipe by id',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'PROCEDURE',     @level1name = N'uspGetRecipeById';
GO
