BEGIN
declare @ScriptVersion int = 2
declare @Comment nvarchar(255) = 'Dodanie tabeli User.'
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

CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO