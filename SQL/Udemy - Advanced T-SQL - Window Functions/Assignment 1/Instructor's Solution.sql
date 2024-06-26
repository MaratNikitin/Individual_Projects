/*Question 1 - 3 */
;with Base as
(
	select *
		,ntile(4) over (Order by CustomerRating desc) RatingGroup
	from Employees
)
select 	ID,
		FirstName,
		LastName,
		BaseSalary,
		CustomerRating,
		((80 - (RatingGroup * 15))) as Bonus,
		cast((BaseSalary * ((100 + (80 - (RatingGroup * 15)))) / 100) as decimal(14,2)) TotalSalary
from Base;

/*Question 4 */
;with Base as
(
	select *
		,ntile(4) over (Order by InternalRating desc) RatingGroup
	from Employees
)
select 	ID,
		FirstName,
		LastName,
		BaseSalary,
		InternalRating,
		((80 - (RatingGroup * 15))) as Bonus,
		cast((BaseSalary * ((100 + (80 - (RatingGroup * 15)))) / 100) as decimal(14,2)) TotalSalary
from Base;


/*Question 5 */
;with Base as
(
	select *
		,ntile(2) over (Order by InternalRating desc) RatingGroup
	from Employees
)
select 	ID,
		FirstName,
		LastName,
		BaseSalary,
		InternalRating,
		((75 - (RatingGroup * 25))) as Bonus,
		cast((BaseSalary * ((100 + (80 - (RatingGroup * 15)))) / 100) as decimal(14,2)) TotalSalary
from Base;


/*Question 6 */
;with base as
(
	select *
		,row_number() over (Partition by CustomerRating Order by CustomerRating desc) [CustomerRatingRank]
	from Employees
)
select b.*
from base b
where b.CustomerRating in (select CustomerRating from base where CustomerRatingRank > 1);