MERGE INTO [ClearBank].[Account] AS TARGET
USING (
		  VALUES 
		  ('RO06BTRL019393493', 1000.0, 1, 1), 
		  ('RO06BTRL019393434', 200.0,  1, 1)
	  ) AS SOURCE ([AccountNumber],[Balance],[AccountStatusID],[AccountAllowedPaymentSchemeID])
ON TARGET.[AccountNumber] = SOURCE.[AccountNumber]

WHEN NOT MATCHED 
THEN
    INSERT ([AccountNumber],[Balance],[AccountStatusID],[AccountAllowedPaymentSchemeID]) VALUES (SOURCE.[AccountNumber],SOURCE.[Balance],SOURCE.[AccountStatusID],SOURCE.[AccountAllowedPaymentSchemeID])

WHEN NOT MATCHED BY SOURCE
THEN DELETE;