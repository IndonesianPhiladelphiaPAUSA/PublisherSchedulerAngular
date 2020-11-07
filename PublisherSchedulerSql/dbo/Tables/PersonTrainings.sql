CREATE TABLE [dbo].[PersonTrainings] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [PersonId]   INT NOT NULL,
    [TrainingId] INT NULL,
    CONSTRAINT [PK_PersonTrainings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonTrainings_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([Id]),
    CONSTRAINT [FK_PersonTrainings_Trainings] FOREIGN KEY ([TrainingId]) REFERENCES [dbo].[Trainings] ([Id])
);

