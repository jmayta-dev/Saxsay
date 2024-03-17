INSERT INTO recipe.RawMaterial
(
    [Name]
)
VALUES
(
    'huevo'
)
GO

INSERT INTO recipe.Ingredient
(
    [RawMaterialId],
    [RecipeId],
    [Quantity]
)
VALUES
(
    1,
    1,
    1
)