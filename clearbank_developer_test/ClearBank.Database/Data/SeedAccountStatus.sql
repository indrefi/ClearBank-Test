MERGE INTO [ClearBank].[AccountStatus] AS TARGET
USING (
		  VALUES 
		  (1,'Live'), 
		  (2,'Disabled'),
		  (3,'InboundPaymentsOnly')
	  ) AS SOURCE ([ID],[Name])
ON TARGET.[ID] = SOURCE.[ID]

WHEN NOT MATCHED 
THEN
    INSERT ([ID],[Name]) VALUES (SOURCE.[ID], SOURCE.[Name])

WHEN NOT MATCHED BY SOURCE
THEN DELETE;
