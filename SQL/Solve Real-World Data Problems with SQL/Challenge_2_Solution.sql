WITH User_Clicks_CTE AS (
    SELECT UserID, Count(*) AS NUM_LINK_CLICKS
    FROM FrontendEventLog
    WHERE EVENTID = 5
    GROUP BY UserID
)

SELECT NUM_LINK_CLICKS, COUNT(NUM_LINK_CLICKS) AS NUM_USERS
FROM User_Clicks_CTE
GROUP BY NUM_LINK_CLICKS