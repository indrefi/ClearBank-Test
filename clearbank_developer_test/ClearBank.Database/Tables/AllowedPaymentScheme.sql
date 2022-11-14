IF NOT EXISTS (SELECT 0 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'ClearBank' 
           AND TABLE_NAME = 'AllowedPaymentScheme')
BEGIN
    CREATE TABLE [ClearBank].[AllowedPaymentScheme]
    (
	    [ID] INT NOT NULL PRIMARY KEY, 
        [Name] VARCHAR(50) NOT NULL
    )
END;