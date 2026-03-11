--Level-2 Problem 2: Atomic Order Cancellation with SAVEPOINT
ALTER TABLE orders
ADD order_status INT;

INSERT INTO orders
VALUES (2, GETDATE(), 'Elena', 4);

BEGIN TRANSACTION;
BEGIN TRY
    SAVE TRANSACTION RestoreStockPoint;
    UPDATE s
    SET s.quantity = s.quantity + oi.quantity
    FROM stocks s
    JOIN order_items oi
    ON s.product_id = oi.product_id
    WHERE oi.order_id = 1;
    UPDATE orders
    SET order_status = 3
    WHERE order_id = 1;
    COMMIT;
    PRINT 'Order cancelled successfully and stock restored';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION RestoreStockPoint;
    PRINT 'Error occurred: ' + ERROR_MESSAGE();
    ROLLBACK;
END CATCH;

SELECT * FROM orders;
SELECT * FROM stocks;
