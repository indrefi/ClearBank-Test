/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
BEGIN TRAN

SET QUOTED_IDENTIFIER ON;
GO

SET ANSI_NULLS ON;
GO

SET ANSI_PADDING ON;
GO

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
GO

-- SCHEMAS
:r .\Schemas\ClearBank.sql

-- TABLES
:r .\Tables\AccountStatus.sql
:r .\Tables\AllowedPaymentScheme.sql
:r .\Tables\Account.sql

-- DATA SEED
:r .\Data\SeedAccountStatus.sql
:r .\Data\SeedAllowedPaymentScheme.sql
:r .\Data\SeedAccount.sql

GO

COMMIT TRAN
