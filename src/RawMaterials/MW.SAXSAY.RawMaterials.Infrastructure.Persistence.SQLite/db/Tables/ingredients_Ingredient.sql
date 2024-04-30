DROP TABLE IF EXISTS ingredients_Ingredient;

CREATE TABLE IF NOT EXISTS ingredients_Ingredient
(
    Id              INTEGER PRIMARY KEY UNIQUE NOT NULL,
    Description     TEXT UNIQUE NOT NULL,
    IsActive        INTEGER NOT NULL,
    BaseUnitId      INTEGER NULL
);