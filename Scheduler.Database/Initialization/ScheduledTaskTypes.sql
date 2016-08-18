IF NOT EXISTS (SELECT * FROM ScheduledTaskTypes)
BEGIN 
	SET IDENTITY_INSERT ScheduledTaskTypes ON
	INSERT INTO ScheduledTaskTypes  (Id, Name)  VALUES (101, 'TestEmail')
	INSERT INTO ScheduledTaskTypes  (Id, Name)  VALUES (201, 'CleanDisposableFiles')
	INSERT INTO ScheduledTaskTypes  (Id, Name)  VALUES (202, 'CreateDailyDirectories')
	SET IDENTITY_INSERT ScheduledTaskTypes OFF	
END
GO