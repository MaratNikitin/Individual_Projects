-- Find all sales where car purchased was electric:
SELECT soldDate, salesAmount, colour, year
FROM sales
	JOIN inventory ON sales.inventoryId = inventory.inventoryId
	JOIN model ON model.modelId = inventory.inventoryId
WHERE EngineType = 'Electric'