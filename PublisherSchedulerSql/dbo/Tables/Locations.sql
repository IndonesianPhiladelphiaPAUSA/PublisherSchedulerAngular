CREATE TABLE [dbo].[Locations] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [IsActive] INT            NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

