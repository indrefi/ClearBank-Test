IF NOT EXISTS (SELECT 0
               FROM INFORMATION_SCHEMA.SCHEMATA 
               WHERE schema_name='ClearBank')
BEGIN
  EXEC sp_executesql N'CREATE SCHEMA ClearBank';
END