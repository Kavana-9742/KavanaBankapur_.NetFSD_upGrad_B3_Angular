--Level-2: Problem 4 – Order Cleanup and Data Maintenance
CREATE DATABASE archive;

USE archive;

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE
);

CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE
);

INSERT INTO orders VALUES
(1,101,1,'2024-01-01','2024-01-05','2024-01-04'),
(2,102,3,'2023-01-10','2023-01-15','2023-01-18'),
(3,103,1,'2024-02-01','2024-02-07','2024-02-06'),
(4,101,1,'2024-03-01','2024-03-05','2024-03-08'),
(5,102,3,'2022-02-01','2022-02-05','2022-02-06');

--Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

--Delete orders where order_status = 3 (Rejected) and older than 1 year.
DELETE FROM orders
WHERE order_id IN
(
    SELECT order_id
    FROM archived_orders
);

--Use nested query to identify customers whose all orders are completed.
SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) =
(
    SELECT COUNT(*)
    FROM orders o2
    WHERE o2.customer_id = orders.customer_id
    AND o2.order_status = 1
);

--Display order processing delay (DATEDIFF between shipped_date and order_date).
SELECT
    order_id,
    order_date,
    shipped_date,
    DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders;

--Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.
SELECT
    order_id,
    order_date,
    required_date,
    shipped_date,
    CASE
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS delivery_status
FROM orders;
