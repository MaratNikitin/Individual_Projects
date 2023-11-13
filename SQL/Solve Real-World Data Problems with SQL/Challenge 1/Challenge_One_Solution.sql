WITH Monthly_Revenue_CTE AS
    (SELECT PRODUCTNAME, MONTH(OrderDate) AS OrderMonth,
        SUM(Revenue) AS Rev_Sum
    FROM Subscriptions
        JOIN Products ON Subscriptions.PRODUCTID = Products.PRODUCTID
    WHERE YEAR(ORDERDATE) = '2022'
    GROUP BY PRODUCTNAME, OrderMonth)

SELECT PRODUCTNAME, 
    MIN(Rev_Sum) AS MIN_REV,
    MAX(Rev_Sum) AS MAX_REV,
    AVG(Rev_Sum) AS AVG_REV,
    STDDEV(Rev_Sum) AS STD_DEV_REV,
FROM Monthly_Revenue_CTE   
GROUP BY PRODUCTNAME