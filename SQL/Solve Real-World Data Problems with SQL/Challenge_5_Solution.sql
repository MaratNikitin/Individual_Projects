With all_subscriptions as(

--UNION subscriptions tables here
SELECT * FROM SubscriptionsProduct1 WHERE ACTIVE = 1

UNION

SELECT * FROM SubscriptionsProduct2 WHERE ACTIVE = 1

)
select
	date_trunc('year', expirationdate) as exp_year, 
	count(*) as subscriptions
from 
	all_subscriptions
group by 
	date_trunc('year', expirationdate)