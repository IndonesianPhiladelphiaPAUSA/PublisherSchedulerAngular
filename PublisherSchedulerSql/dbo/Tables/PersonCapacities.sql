CREATE TABLE [dbo].[PersonCapacities] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [PersonId]   INT NOT NULL,
    [CapacityId] INT NOT NULL,
    CONSTRAINT [PK_PersonCapacities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonCapacities_Capacities] FOREIGN KEY ([CapacityId]) REFERENCES [dbo].[Capacities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonCapacities_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([Id]) ON DELETE CASCADE
);

