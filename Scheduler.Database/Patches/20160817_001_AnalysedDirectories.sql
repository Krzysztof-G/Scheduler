BEGIN
declare @ScriptVersion int = 3
declare @Comment nvarchar(255) = 'Dodanie tabeli AnalysedDirectory i AnalyseType User.'
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

CREATE TABLE [dbo].[AnalyseType](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_AnalizeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[AnalysedDirectory](
	[Id] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Path] [varchar](max) NOT NULL,
	[AnalyseTypeId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.AnalizedDirectory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[AnalysedDirectory]  WITH CHECK ADD  CONSTRAINT [FK_AnalizedDirectory_AnalizeType] FOREIGN KEY([AnalyseTypeId])
REFERENCES [dbo].[AnalyseType] ([Id])
GO

ALTER TABLE [dbo].[AnalysedDirectory] CHECK CONSTRAINT [FK_AnalizedDirectory_AnalizeType]
GO