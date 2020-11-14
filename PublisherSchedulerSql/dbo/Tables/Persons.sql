CREATE TABLE [dbo].[Persons] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [IsActive]      BIT            NULL,
    [SecurityLevel] INT            NULL,
    [aspnetuserid]  NVARCHAR (128) NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

