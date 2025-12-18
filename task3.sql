-- problem 1
SELECT Product.product_name , Sales.year , Sales.price
FROM Sales
INNER JOIN Product
ON Sales.product_id = Product.product_id;

-- problem 2
SELECT customer_id , count(*) as count_no_trans
FROM Visits
LEFT JOIN Transactions
ON Visits.visit_id = Transactions.visit_id
WHERE Transactions.transaction_id IS NULL
GROUP BY customer_id;

-- problem 3
SELECT EmployeeUNI.unique_id , [name]
FROM Employees
LEFT JOIN EmployeeUNI
ON Employees.id = EmployeeUNI.id;

-- problem 4
SELECT w1.id as Id
FROM Weather w1
INNER JOIN Weather w2
ON DATEADD(day , -1 , w1.recordDate) = w2.recordDate
WHERE w1.temperature > w2.temperature;

-- problem 5
SELECT emp_name , ISNULL(Departments.dept_id , 'Unsigned')
FROM Employees
LEFT JOIN Departments
ON Employees.dept_id = Departments.dept_id;

-- problem 6
SELECT product_name , Suppliers.supplier_name
FROM Products
LEFT JOIN Suppliers
ON Products.supplier_id = Suppliers.supplier_id
WHERE product_name LIKE '%Phone%';

-- problem 7
SELECT CONCAT(first_name , ' ' , last_name) as full_name , Orders.order_id , Orders.amount
FROM Customers
FULL JOIN Orders
ON Customers.customer_id = Orders.order_id;

-- problem 8
create table books (
	book_id int primary key ,
	book_title varchar(50) ,
	publisher_id int ,
	constraint pub_fk foreign key (publisher_id)
	references publishers(publisher_id)
)

create table publishers (
	publisher_id int primary key ,
	publisher_name varchar(50) ,
	publisher_city varchar(50)
)

create table book_genres (
	book_id int ,
	genre varchar(10) ,
	constraint book_genre_pk primary key (book_id , genre)
)

create table book_authors (
	book_id int ,
	author varchar(10) ,
	constraint book_auth_pk primary key (book_id , author)
)

-- problem 9
create table students (
	student_id int primary key ,
	student_name varchar(50) ,
	student_email varchar(50)
)

create table student_courses (
	student_id int ,
	course varchar(10) ,
	constraint stud_crs_fk foreign key (student_id)
	references students(student_id) ,
	constraint stud_crs_pk primary key (student_id , course)
)

create table student_instructors (
	student_id int ,
	instructor varchar(50) ,
	constraint stud_instr_fk foreign key (student_id)
	references students(student_id) ,
	constraint instr_fk foreign key (instructor)
	references instructors (instructor_id) ,
	constraint stud_crs_pk primary key (student_id , instructor)
)

create table instructors (
	instructor_id varchar(50) primary key ,
	department varchar(20) ,
	constraint department foreign key (department)
	references departments (department)
)

create table departments (
	department varchar(50) primary key ,
	building varchar(50) ,

)

-- problem 10
create table patients (
	patient_id int primary key ,
	patient_name varchar(50) ,
	doctor_id int ,
	constraint patient_doc_fk foreign key (doctor_id)
	references doctors (doctor_id)
)

create table patient_phones (
	patient_id int ,
	phone varchar(15) ,
	constraint patient_phone_fk foreign key (patient_id)
	references patients (patient_id) ,
	constraint patient_phone_pk primary key (patient_id , phone)
)

create table patient_appointments (
	patient_id int ,
	appointment_date date ,
	constraint patient_app_fk foreign key (patient_id)
	references patients (patient_id) ,
	constraint patient_app_pk primary key (patient_id , appointment_date)
)

create table  doctors (
	doctor_id int primary key ,
	doctor_name varchar(50) ,
	speciality varchar(50) ,
	constraint doc_spec_fk foreign key (speciality)
	references specialities (speciality)
)

create table speciality (
	speciality varchar(50) primary key ,
	clinic varchar(50) ,
)