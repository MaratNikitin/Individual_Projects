SELECT DISTINCT emp.employeeid, 
    emp.NAME AS EMPLOYEE_NAME,  
    man.NAME AS MANAGER_NAME,
    CASE WHEN ISNULL(man.EMAIL,'') <> '' THEN man.EMAIL 
        ELSE emp.EMAIL END AS CONTACT_EMAIL
FROM employees as emp
    LEFT JOIN employees AS man ON emp.managerid = man.employeeid
    LEFT JOIN sales ON sales.SALESEMPLOYEEID = emp.employeeid
WHERE ISNULL(SaleId,0) <> 0