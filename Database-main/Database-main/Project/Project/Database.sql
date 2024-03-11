create table customer (
id int primary key identity(1,1),
first_name varchar(50) not null,
last_name varchar(50) not null,
email varchar(50) not null,
);

create table products (
id int primary key identity (1,1),
product_name varchar(50) not null,
price decimal(10,2) not null,
is_available bit not null
);

create table orders (
id int primary key identity (1,1),
customer_id int foreign key references customer(id),
order_date datetime,
total_price decimal(10,2),
);

create table order_details (
id int primary key identity (1,1),
order_id int foreign key references orders(id),
product_id int foreign key references products(id),
amount int not null,
);

create table review (
id int primary key identity (1,1),
product_id int foreign key references products(id),
customer_id int foreign key references customer(id),
reviewtext varchar(50) not null,
);

INSERT INTO products (product_name, price, is_available) VALUES ('Laptop', 1200.00, 1);
INSERT INTO products (product_name, price, is_available) VALUES ('Smartphone', 800.00, 1);
INSERT INTO products (product_name, price, is_available) VALUES ('Headphones', 150.00, 0);
INSERT INTO products (product_name, price, is_available) VALUES ('TV', 200.00, 1);
INSERT INTO products (product_name, price, is_available) VALUES ('XBOX', 300.00, 1);
INSERT INTO products (product_name, price, is_available) VALUES ('Stereo Box', 150.00, 1);
INSERT INTO products (product_name, price, is_available) VALUES ('Fridge', 500.00, 1);

INSERT INTO review (product_name, price, is_available) VALUES ('Fridge', 500.00, 1);

delete from customer;
delete from orders;
delete from order_details;
delete from review;