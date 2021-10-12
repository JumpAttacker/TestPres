select g.ClientName, MONTH(g.Date) as Month, sum(g.Amount) as SumAmount
from test g
where YEAR(g.Date) = 2017
group by g.ClientName, MONTH(g.Date)
order by SumAmount