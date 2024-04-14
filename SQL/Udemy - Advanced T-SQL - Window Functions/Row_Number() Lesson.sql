-- Udemy Course: "Advanced T-SQL: Window Functions for Advanced Querying"

SELECT *,
	LongestSongRank = ROW_NUMBER() OVER (ORDER BY Milliseconds DESC)
FROM [Chinook].[dbo].[Track]
ORDER BY LongestSongRank ASC

GO

; WiTH TrackPage_CTE AS
(
	SELECT *,
		RowNumber = ROW_NUMBER() OVER (ORDER BY TrackID ASC)
	FROM Chinook.dbo.Track
)
SELECT *
FROM TrackPage_CTE
WHERE RowNumber <=10

GO

