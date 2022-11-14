IF NOT EXISTS (SELECT 0 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'ClearBank' 
           AND TABLE_NAME = 'Account')
BEGIN
    CREATE TABLE [ClearBank].[Account]
    (
	    [AccountNumber] VARCHAR(100) NOT NULL PRIMARY KEY, 
        [Balance] DECIMAL(13,3) NOT NULL,
        [AccountStatusID] INT  NOT NULL,
        [AccountAllowedPaymentSchemeID] INT NOT NULL,
        CONSTRAINT [FK_AccountStatus_AccountStatusID] FOREIGN KEY ([AccountStatusID]) REFERENCES [ClearBank].[AccountStatus]([ID]),
        CONSTRAINT [FK_AllowedPaymentScheme_AccountAllowedPaymentSchemeID] FOREIGN KEY ([AccountAllowedPaymentSchemeID]) REFERENCES [ClearBank].[AllowedPaymentScheme]([ID])
    )
END;