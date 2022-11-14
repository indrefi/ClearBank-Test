IF NOT EXISTS (SELECT 0 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'ClearBank' 
           AND TABLE_NAME = 'AccountStatus')
BEGIN
    CREATE TABLE [ClearBank].[AccountStatus]
    (
	    [ID] INT NOT NULL PRIMARY KEY, 
        [Name] VARCHAR(50) NOT NULL
    )
END;