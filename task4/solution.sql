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
-- problem 5
select employee_id
from Employees
where salary < 30000 and manager_id not in (select employee_id from Employees)
order by employee_id;
-- problem 6
select ( case when id = ( select count(*) from Seat ) 
            and (select count(*) from Seat) % 2 = 1 then id else
    ( case when id % 2 = 0 then id - 1 else id + 1 end )
end ) as id , student
from Seat
order by id asc;
-- problem 7
select employee_id , department_id
from Employee
where primary_flag = 'Y' or employee_id in (
    select employee_id
    from Employee
    group by employee_id
    having count(*) = 1
)
-- problem 7 index
create nonclustered index index_logs on AppLogs ([service_name] , created_at desc);
-- problem 8

-- ans: by reducing the selected columns , so the index covers only it's columns

-- problem 10
create view vw_vipCustomers as
select customers.customer_id , [name] , email , SUM(total_amount) as total_spent
from customers
join orders
on customers.customer_id = orders.customer_id
group by customers.customer_id , [name] , email
having total_spent > 5000;