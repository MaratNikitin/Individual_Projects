WITH Months_CTE AS(
select 
    date_trunc('month', orderdate) as order_month, 
    sum(revenue) as monthly_revenue
from 
    subscriptions
group by 
    date_trunc('month', orderdate)
)

SELECT Months_CTE.order_month AS Current_Month, 
    DATEADD(MONTH, -1, Months_CTE.order_month) AS Previous_Month,
    Months_CTE.monthly_revenue AS Current_Revenue,
    Previous_Month_CTE.monthly_revenue AS Previous_Revenue
FROM Months_CTE
    LEFT JOIN Months_CTE AS Previous_Month_CTE ON Previous_Month_CTE.order_month = DATEADD(MONTH, -1, Months_CTE.order_month)
WHERE Months_CTE.monthly_revenue > Previous_Month_CTE.monthly_revenue

