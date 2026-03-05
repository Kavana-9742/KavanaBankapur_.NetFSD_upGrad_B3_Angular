CREATE DATABASE Stock;

USE Stock;

-- Level-2_Problem-2 -> Product Stock and Sales Analysis
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100) NOT NULL
);

INSERT INTO stores VALUES 
(1, 'Main Street Hub'), 
(2, 'Downtown Outlet');

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

INSERT INTO categories VALUES 
(1, 'Electronics'), 
(2, 'Fashion');

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);

INSERT INTO brands VALUES 
(1, 'Samsung'), 
(2, 'Apple'), 
(3, 'Nike');

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10, 2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO products VALUES 
(101, 'iPhone 15', 2, 1, 2024, 999.00),
(102, 'Galaxy S24', 1, 1, 2024, 850.00),
(103, 'Air Max', 3, 2, 2023, 120.00),
(104, 'MacBook Pro', 2, 1, 2024, 2500.00);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks VALUES 
(1, 101, 10), 
(1, 102, 5), 
(1, 104, 2),
(2, 101, 3), 
(2, 103, 20);

CREATE TABLE order_items (
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10, 2),
    discount DECIMAL(4, 2) DEFAULT 0,
    PRIMARY KEY (order_id, item_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO order_items VALUES 
(5001, 1, 101, 1, 999.00, 0.05),
(5002, 1, 102, 2, 850.00, 0.10);

-- Level-2_Problem-2 -> Query
SELECT 
    p.product_name, 
    s.store_name, 
    st.quantity AS available_stock, 
    ISNULL(SUM(oi.quantity), 0) AS total_quantity_sold
FROM products AS p
INNER JOIN stocks AS st ON p.product_id = st.product_id
INNER JOIN stores AS s ON st.store_id = s.store_id
LEFT JOIN order_items AS oi ON p.product_id = oi.product_id
GROUP BY 
    p.product_name, 
    s.store_name, 
    st.quantity
ORDER BY p.product_name;
