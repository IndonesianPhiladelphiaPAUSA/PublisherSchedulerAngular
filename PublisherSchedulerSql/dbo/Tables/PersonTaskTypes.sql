CREATE TABLE [dbo].[PersonTaskTypes] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [TaskTypeId] INT NOT NULL,
    [PersonId]   INT NOT NULL,
    CONSTRAINT [PK_PersonTaskTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

