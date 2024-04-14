;with base as
(
	select [placeholder] c.StateOrRegion, c.City, 
			sum([placeholder]) over (Partition by [placeholder]) TotalSalesPerState,
			sum([placeholder]) over (Partition by [placeholder], [placeholder]) TotalSalesPerCity
	from Sales.Customer c
	inner join Sales.[Order] o
	on o.CustomerID = c.CustomerID
)
select b.StateOrRegion, b.City, format(b.[placeholder], 'C2') TotalSalesPerState,
	format(b.[placeholder], 'C2') TotalSalesPerCity,
	format(percentile_cont([placeholder]) [placeholder] (Order by b.[placeholder]) over (Partition by b.[placeholder]), 'C2') [MedianSalesPerState],
	format(cume_dist() over (Order by b.[placeholder] desc), 'P') [CityRank],
	format(percent_rank() over (Partition by b.[placeholder] Order by b.[placeholder] desc), 'P') [StateCityRank]
from base b
order by [CityRank]