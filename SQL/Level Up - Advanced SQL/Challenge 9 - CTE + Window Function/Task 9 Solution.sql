-- Find all sales where car purchased was electric:
WITH car_sales_cte AS (
SELECT employee.employeeId, firstName, lastName, model, COUNT(model.modelId) AS NumberOfCarsSold
FROM sales
	JOIN employee ON employee.employeeId = sales.employeeId
	JOIN inventory ON sales.inventoryId = inventory.inventoryId
	JOIN model ON model.modelId = inventory.inventoryId
GROUP BY firstName, lastName, model.modelId
ORDER BY lastName, firstName, NumberOfCarsSold DESC
)
SELECT firstName, lastName, model, NumberOfCarsSold, 
	RANK() over(PARTITION BY employeeId ORDER BY NumberOfCarsSold DESC) AS CarModelRank
FROM car_sales_cte