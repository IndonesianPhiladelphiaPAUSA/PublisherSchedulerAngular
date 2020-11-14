CREATE TABLE [dbo].[ProjectPersons] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ProjectId] INT NOT NULL,
    [PersonId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProjectPersons_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([Id]),
    CONSTRAINT [FK_ProjectPersons_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);

