USE [MWSAXSAYDB];
GO

IF EXISTS ( SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.uspCreateRecipe', N'P') )
BEGIN
    DROP PROCEDURE [recipe].[uspCreateRecipe];
END
GO

CREATE PROCEDURE [recipe].[uspCreateRecipe]
    @Name                  VARCHAR(254),
    @PreparationTime       CHAR(5),
    @Portions              INT,
    @ImageUrl              VARCHAR(254),
    @Preparation           VARCHAR(MAX),
    @Calories              FLOAT,
    @CommentSuggestions    VARCHAR(MAX),
    @RecipeId              INT OUTPUT
AS
SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRANSACTION;
    INSERT INTO [recipe].[Recipe]
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
        @Name,
        @PreparationTime,
        @Portions,
        @ImageUrl,
        @Preparation,
        @Calories,
        @CommentSuggestions
    )

    SET @RecipeId = @@IDENTITY;

COMMIT TRANSACTION;
GO
