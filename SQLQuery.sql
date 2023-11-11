create database BikeRental;
use BikeRental;

create table Bike (
	id int not null identity(1,1) primary key,
	name varchar(50) not null,
	rentalPrice int not null,
	color varchar(50) not null
);

insert into Bike (name, rentalPrice, color) values
('Hunter', 2800, 'red'),
('Racer', 3500, 'blue'),
('Mountain', 4000, 'green'),
('City', 2500, 'black'),
('BMX', 2000, 'yellow'),
('Kids', 1500, 'pink'),
('Tandem', 5000, 'white'),
('Electric', 6000, 'silver'),
('Folding', 3000, 'orange'),
('Cargo', 4500, 'brown');

create table Customer (
	id int not null identity(1,1) primary key,
	name varchar(50) not null,
	phone varchar(50) not null,
	email varchar(50) not null,
	address varchar(50) not null
);

insert into Customer (name, phone, email, address) values
('John', '12345678', 'test', 'test');

select * from Customer;

create table Rental (
	id int not null identity(1,1) primary key,
	bikeId int not null,
	customerId int not null,
	rentalDate date not null,
	returnDate date not null,
	foreign key (bikeId) references Bike(id),
	foreign key (customerId) references Customer(id)
);