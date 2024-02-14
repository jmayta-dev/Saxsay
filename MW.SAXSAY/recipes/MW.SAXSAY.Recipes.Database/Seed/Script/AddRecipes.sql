USE [MWSAXSAYDB];
GO
SET XACT_ABORT ON;
SET NOCOUNT ON;
BEGIN TRANSACTION;
    INSERT INTO [recipe].[Recipe]
    (
        [Name],
        [PreparationTime],
        [Portions],
        [ImageUrl],
        [Preparation],
        [Calories],
        [CommentSuggestion]
    )
    VALUES 
    (
        'Arroz con huevo',
        '00:15',
        1,
        NULL,
        'Preparar arroz, poner a freír un huevo. Servir.',
        NULL,
        NULL
    )
COMMIT TRANSACTION;
SET XACT_ABORT OFF;