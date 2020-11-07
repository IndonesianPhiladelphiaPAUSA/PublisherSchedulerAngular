CREATE TABLE [dbo].[Assignments] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [SlotId]     INT NOT NULL,
    [PersonId]   INT NOT NULL,
    [LocationId] INT NOT NULL,
    CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Assignments_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Assignments_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Assignments_Slots] FOREIGN KEY ([SlotId]) REFERENCES [dbo].[Slots] ([Id]) ON DELETE CASCADE
);

