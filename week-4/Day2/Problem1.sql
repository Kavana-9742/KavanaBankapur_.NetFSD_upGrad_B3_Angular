--Level-2 Problem 1: Transactions and Trigger Implementation
CREATE DATABASE AutoRetail;

USE AutoRetail;

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    price DECIMAL(10,2)
);

INSERT INTO products VALUES
(101,'Car Battery',5000),
(102,'Brake Pad',2000),
(103,'Engine Oil',800);

CREATE TABLE stocks
(
    product_id INT PRIMARY KEY,
    quantity INT NOT NULL,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks VALUES
(101,10),
(102,15),
(103,20);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    order_date DATE,
    customer_name VARCHAR(100)
);

CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    price DECIMAL(10,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock for the product.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id;
END;


BEGIN TRANSACTION
BEGIN TRY
    INSERT INTO orders
    VALUES (1, GETDATE(), 'Alaric');
    INSERT INTO order_items
    VALUES
    (1,1,101,2,5000),
    (2,1,103,3,800);
    COMMIT;
    PRINT 'Order placed successfully';
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT 'Order failed: ' + ERROR_MESSAGE();
END CATCH;

SELECT * FROM orders;
SELECT * FROM order_items;
SELECT * FROM stocks;
