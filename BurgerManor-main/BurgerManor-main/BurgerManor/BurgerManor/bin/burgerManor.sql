create database burgerManor
use burgerManor

/*--------------------------- CUSTOMERS TABLE ---------------------------------*/
CREATE TABLE CUSTOMERS (
    CID INT IDENTITY(1,1) PRIMARY KEY,
    C_ID AS ('C-' + RIGHT('000' + CAST(CID AS VARCHAR(10)), 3)) PERSISTED,
    C_Firstname NVARCHAR(50),
    C_Lastname NVARCHAR(50),
    C_Age INT,
    C_Email NVARCHAR(255) UNIQUE NOT NULL,
    C_Address NVARCHAR(500),
    C_UserType NVARCHAR(10) DEFAULT 'customer' CHECK (C_UserType IN ('admin', 'customer')),
    C_Username NVARCHAR(50) NOT NULL,
    C_Password NVARCHAR(100) NOT NULL
);

INSERT INTO CUSTOMERS (C_Firstname, C_Lastname,C_Email, C_UserType, C_Username, C_Password)
VALUES ('Johns', 'Does', 'examples@examples.coms', 'customer', 'example_usernames', 'example_passwords');




/*--------------------------- ADMIN TABLE ---------------------------------*/
CREATE TABLE ADMINISTRATOR (
    AID INT IDENTITY(1,1) PRIMARY KEY,
    A_ID AS ('A-' + RIGHT('000' + CAST(AID AS VARCHAR(10)), 3)) PERSISTED,
    A_Firstname NVARCHAR(50),
    A_Lastname NVARCHAR(50),
    A_Age INT,
    A_Email NVARCHAR(255) UNIQUE NOT NULL,
    A_Address NVARCHAR(500),
    A_UserType NVARCHAR(10) DEFAULT 'admin' CHECK (A_UserType IN ('admin', 'customer')),
    A_Username NVARCHAR(50) NOT NULL,
    A_Password NVARCHAR(100) NOT NULL
);

/*--------------------------- PRODUCT TABLE ---------------------------------*/
CREATE TABLE PRODUCTS (
    PID INT PRIMARY KEY IDENTITY,
    P_ID AS ('P-' + RIGHT('000' + CAST(PID AS VARCHAR(10)), 3)) PERSISTED,
	P_IMAGE IMAGE,
	P_DESCRIPTION VARCHAR(MAX),
    P_NAME VARCHAR(50) NOT NULL,
    P_QUANTITY INT NOT NULL,
    P_PRICE DOUBLE PRECISION NOT NULL,
	P_CATEGORY NVARCHAR(20) NOT NULL CHECK (P_Category IN ('burgers', 'fries')),
);

---------------------------- ORDERS TABLE -----------------------------------

CREATE TABLE ORDERS (
    OID INT PRIMARY KEY IDENTITY,
    O_ID AS ('O-' + RIGHT('000' + CAST(OID AS VARCHAR(10)), 3)) PERSISTED,
    PRODUCT_ID INT,
    PRODUCT_NAME VARCHAR(50),
    CUSTOMER_ID INT,
    ORDERED_QUANTITY INT NOT NULL,
    PRODUCT_PRICE DOUBLE PRECISION,
    ORDER_TOTAL_PRICE DOUBLE PRECISION,
    ORDER_DATE DATETIME DEFAULT GETDATE(), 
    FOREIGN KEY (PRODUCT_ID) REFERENCES PRODUCTS(PID),
    FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMERS(CID)
);


--------------------------- TRIGGERS ---------------------------------

CREATE OR ALTER TRIGGER UpdateOrderPricesAndQuantity
ON ORDERS
AFTER INSERT
AS
BEGIN
    DECLARE @ProductId INT;
    DECLARE @OrderedQuantity INT;
    DECLARE @ProductPrice DECIMAL(10, 2);
    DECLARE @Description NVARCHAR(500);

    -- Iterate through each inserted order
    DECLARE order_cursor CURSOR FOR
    SELECT PRODUCT_ID, ORDERED_QUANTITY
    FROM inserted;

    OPEN order_cursor;
    FETCH NEXT FROM order_cursor INTO @ProductId, @OrderedQuantity;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Get product details for the current order
        SELECT @ProductPrice = P_PRICE, @Description = P_DESCRIPTION
        FROM PRODUCTS
        WHERE PID = @ProductId;

        -- Update order details
        UPDATE ORDERS
        SET PRODUCT_PRICE = @ProductPrice,
            ORDER_TOTAL_PRICE = @ProductPrice * @OrderedQuantity,
            PRODUCT_DESCRIPTION = @Description
        WHERE PRODUCT_ID = @ProductId;

        FETCH NEXT FROM order_cursor INTO @ProductId, @OrderedQuantity;
    END;

    CLOSE order_cursor;
    DEALLOCATE order_cursor;
END;



-------------------------------------------------------------------------



UPDATE ORDERS
SET PRODUCT_PRICE = (SELECT P_PRICE FROM PRODUCTS WHERE PRODUCTS.PID = ORDERS.PRODUCT_ID),
    ORDER_TOTAL_PRICE = ORDERED_QUANTITY * (SELECT P_PRICE FROM PRODUCTS WHERE PRODUCTS.PID = ORDERS.PRODUCT_ID);



INSERT INTO PRODUCTS (P_IMAGE, P_NAME, P_QUANTITY, P_PRICE)
VALUES (0x, 'Product4', 100, 20.99),
       (0x, 'Product5', 5, 100.49),
       (0x, 'Product6', 25, 5.99),
	   (0x, 'Product7', 10, 50);

-- Insert 10 rows into ORDERS table with product details retrieved from PRODUCTS table
-- Insert 10 rows into ORDERS table with random products
INSERT INTO ORDERS (PRODUCT_ID, PRODUCT_NAME, CUSTOMER_ID, ORDERED_QUANTITY)
SELECT 
    P.PID AS PRODUCT_ID,
    P.P_NAME AS PRODUCT_NAME,
    1 AS CUSTOMER_ID,  -- Example customer ID
    2 AS ORDERED_QUANTITY  -- Example ordered quantity
FROM 
    PRODUCTS P
ORDER BY 
    NEWID()
OFFSET 0 ROWS
FETCH NEXT 10 ROWS ONLY;



select * from ADMINISTRATOR
select * from CUSTOMERS
select * from ORDERS
select * from PRODUCTS
	

drop table ORDERS
drop table PRODUCTS
drop table ADMINISTRATOR
drop table CUSTOMERS
drop trigger UpdateOrderPricesAndQuantity

delete from CUSTOMERS





------------------------EXAMPLE------------------------------------------
INSERT INTO PRODUCTS (P_NAME, P_QUANTITY, P_PRICE, P_DESCRIPTION)
VALUES 
    ('Product 1', 100, 10.99, 'Description for Product 1'),
    ('Product 2', 150, 20.49, 'Description for Product 2'),
    ('Product 3', 80, 5.99, 'Description for Product 3'),
    ('Product 4', 200, 15.75, 'Description for Product 4'),
    ('Product 5', 120, 8.99, 'Description for Product 5'),
    ('Product 6', 90, 12.49, 'Description for Product 6'),
    ('Product 7', 110, 6.25, 'Description for Product 7'),
    ('Product 8', 130, 18.99, 'Description for Product 8'),
    ('Product 9', 70, 9.75, 'Description for Product 9'),
    ('Product 10', 180, 14.49, 'Description for Product 10');

	-- Assuming the following customer IDs and product IDs exist
DECLARE @CustomerID1 INT = 1;
DECLARE @CustomerID2 INT = 2;
DECLARE @ProductID1 INT = 1;
DECLARE @ProductID2 INT = 2;

INSERT INTO ORDERS (PRODUCT_ID, PRODUCT_NAME, CUSTOMER_ID, ORDERED_QUANTITY, PRODUCT_PRICE, ORDER_TOTAL_PRICE, PRODUCT_DESCRIPTION)
VALUES 
    (@ProductID1, 'Product 1', @CustomerID1, 2, 10.99, 21.98, 'Description for Order 1'),
    (@ProductID2, 'Product 2', @CustomerID2, 1, 20.49, 20.49, 'Description for Order 2'),
    (@ProductID1, 'Product 1', @CustomerID1, 3, 10.99, 32.97, 'Description for Order 3'),
    (@ProductID2, 'Product 2', @CustomerID2, 2, 20.49, 40.98, 'Description for Order 4'),
    (@ProductID1, 'Product 1', @CustomerID1, 1, 10.99, 10.99, 'Description for Order 5'),
    (@ProductID2, 'Product 2', @CustomerID2, 4, 20.49, 81.96, 'Description for Order 6'),
    (@ProductID1, 'Product 1', @CustomerID1, 2, 10.99, 21.98, 'Description for Order 7'),
    (@ProductID2, 'Product 2', @CustomerID2, 1, 20.49, 20.49, 'Description for Order 8'),
    (@ProductID1, 'Product 1', @CustomerID1, 3, 10.99, 32.97, 'Description for Order 9'),
    (@ProductID2, 'Product 2', @CustomerID2, 2, 20.49, 40.98, 'Description for Order 10');
