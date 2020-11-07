CREATE TABLE [dbo].[Trainings] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (256) NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Training] PRIMARY KEY CLUSTERED ([Id] ASC)
);

