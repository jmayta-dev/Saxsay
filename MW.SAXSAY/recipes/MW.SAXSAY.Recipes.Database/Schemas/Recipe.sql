USE MWSAXSAYDB;
GO

IF EXISTS ( SELECT object_id FROM sys.objects
            WHERE [object_id] = SCHEMA_ID('recipe') )
    DROP SCHEMA recipe;
GO

CREATE SCHEMA recipe;
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'Contains objects related to recipes.',
    @level0type = N'SCHEMA',    @level0name = N'recipe';
GO