--Level-2 Problem 2: Stock Auto-Update Trigger
CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT NOT NULL,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks VALUES
(1,101,10),
(1,103,20),
(2,102,15),
(1,104,5),
(3,105,8),
(3,103,25);

-- Create an AFTER INSERT trigger on order_items.
-- Reduce the corresponding quantity in stocks table.
-- Prevent stock from becoming negative.
-- If stock is insufficient, rollback the transaction with a custom error message.

CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (
            SELECT 1
            FROM stocks s
            JOIN orders o ON s.store_id = o.store_id
            JOIN inserted i ON o.order_id = i.order_id 
                             AND s.product_id = i.product_id
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
        JOIN orders o ON s.store_id = o.store_id
        JOIN inserted i 
            ON o.order_id = i.order_id
           AND s.product_id = i.product_id;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

INSERT INTO order_items
VALUES (7,2,102,2,1500,0);

--INSERT INTO order_items
--VALUES (8,3,104,50,12000,0);

SELECT * FROM stocks;
