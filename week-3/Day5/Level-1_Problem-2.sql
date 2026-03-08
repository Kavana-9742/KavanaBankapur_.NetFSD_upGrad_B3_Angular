--Level-1 Problem 2: Creating Views and Indexes for Performance
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

--Create a view that shows product name, brand name, category name, model year and list price.
CREATE VIEW vw_product_details AS
SELECT 
	p.product_name,
	b.brand_name,
	c.category_name,
	p.model_year,
	p.price
FROM Products p
JOIN brand b
ON p.brand_id = b.brand_id
JOIN category c
ON p.category_id = c.category_id;

SELECT * FROM vw_product_details;

CREATE TABLE staff(
	staff_id INT PRIMARY KEY,
	staff_name VARCHAR(100) NOT NULL,
	store_id INT,
	FOREIGN KEY(store_id) REFERENCES store(store_id)
);

INSERT INTO staff VALUES
(1, 'Rekha', 1),
(2,'Meena',2),
(3,'Arjun',3),
(4,'Priya',4),
(5,'Kiran',5);

CREATE TABLE orders(
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    staff_id INT,
    order_date DATE,
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
    FOREIGN KEY (store_id) REFERENCES store(store_id),
    FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
);

INSERT INTO orders VALUES
(1,1,1,1,'2025-01-10'),
(2,2,2,2,'2025-01-12'),
(3,3,3,3,'2025-01-15'),
(4,4,1,1,'2025-01-18'),
(5,5,4,4,'2025-01-20');

--Create a view that shows order details with customer name, store name and staff name.
CREATE VIEW vw_order_details AS
SELECT 
	o.order_id,
	c.first_name + ' ' + c.last_name AS customer_full_name,
	s.store_name,
	st.staff_name,
	o.order_date
FROM orders o
JOIN customer c
ON o.customer_id = c.customer_id
JOIN store s
ON o.store_id = s.store_id
JOIN staff st
ON o.staff_id = st.staff_id;

SELECT * FROM vw_order_details;

CREATE INDEX idx_products_brand
ON Products(brand_id);

CREATE INDEX idx_products_category
ON Products(category_id);

SELECT p.product_name, b.brand_name
FROM Products p
JOIN brand b
ON p.brand_id = b.brand_id;
