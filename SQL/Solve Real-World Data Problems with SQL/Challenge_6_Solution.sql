with all_cancelation_reasons AS(

SELECT DISTINCT subscriptionid, CancelationReason1 AS cancelationreason 
    FROM Cancelations

UNION ALL

SELECT DISTINCT subscriptionid, CancelationReason2 AS cancelationreason 
    FROM Cancelations

UNION ALL

SELECT DISTINCT subscriptionid, CancelationReason3 AS cancelationreason 
    FROM Cancelations

)

select 
    cast(count(
        case when cancelationreason = 'Expensive' 
        then subscriptionid end) as float)
    /count(distinct subscriptionid) as percent_expensive
from    
    all_cancelation_reasons
;
