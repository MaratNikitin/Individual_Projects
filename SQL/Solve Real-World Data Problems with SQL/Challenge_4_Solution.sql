SELECT USERID,
    SUM(CASE WHEN log.EVENTID = 1 THEN 1 ELSE 0 END) AS VIEWEDHELPCENTERPAGE,
    SUM(CASE WHEN log.EVENTID = 2 THEN 1 ELSE 0 END) AS CLICKEDFAQS,
    SUM(CASE WHEN log.EVENTID = 3 THEN 1 ELSE 0 END) AS CLICKEDCONTACTSUPPORT,
    SUM(CASE WHEN log.EVENTID = 4 THEN 1 ELSE 0 END) AS SUBMITTEDTICKET
FROM FrontendEventDefinitions def
    JOIN FrontendEventLog log ON def.EVENTID = log.EVENTID
WHERE def.EVENTTYPE = 'Customer Support'
GROUP BY USERID