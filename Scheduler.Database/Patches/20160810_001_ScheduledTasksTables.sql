BEGIN
declare @ScriptVersion int = 1
declare @Comment nvarchar(255) = 'Dodanie tabel potrzebnych do Schedulera - ScheduledTask + 2 słowniki.'
	IF EXISTS (
		SELECT *
		FROM   INFORMATION_SCHEMA.TABLES
		WHERE  TABLE_NAME = 'DBVersion') 
	AND EXISTS (SELECT * from DBVersion WHERE version = @ScriptVersion)
	BEGIN
		RETURN
	END
	SET IDENTITY_INSERT DBVersion ON
	INSERT INTO DBVersion  (version, UpgradeDate, Comment) VALUES (@ScriptVersion, GETDATE(),  @Comment)
	SET IDENTITY_INSERT DBVersion OFF
END
GO

CREATE TABLE [dbo].[ScheduledTaskTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ScheduledTaskTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ScheduledTaskStates](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ScheduledTaskStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[ScheduledTasks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PlanedExecutionDate] [datetime2](0) NOT NULL,
	[CreationDate] [datetime2](0) NOT NULL,
	[RelatedObjectId] [bigint] NULL,
	[ScheduledTaskTypeId] [bigint] NOT NULL,
	[ScheduledTaskStateId] [bigint] NOT NULL,
 CONSTRAINT [PK_ScheduledTasks] PRIMARY KEY CLUSTERED 
(
	[ScheduledTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ScheduledTask] UNIQUE NONCLUSTERED 
(
	[ScheduledTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ScheduledTasks]  WITH CHECK ADD  CONSTRAINT [FK_ScheduledTasks_ScheduledTaskState] FOREIGN KEY([ScheduledTaskStateId])
REFERENCES [dbo].[ScheduledTaskState] ([Id])
GO

ALTER TABLE [dbo].[ScheduledTasks] CHECK CONSTRAINT [FK_ScheduledTasks_ScheduledTaskState]
GO

ALTER TABLE [dbo].[ScheduledTasks]  WITH CHECK ADD  CONSTRAINT [FK_ScheduledTasks_ScheduledTaskType] FOREIGN KEY([ScheduledTaskTypeId])
REFERENCES [dbo].[ScheduledTaskTypes] ([Id])
GO

ALTER TABLE [dbo].[ScheduledTasks] CHECK CONSTRAINT [FK_ScheduledTasks_ScheduledTaskType]
GO