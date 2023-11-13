WITH party_size_cte AS (
    SELECT Date, SUM(PartySize) AS PartySize, ReservationID
    FROM Reservations
    WHERE Reservations.Date >= '2022-01-01'
    GROUP BY Date, ReservationID
)

SELECT Date, PartySize
    , SUM(PartySize) OVER(ORDER BY Date) AS Total
FROM party_size_cte
ORDER BY Date