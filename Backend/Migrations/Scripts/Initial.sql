IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Recipes] (
    [Id] uniqueidentifier NOT NULL,
    [Title_Value] varchar NOT NULL,
    [Description_Value] varchar NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [ModifiedAt] datetimeoffset NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Recipes_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Ingridient] (
    [RecipeId] uniqueidentifier NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Name] varchar NOT NULL,
    [Qty] float NOT NULL,
    [Measure] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Ingridient] PRIMARY KEY ([RecipeId], [Id]),
    CONSTRAINT [FK_Ingridient_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Step] (
    [RecipeId] uniqueidentifier NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [Name] varchar NOT NULL,
    [Description] varchar NOT NULL,
    [Picture] varchar NULL,
    CONSTRAINT [PK_Step] PRIMARY KEY ([RecipeId], [Id]),
    CONSTRAINT [FK_Step_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Recipes_CategoryId] ON [Recipes] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231129123424_Initial', N'7.0.5');
GO

COMMIT;
GO

