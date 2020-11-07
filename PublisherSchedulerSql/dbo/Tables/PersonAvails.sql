CREATE TABLE [dbo].[PersonAvails] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [BeginTime]   DATETIME2 (7) NOT NULL,
    [EndTime]     DATETIME2 (7) NOT NULL,
    [IsAvailable] BIT           NOT NULL,
    [PersonId]    INT           NOT NULL,
    CONSTRAINT [PK_PersonAvails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonAvails_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([Id]) ON DELETE CASCADE
);

