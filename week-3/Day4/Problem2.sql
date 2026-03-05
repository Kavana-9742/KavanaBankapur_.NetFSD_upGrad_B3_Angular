--Level-1: Problem 2 – Customer Activity Classification

CREATE TABLE customers(
	customer_id INT PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL
);

INSERT INTO customers VALUES
(1, 'Damon', 'Salvatore'),
(2, 'Elena', 'Gilbert'),
(3, 'Paul', 'Wesley');

CREATE TABLE orders(
	order_id INT PRIMARY KEY,
	customer_id INT,
	order_value INT NOT NULL,
	FOREIGN KEY(customer_id) REFERENCES customers(customer_id)
);

INSERT INTO orders VALUES
(101, 1, 7000),
(102, 1, 5000),
(103, 2, 3000);

--Level-1: Problem 2 -> Query
SELECT 
	CONCAT(c.first_name,' ',c.last_name) AS full_name,
	(SELECT SUM(o.order_value)
	FROM orders o
	WHERE o.customer_id=c.customer_id) AS total_order_value,
	CASE
		WHEN(SELECT SUM(o.order_value)FROM orders o 
		WHERE o.customer_id=c.customer_id) > 10000 THEN 'Premium'
		WHEN(SELECT SUM(o.order_value)FROM orders o
		WHERE o.customer_id=c.customer_id) BETWEEN 5000 AND 10000
		THEN 'Regular'
		ELSE 'Basic'
	END AS customer_type
	FROM customers c
JOIN orders o ON c.customer_id = o.customer_id
UNION
SELECT 
    CONCAT(first_name,' ',last_name) AS full_name,
    0 AS total_order_value,
    'No Orders' AS customer_type
FROM customers
WHERE customer_id NOT IN (SELECT customer_id FROM orders);
