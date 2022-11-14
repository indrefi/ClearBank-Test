MERGE INTO [ClearBank].[AllowedPaymentScheme] AS TARGET
USING (
		  VALUES 
		  (1,'FasterPayments'), 
		  (2,'Bacs'),
		  (3,'Chaps')
	  ) AS SOURCE ([ID],[Name])
ON TARGET.[ID] = SOURCE.[ID]

WHEN NOT MATCHED 
THEN
    INSERT ([ID],[Name]) VALUES (SOURCE.[ID], SOURCE.[Name])

WHEN NOT MATCHED BY SOURCE
THEN DELETE;
