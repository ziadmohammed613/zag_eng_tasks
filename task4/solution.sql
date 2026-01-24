-- problem 1
select *
from Cinema
where id % 2 != 0 and [description] != 'boring'
order by rating desc;
-- problem 2
select project_id , round(avg(cast(experience_years as float)) , 2) as average_years
from Project
inner join Employee
on Project.employee_id = Employee.employee_id
group by project_id;
-- problem 3
select format(trans_date, 'yyyy-MM') as [month] , country ,
count(*) as trans_count ,
count(case when [state] = 'approved' then 1 else null end) as approved_count ,
sum(amount) as trans_total_amount ,
sum(case when [state] = 'approved' then amount else 0 end) as approved_total_amount
from Transactions
group by format(trans_date, 'yyyy-MM') , country;
-- problem 4
select teacher_id , count(distinct subject_id) as cnt
from Teacher
group by teacher_id;