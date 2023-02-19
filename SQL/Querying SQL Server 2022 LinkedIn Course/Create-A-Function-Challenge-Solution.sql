USE WideWorldImporters
GO

CREATE OR ALTER FUNCTION Warehouse.funcEvaluateTemperatures(@Temperature AS DECIMAL(10,2))
RETURNS NVARCHAR(60)
AS
BEGIN
	DECLARE @Output NVARCHAR(60)
	BEGIN
		SET @Output = 
		CASE
			WHEN @Temperature < 3.5 THEN 'Too Cold'
			WHEN @Temperature > 4.0 THEN 'Too Hot'
			ELSE 'Just Right'
		END
	END
	RETURN @Output
END;
GO

-- Testing the newly created function:
SELECT TOP 1000 Temperature 
	,Warehouse.funcEvaluateTemperatures(Temperature) AS [Temperature Evaluation]
FROM Warehouse.ColdRoomTemperatures

