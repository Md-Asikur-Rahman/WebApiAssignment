use EmployeeDB
insert into EmployeeTable(FirstName,LastName,Designation,Gender,Email,PhoneNumber,EmployeeDescription,EmployeePicture) values
	('Asikur','Rahman','Software Engineer','Male','asikur.25@gmail.com','01875859187','Newly joined as Software Engineer','asik.jpg'),
	('Oshim','Mia','Software Engineer','Male','oshim.25@gmail.com','01875855949','Newly joined as Software Engineer','oshim.jpg'),
	('Reayzul','Haque','Senior Software Engineer','Male','reayz@gmail.com','01339494949','Newly joined as Software Engineer','reayz.jpg') 
select * from EmployeeTable
select * from EmployeeTable where Designation='Software Engineer' 
select * from EmployeeTable order by LastName desc
delete EmployeeTable where EmployeeID=10
delete EmployeeTable
