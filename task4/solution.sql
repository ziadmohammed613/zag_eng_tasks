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