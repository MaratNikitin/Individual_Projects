; WITH host_scores_CTE AS 
(
    SELECT host_team AS team_id,
        CASE WHEN (host_goals > guest_goals) THEN 3 
            WHEN (host_goals = guest_goals) THEN 1 
            ELSE 0 END AS scores
    FROM matches
)

, guest_scores_CTE AS 
(
    SELECT guest_team AS team_id,
        CASE WHEN (host_goals < guest_goals) THEN 3 
            WHEN (host_goals = guest_goals) THEN 1 
            ELSE 0 END AS scores
    FROM matches
)

, all_scores_CTE AS
(
    SELECT * FROM host_scores_CTE
    UNION ALL
    SELECT * FROM guest_scores_CTE
)

SELECT t.team_id, t.team_name, COALESCE(SUM(scores),0) AS num_points
FROM teams t
    LEFT JOIN all_scores_CTE s ON s.team_id = t.team_id
GROUP BY t.team_id, t.team_name
ORDER BY num_points DESC, team_id
