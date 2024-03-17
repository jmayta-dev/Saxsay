USE [MWSAXSAYDB];
GO

IF EXISTS ( SELECT [object_id] FROM [sys].[objects]
            WHERE [object_id] = OBJECT_ID(N'recipe.Recipe', N'U')   )
BEGIN
    DROP TABLE [recipe].[Recipe]
END
GO

CREATE TABLE [recipe].[Recipe] (
    [RecipeId]              INT IDENTITY(1,1)   NOT NULL,
    [Name]                  VARCHAR(254)        NOT NULL,
    [PreparationTime]       CHAR(5)             NULL,
    [Portions]              INT                 NULL,
    [ImageUrl]              VARCHAR(254)        NULL,
    [Preparation]           VARCHAR(MAX)        NULL,
    [Calories]              FLOAT               NULL,
    [CommentSuggestion]     VARCHAR(MAX)        NULL
)
GO

ALTER TABLE [recipe].[Recipe]
    ADD CONSTRAINT Recipe_RecipeId_CPK
        PRIMARY KEY ([RecipeId]);
GO

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Recipe table.',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Recipe identifier',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'RecipeId';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Recipe name',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'Name';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Preparation time expresed like "HH:mm"',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'PreparationTime';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Portions / diners',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'Portions';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Image URL',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'ImageUrl';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Preparation steps',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'Preparation';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Calories quantity',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'Calories';

EXEC sys.sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Comments and suggestions',
    @level0type = N'SCHEMA',    @level0name = N'recipe',
    @level1type = N'TABLE',     @level1name = N'Recipe',
    @level2type = N'COLUMN',    @level2name = N'CommentSuggestion';
