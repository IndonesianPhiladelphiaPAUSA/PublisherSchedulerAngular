CREATE TABLE [dbo].[Capacities] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Capacities] PRIMARY KEY CLUSTERED ([Id] ASC)
);

