CREATE DATABASE StoreDB;

USE StoreDB;

--Level-1_Problem-2 -> Product Price Listing by Category
CREATE TABLE categories(
	category_id INT PRIMARY KEY,
	category_name VARCHAR(100) NOT NULL
);

INSERT INTO categories VALUES
(1, 'Electronics'),
(2, 'Fashion'),
(3, 'Soft Drinks');

CREATE TABLE brands(
	brand_id INT PRIMARY KEY,
	brand_name VARCHAR(100) NOT NULL
);

INSERT INTO brands VALUES
(1, 'Samsung'),
(2, 'Dell'),
(3, 'Xiomi'),
(4, 'Chanel'),
(5, 'Prada'),
(6, 'Varsace'),
(7, 'Sprite'),
(8, 'Coca-Cola'),
(9, 'Crush'),
(10, 'Pepsi');

CREATE TABLE products(
	product_id INT PRIMARY KEY,
	product_name VARCHAR(100) NOT NULL,
	brand_id INT,
	category_id INT,
	model_year INT,
	list_price DECIMAL(10, 2),
	FOREIGN KEY(brand_id) REFERENCES brands(brand_id),
	FOREIGN KEY(category_id) REFERENCES categories(category_id)
);

INSERT INTO products VALUES
(101, 'SmartPhone', 1, 1, 2025, 100000),
(102, 'Wallet', 5, 2, 2023, 50000),
(103, 'Mobile', 3, 1, 2024, 30000),
(104, 'Parfume', 4, 2, 2025,400),
(105, 'Carbonate SD', 9, 3, 2025, 20),
(106, 'Jewelry', 6, 2, 2024, 450),
(107, 'Pepsi zero sugar', 10, 3, 2020, 60),
(108, 'Sprite chill', 7, 3, 2021, 40),
(109, 'Diet Coke', 8, 3, 2021, 70),
(110, 'Laptop', 2, 1, 2020, 60000),
(111, 'Clothes', 6, 2, 2026,800);

--Level-1_Problem-2 -> Query
SELECT p.product_name,
	   b.brand_name,
	   c.category_name,
	   p.model_year,
	   p.list_price
FROM products as p INNER JOIN brands as b
ON p.brand_id = b.brand_id
INNER JOIN categories AS c ON 
p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY P.LIST_PRICE ASC;
