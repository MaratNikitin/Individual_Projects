create table Employees
(
	ID int identity(100, 1) not null primary key,
	FirstName nvarchar(75) not null,
	LastName nvarchar(75) not null,
	BaseSalary decimal(14,2) not null,
	InternalRating decimal(2,1) not null,
	CustomerRating decimal(2,1) not null
);
go

insert into Employees (FirstName, LastName, BaseSalary, InternalRating, CustomerRating)
values ('James', 'Weekend', 6750, 4.3, 4.7), ('John', 'Wilson', 6750, 3.8, 3.5),
	   ('Samantha', 'Moore', 9500, 5.0, 4.9), ('Brooke', 'White', 8300, 4.9, 5.0),
	   ('Don', 'Millerson', 8550, 3.4, 3.1), ('Mitch', 'Davis', 6750, 4.1, 3.9),
	   ('Alfred', 'Smith', 6250, 3.9, 3.7), ('Sarah', 'Gomez', 8750, 3.9, 4.2),
	   ('Ashley', 'Garcia', 9250, 4.0, 4.1), ('Mandy', 'Willow', 8750, 3.5, 2.9),
	   ('Michael', 'Anderson', 6890, 3.7, 3.4), ('Rey', 'Reynolds', 6500, 4.1, 3.6),
	   ('Jonathan', 'Williams', 6250, 4.2, 3.9), ('Sam', 'Thomas', 7575, 4.5, 4.1),
	   ('Sasha', 'Lopez', 8775, 4.9, 4.9);
go