--Level-1 Problem 1: Basic Setup and Data Retrieval in EcommDb

CREATE DATABASE EcommDb;

USE EcommDb;

CREATE TABLE category(
	category_id INT PRIMARY KEY,
	category_name VARCHAR(100) NOT NULL
);

INSERT INTO category VALUES
(1, 'SUV'),
(2, 'Sedan'),
(3, 'Hatchback'),
(4, 'Truck'),
(5, 'Electric');

CREATE TABLE brand(
	brand_id INT PRIMARY KEY,
	brand_name VARCHAR(100) NOT NULL
);

INSERT INTO brand VALUES
(1, 'Toyota'),
(2, 'Honda'),
(3, 'Ford'),
(4, 'Tesla'),
(5, 'Hyundai');

CREATE TABLE Products(
	product_id INT PRIMARY KEY,
	product_name VARCHAR(100) NOT NULL,
	brand_id INT,
	category_id INT,
	model_year INT,
	price DECIMAL(10,2),
	FOREIGN KEY(brand_id) REFERENCES brand(brand_id),
	FOREIGN KEY(category_id) REFERENCES category(category_id)
);

INSERT INTO Products VALUES
(6, 'Toyota Fortuner', 1, 1, 2023, 45000),
(7, 'Honda City', 2, 2, 2022, 25000),
(8, 'Hyundai i20', 5, 3, 2023, 18000),
(9, 'Ford Ranger', 3, 4, 2021, 40000),
(10, 'Tesla Model 3', 4, 5, 2024, 50000);

CREATE TABLE customer(
	customer_id INT PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100)  NOT NULL,
	city VARCHAR(100) NOT NULL,
	phone VARCHAR(20) NOT NULL
);

INSERT INTO customer VALUES
(1, 'Raina', 'Kumar', 'Bangalore', '5247928329'),
(2, 'Anita', 'Sharma', 'Delhi', '9860924249'),
(3, 'Rashmi', 'Patil', 'Mumbai', '9865324683'),
(4, 'Sanvi', 'Rao', 'Bangalore', '8238462929'),
(5, 'Amit', 'Verma', 'Pune', '8936456243');

CREATE TABLE store(
	store_id INT PRIMARY KEY,
	store_name VARCHAR(100) NOT NULL,
	city VARCHAR(100) NOT NULL
);

INSERT INTO store VALUES
(1,'AutoHub Bangalore','Bangalore'),
(2,'City Cars Delhi','Delhi'),
(3,'Metro Motors Mumbai','Mumbai'),
(4,'Pune Auto Mall','Pune'),
(5,'South India Cars','Chennai');

--Write SELECT queries to retrieve all products with their brand and category names.
SELECT p.product_name,
	   b.brand_name,
	   c.category_name,
	   p.price
FROM Products p
JOIN brand b
ON p.brand_id = b.brand_id
JOIN category c
ON p.category_id = c.category_id;

--Retrieve all customers from a specific city.
--Eg: Bangalore
SELECT * FROM customer WHERE city='Bangalore';

--Display total number of products available in each category.
SELECT c.category_name,
COUNT(p.product_id) AS total_products
FROM category c
LEFT JOIN Products p
ON c.category_id = p.category_id
GROUP BY c.category_name, c.category_id;

TRUNCATE TABLE Products;
select * from Products;
