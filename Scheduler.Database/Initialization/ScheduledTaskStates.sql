IF NOT EXISTS (SELECT * FROM ScheduledTaskStates)
BEGIN 
	SET IDENTITY_INSERT ScheduledTaskStates ON
	INSERT INTO ScheduledTaskStates  (Id, Name)  VALUES (1, 'Pending')
	INSERT INTO ScheduledTaskStates  (Id, Name)  VALUES (2, 'Succeed')
	INSERT INTO ScheduledTaskStates  (Id, Name)  VALUES (3, 'Error')
	INSERT INTO ScheduledTaskStates  (Id, Name)  VALUES (4, 'Canceled')
	INSERT INTO ScheduledTaskStates  (Id, Name)  VALUES (5, 'Executing')
	SET IDENTITY_INSERT ScheduledTaskStates OFF	
END
GO