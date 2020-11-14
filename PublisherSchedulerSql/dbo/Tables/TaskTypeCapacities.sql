CREATE TABLE [dbo].[TaskTypeCapacities] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [TaskType_Id] INT NOT NULL,
    [Capacity_Id] INT NOT NULL,
    CONSTRAINT [PK_TaskTypeCapacities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TaskTypeCapacities_Capacity] FOREIGN KEY ([Capacity_Id]) REFERENCES [dbo].[Capacities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TaskTypeCapacities_TaskType] FOREIGN KEY ([TaskType_Id]) REFERENCES [dbo].[TaskTypes] ([Id]) ON DELETE CASCADE
);

