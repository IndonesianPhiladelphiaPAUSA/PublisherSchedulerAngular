CREATE TABLE [dbo].[Slots] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProjectId]   INT            NOT NULL,
    [BeginTime]   DATETIME2 (7)  NOT NULL,
    [EndTime]     DATETIME2 (7)  NOT NULL,
    [IsActive]    INT            NULL,
    [Description] NVARCHAR (MAX) NULL,
    [TaskTypeId]  INT            NOT NULL,
    [TrainingId]  INT            NULL,
    CONSTRAINT [PK_Slots] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Slots_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_Slots_TaskTypes] FOREIGN KEY ([TaskTypeId]) REFERENCES [dbo].[TaskTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Slots_Trainings] FOREIGN KEY ([TrainingId]) REFERENCES [dbo].[Trainings] ([Id])
);

