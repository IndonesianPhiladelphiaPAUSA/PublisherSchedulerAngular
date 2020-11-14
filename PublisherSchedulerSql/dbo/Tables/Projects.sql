CREATE TABLE [dbo].[Projects] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (256) NULL,
    [Description] VARCHAR (MAX) NULL,
    [IsActive]    INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

