USE MWSAXSAYDB;
GO

IF EXISTS ( SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.uspCreateRecipe', N'P') )
BEGIN
    DROP PROCEDURE recipe.uspCreateRecipe;
END
GO

CREATE PROCEDURE recipe.uspCreateRecipe
    @pName VARCHAR(254),
    @pPreparationTime CHAR(5),
    @pPortions INT,
    @pImageUrl VARCHAR(254),
    @pPreparation VARCHAR(MAX),
    @pCalories FLOAT,
    @pCommentSuggestions VARCHAR(MAX),
    @pRecipeId INT OUTPUT
AS
SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRANSACTION;
    INSERT INTO recipe.Recipe
    (
        [Name],
        [PreparationTime],
        [Portions],
        [ImageUrl],
        [Preparation],
        [Calories],
        [CommentSuggestions]
    )
    VALUES
    (
        @pName,
        @pPreparationTime,
        @pPortions,
        @pImageUrl,
        @pPreparation,
        @pCalories,
        @pCommentSuggestions
    )

    SET @pRecipeId = @@IDENTITY;

COMMIT TRANSACTION;
GO