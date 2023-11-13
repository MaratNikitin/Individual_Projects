WITH order_prices_cte AS (
    SELECT o.OrderID, SUM(Price) AS ThisOrderPrice
    FROM Orders o
        JOIN OrdersDishes od ON o.ORDERID = od.ORDERID
        JOIN Dishes d ON d.DISHID = od.DISHID
    WHERE OrderDate >= '2022-01-01'
    GROUP BY o.OrderID
    ORDER BY OrderID
)

SELECT OrderID, ThisOrderPrice, 
    (ThisOrderPrice - LAG(ThisOrderPrice,1) OVER(ORDER BY OrderID)) AS DiffFromPrev
FROM order_prices_cte