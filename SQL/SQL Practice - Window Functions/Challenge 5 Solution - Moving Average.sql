-- Version 1
SELECT CustomerID, o.OrderID, SUM(Price) AS OrderTotal,
    ROUND(AVG(SUM(Price)) OVER(PARTITION BY CustomerID ORDER BY CustomerID, o.ORDERID ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING),2) AS MovingAvg
FROM Orders o
    JOIN OrdersDishes od ON o.ORDERID = od.ORDERID
    JOIN Dishes d ON d.DISHID = od.DISHID
GROUP BY o.OrderID
ORDER BY CustomerID, o.ORDERID

-- Version 2
SELECT CustomerID, o.OrderID, SUM(Price) AS OrderTotal,
    ROUND(AVG(SUM(Price)) OVER(PARTITION BY CustomerID ORDER BY CustomerID, o.ORDERID ROWS BETWEEN 2 PRECEDING AND CURRENT ROW),2) AS MovingAvg
FROM Orders o
    JOIN OrdersDishes od ON o.ORDERID = od.ORDERID
    JOIN Dishes d ON d.DISHID = od.DISHID
GROUP BY o.OrderID
ORDER BY CustomerID, o.ORDERID