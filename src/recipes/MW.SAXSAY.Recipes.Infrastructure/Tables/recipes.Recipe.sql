-- Tabla para Recetas
DROP TABLE IF EXISTS [Recipe];
CREATE TABLE IF NOT EXISTS [Recipe] (
    [Id] INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    [Name] TEXT UNIQUE NOT NULL,
    [Portions] INTEGER NULL,
    [Difficulty] INTEGER NULL,
    [CommentSuggestion] TEXT NULL
);

-- Tabla para Ingredientes
DROP TABLE IF EXISTS [Ingredient];
CREATE TABLE IF NOT EXISTS [Ingredient] (
    [Id] INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    [Description] TEXT UNIQUE NOT NULL
);

-- Tabla para Categorías
DROP TABLE IF EXISTS [Category];
CREATE TABLE IF NOT EXISTS [Category] (
    [Id] INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    [Description] TEXT UNIQUE NOT NULL
)

-- Tabla detalle para Categorias y Recetas
DROP TABLE IF EXISTS [RecipeCategory];
CREATE TABLE IF NOT EXISTS [RecipeCategory] (
    [Id] INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    [RecipeId] INTEGER NOT NULL,
    [CategoryId] INTEGER NOT NULL,
    UNIQUE ([RecipeId], [CategoryId])
);

--==============================
-- INSERCION DE DATOS EN TABLAS
--==============================
DELETE FROM [Category];
UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE [name] = 'Category';
INSERT INTO [Category] ([Description])
VALUES
    ('Salsa'),
    ('Sopa');

DELETE FROM [Ingredient];
UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE [name] = 'Ingredient';
INSERT INTO [Ingredient] ([Description])
VALUES
    ('aceite vegetal'),
    ('ajo'),
    ('ajonjolí'),
    ('cebollita china'),
    ('cilantro'),
    ('jugo de limón'),
    ('mostaza'),
    ('orégano'),
    ('perejil'),
    ('pimiento'),
    ('sal'),
    ('tomate'),
    ('vinagre');

DELETE FROM [Recipe];
UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE [name] = 'Recipe';
INSERT INTO [Recipe] ([Name])
VALUES
    ('ají de pollería'),
    ('ketchup'),
    ('mayonesa light'),
    ('vinagreta de pollería');

DELETE FROM [RecipeCategory];
UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE [name] = 'RecipeCategory';
INSERT INTO [RecipeCategory] ([CategoryId], [RecipeId])
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (1, 4);
