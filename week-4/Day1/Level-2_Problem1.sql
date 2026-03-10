CREATE DATABASE CompanySalesDB;

USE CompanySalesDB;

--Level-2 Problem 1: Stored Procedures and User-Defined Functions
CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100) NOT NULL
);

INSERT INTO stores VALUES
(1,'Central Store'),
(2,'City Store'),
(3,'Online Store');

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    list_price DECIMAL(10,2) NOT NULL
);

INSERT INTO products VALUES
(101,'Laptop',50000),
(102,'Keyboard',1500),
(103,'Mouse',500),
(104,'Monitor',12000),
(105,'Printer',8000);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    store_id INT NOT NULL,
    order_date DATE NOT NULL,
    order_status INT NOT NULL,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO orders VALUES
(1,1,1,'2024-01-10',1),
(2,2,2,'2024-01-12',1),
(3,3,1,'2024-01-15',1),
(4,4,3,'2024-01-18',1);

CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    list_price DECIMAL(10,2) NOT NULL,
    discount DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO order_items VALUES
(1,1,101,1,50000,10),
(2,1,103,2,500,5),
(3,2,102,1,1500,0),
(4,3,104,1,12000,8),
(5,4,105,1,8000,5),
(6,4,103,3,500,0);

-- Create a stored procedure to generate total sales amount per store.
CREATE PROCEDURE sp_TotalSalesPerStore AS
BEGIN SELECT 
        s.store_name,
        SUM(oi.quantity * oi.list_price) AS total_sales
    FROM stores s
    JOIN orders o ON s.store_id = o.store_id
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY s.store_name
    ORDER BY total_sales DESC;
END;

EXEC sp_TotalSalesPerStore;

--Create a stored procedure to retrieve orders by date range.
CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS BEGIN SELECT 
        order_id,
        customer_id,
        store_id,
        order_date,
        order_status
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
    ORDER BY order_date;
END;

EXEC sp_GetOrdersByDateRange '2024-01-01','2024-12-31';

-- Create a scalar function to calculate total price after discount.
CREATE FUNCTION fn_CalculateDiscountPrice
(
    @price DECIMAL(10,2),
    @discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS BEGIN
    DECLARE @final_price DECIMAL(10,2)
    SET @final_price = @price - (@price * ISNULL(@discount,0) / 100)
    RETURN @final_price
END;

SELECT 
product_name,
list_price,
dbo.fn_CalculateDiscountPrice(list_price,10) AS discounted_price
FROM products;

-- Create a table-valued function to return top 5 selling products.
CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS total_sold
    FROM products p
    JOIN order_items oi ON p.product_id = oi.product_id
    GROUP BY p.product_name
    ORDER BY total_sold DESC
);

SELECT * FROM dbo.fn_Top5SellingProducts();
