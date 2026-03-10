--Level-2 Problem 3: Order Status Validation Trigger
CREATE TABLE #OrderRevenue      -- Store computed revenue in a temporary table.
(
    store_id INT,
    order_id INT,
    revenue DECIMAL(12,2)
);
DECLARE @order_id INT;
DECLARE @store_id INT;
DECLARE @revenue DECIMAL(12,2);
DECLARE revenue_cursor CURSOR FOR       -- Use a cursor to iterate through completed orders (order_status = 4).
SELECT order_id, store_id
FROM orders
WHERE order_status = 4;
BEGIN TRY
    BEGIN TRANSACTION;
    OPEN revenue_cursor;
    FETCH NEXT FROM revenue_cursor INTO @order_id, @store_id;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @revenue = SUM(quantity * list_price * (1 - discount))  --Calculate total revenue per order using order_items.
        FROM order_items
        WHERE order_id = @order_id;
        IF @revenue IS NULL
            SET @revenue = 0;
        INSERT INTO #OrderRevenue(store_id, order_id, revenue)
        VALUES (@store_id, @order_id, @revenue);
        FETCH NEXT FROM revenue_cursor INTO @order_id, @store_id;
    END
    CLOSE revenue_cursor;
    DEALLOCATE revenue_cursor;
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Error occurred during revenue calculation.';
END CATCH;
SELECT                      --Display store-wise revenue summary.
    store_id,
    SUM(revenue) AS total_store_revenue
FROM #OrderRevenue
GROUP BY store_id;

SELECT * FROM #OrderRevenue;
