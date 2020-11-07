CREATE TABLE [dbo].[TaskTypes] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [ProjectId] INT            NOT NULL,
    [IsActive]  INT            NULL,
    CONSTRAINT [PK_TaskTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

