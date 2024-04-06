;WITH events_CTE AS
(

    SELECT *, 
            LEAD(value) OVER (PARTITION BY event_type ORDER BY time DESC) AS SecondLatest,
            ROW_NUMBER() OVER (PARTITION BY event_type ORDER BY time DESC) AS RowNumber
    FROM events 
    WHERE event_type IN (
                            SELECT event_type 
                            FROM events
                            GROUP BY event_type
                            HAVING(COUNT(event_type)>1)
                        )
)

SELECT event_type, (value - SecondLatest) AS value
FROM events_CTE
WHERE RowNumber = 1
