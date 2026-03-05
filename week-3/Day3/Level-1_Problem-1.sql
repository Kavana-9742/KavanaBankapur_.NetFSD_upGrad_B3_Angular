CREATE DATABASE StoreDB;

USE StoreDB;

--Level-1_Problem-1 -> Basic Customer Order Report
CREATE TABLE Customers(
	cust_id INT PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL
);

INSERT INTO Customers VALUES
(1, 'Kai', 'Singh'),
(2, 'Asher', 'Smith'),
(3, 'Elena', 'Gilbert'),
(4, 'Damon', 'Salvatore'),
(5, 'Caroline', 'Forbes'),
(6, 'Bonnie', 'Bennet');

CREATE TABLE Orders(
	order_id INT PRIMARY KEY,
	cust_id INT,
	order_date DATE NOT NULL,
	order_status INT,
	FOREIGN KEY(cust_id) REFERENCES Customers(cust_id)
);

INSERT INTO Orders VALUES
(101, 1, '2024-03-01', 1),
(102, 2, '2024-04-02', 1),
(103, 2, '2024-06-04', 2),
(104, 5, '2024-07-11', 4),
(105, 3, '2024-11-10', 3),
(106, 6, '2025-01-01', 4),
(107, 4, '2025-03-24', 1);

--Level-1_Problem-1 query
SELECT c.first_name,c.last_name,
	   o.order_id,o.order_date,
	   o.order_status
FROM customers AS c INNER JOIN orders AS o
ON c.cust_id = o.cust_id WHERE 
o.order_status = 1 OR o.order_status = 4
ORDER BY o.order_date DESC;
