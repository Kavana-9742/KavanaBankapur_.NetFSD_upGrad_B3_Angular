CREATE DATABASE Retail;

USE Retail;

-- Level-1: Problem 1 – Product Analysis Using Nested Queries
CREATE TABLE categories(
	category_id INT PRIMARY KEY,
	category_name VARCHAR(100)
);

INSERT INTO categories VALUES
(1, 'Mountain Bikes'),
(2, 'Road Bikes'),
(3, 'Electric Bikes');

CREATE TABLE Products(
	product_id INT PRIMARY KEY,
	product_name VARCHAR(100) NOT NULL,
	model_year INT NOT NULL,
	list_price DECIMAL(10,2) NOT NULL,
	category_id INT,FOREIGN KEY(category_id) 
	REFERENCES categories(category_id)
);

INSERT INTO Products VALUES
(1,'Trek 820',2017,1200,1),
(2,'Giant ATX',2018,900,1),
(3,'Specialized Rockhopper',2019,1500,1),
(4,'Trek Domane',2018,2000,2),
(5,'Giant Defy',2017,1800,2),
(6,'Electric X',2019,3500,3);

--Level-1: Problem 1 -> Query
SELECT CONCAT(product_name ,' (',model_year,')') AS product_details,
product_name,
model_year,
list_price,
(list_price - (
	SELECT AVG(list_price) FROM Products p2
	WHERE p2.category_id = p1.category_id))
AS price_difference
FROM Products p1
WHERE list_price >
(
	SELECT AVG(list_price)
	FROM Products p2
	WHERE p2.category_id = p1.category_id
);
