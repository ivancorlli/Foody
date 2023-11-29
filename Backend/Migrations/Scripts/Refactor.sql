BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Step]') AND [c].[name] = N'Picture');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Step] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Step] ALTER COLUMN [Picture] varchar(500) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Step]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Step] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Step] ALTER COLUMN [Name] varchar(250) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Step]') AND [c].[name] = N'Description');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Step] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Step] ALTER COLUMN [Description] varchar(750) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'Title_Value');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Recipes] ALTER COLUMN [Title_Value] varchar(250) NOT NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'Description_Value');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Recipes] ALTER COLUMN [Description_Value] varchar(750) NOT NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ingridient]') AND [c].[name] = N'Name');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Ingridient] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Ingridient] ALTER COLUMN [Name] varchar(250) NOT NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'Name');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Categories] ALTER COLUMN [Name] varchar(150) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231129160221_Refactor', N'7.0.5');
GO

COMMIT;
GO

