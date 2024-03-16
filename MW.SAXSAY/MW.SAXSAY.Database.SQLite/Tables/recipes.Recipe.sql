-- Creación de tabla Recetas
CREATE TABLE IF NOT EXISTS recipe.Recipes (
    [Id] INTEGER PRIMARY KEY,
    [Name] TEXT NULL,
    [PreparationTime] TEXT NULL,
    [PreparationSteps] TEXT NULL,
    [Portions] INTEGER NOT NULL,
    [ImageUrl] TEXT NULL,
    [CommentSuggestion] TEXT NULL
)