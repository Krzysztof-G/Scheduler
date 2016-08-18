IF NOT EXISTS (SELECT * FROM AnalyseType)
BEGIN 
	SET IDENTITY_INSERT AnalyseType ON
	INSERT INTO AnalyseType  (Id, Name)  VALUES (1, 'CleanDisposableFiles')
	INSERT INTO AnalyseType  (Id, Name)  VALUES (2, 'CreateDailyDirectories')
	SET IDENTITY_INSERT AnalyseType OFF	
END
GO