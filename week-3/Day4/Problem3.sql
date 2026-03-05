-- Level-2: Problem 3 – Store Performance and Stock Validation
CREATE DATABASE AutoDb;

USE AutoDb;

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

INSERT INTO stores VALUES
(1,'Bangalore Store'),
(2,'Delhi Store');

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    list_price DECIMAL(10,2)
);

INSERT INTO products VALUES
(1,'Bike',50000),
(2,'Helmet',2000),
(3,'Gloves',500);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO orders VALUES
(101,1),
(102,1),
(103,2);

CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO order_items VALUES
(101,1,2,500),
(102,2,3,100),
(103,3,5,50);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks VALUES
(1,1,0),
(1,2,10),
(2,3,0);

--1. Identify products sold in each store using nested queries.
SELECT store_id, product_id
FROM (
        SELECT o.store_id, oi.product_id
        FROM orders o
        JOIN order_items oi
        ON o.order_id = oi.order_id
     ) AS sold_products;

--2. Compare sold products with current stock using INTERSECT
SELECT store_id, product_id
FROM (
        SELECT o.store_id, oi.product_id
        FROM orders o
        JOIN order_items oi
        ON o.order_id = oi.order_id
     ) AS sold_products
INTERSECT
SELECT store_id, product_id
FROM stocks
WHERE quantity > 0;

--2. Compare sold products with current stock using EXCEPT
SELECT store_id, product_id
FROM (
        SELECT o.store_id, oi.product_id
        FROM orders o
        JOIN order_items oi
        ON o.order_id = oi.order_id
     ) AS sold_products
EXCEPT
SELECT store_id, product_id
FROM stocks
WHERE quantity > 0;

--3. Display store_name, product_name, total quantity sold.
SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold
FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id
JOIN stores s
ON o.store_id = s.store_id
JOIN products p
ON oi.product_id = p.product_id
GROUP BY s.store_name, p.product_name;

--4. Calculate total revenue per product (quantity × list_price – discount).
SELECT 
    p.product_name,
    SUM(oi.quantity * p.list_price - oi.discount) AS total_revenue
FROM order_items oi
JOIN products p
ON oi.product_id = p.product_id
GROUP BY p.product_name;

--5. Update stock quantity to 0 for discontinued products (simulation).
UPDATE stocks
SET quantity = 0
WHERE product_id = 3;
