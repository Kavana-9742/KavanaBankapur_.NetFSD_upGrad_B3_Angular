CREATE DATABASE Sales;

USE Sales;

--Level-2_Problem-1 -> Store Wise Sales Summary
CREATE TABLE stores(
	store_id INT PRIMARY KEY,
	store_name VARCHAR(100) NOT NULL
);

INSERT INTO stores VALUES
(1, 'downtown bikes'),
(2, 'suburban wheels');

CREATE TABLE orders(
	order_id INT PRIMARY KEY,
	store_id INT,
	order_status INT,
);

INSERT INTO orders VALUES
(101, 1, 4),
(102, 1, 4),
(103, 2, 4),
(104, 2, 1);

CREATE TABLE order_items(
	order_id INT,
	item_id INT,
	quantity INT,
	list_price DECIMAL(10, 0),
	discount DECIMAL(4, 2),
	PRIMARY KEY(order_id, item_id),
	FOREIGN KEY(order_id) REFERENCES orders(order_id)
);

INSERT INTO order_items VALUES
(101, 1, 2, 1000.00, 0.10),
(102, 1, 1, 500.00, 0.00),
(104, 1, 1, 2000.00, 0.05);

--Level-2_Problem-1 -> Query
SELECT 
    s.store_name, 
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales_amount
FROM stores AS s
INNER JOIN orders AS o ON s.store_id = o.store_id
INNER JOIN order_items AS oi ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales_amount DESC;

