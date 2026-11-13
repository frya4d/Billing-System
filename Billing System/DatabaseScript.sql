CREATE DATABASE BillingSystemDB;
GO

USE BillingSystemDB;
GO

CREATE TABLE tbl_users (
    id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(50),
    last_name NVARCHAR(50),
    email NVARCHAR(100),
    username NVARCHAR(50),
    password NVARCHAR(100),
    contact NVARCHAR(50),
    gender NVARCHAR(20),
    address NVARCHAR(250),
    user_type NVARCHAR(50)
);
GO

CREATE TABLE tbl_categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    title NVARCHAR(100),
    description NVARCHAR(250)
);
GO

INSERT INTO tbl_categories (title, description) 
VALUES ('Phone', 'Smartphones and mobile devices'),
       ('Electronics', 'Electronic equipment and gadgets');
GO

CREATE TABLE tbl_products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100),
    category NVARCHAR(100),
    price DECIMAL(10, 2),
    description NVARCHAR(250),
    quantity NVARCHAR(50),
    added_date NVARCHAR(50),
    added_by NVARCHAR(50)
);
GO

CREATE TABLE tbl_customer (
    id INT PRIMARY KEY IDENTITY(1,1),
    type NVARCHAR(50),
    name NVARCHAR(50),
    contact NVARCHAR(50),
    email NVARCHAR(100),
    address NVARCHAR(250)
);
GO

CREATE TABLE [Transaction] (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    SubTotal DECIMAL(18, 2),
    DiscountPercent DECIMAL(5, 2),
    Total DECIMAL(18, 2),
    PaidAmount DECIMAL(18, 2),
    ReturnAmount DECIMAL(18, 2),
    AddedDate DATETIME,
    AddedBy INT,
    FOREIGN KEY (CustomerID) REFERENCES tbl_customer(id)
);
GO

CREATE TABLE TransactionDetails (
    DetailID INT PRIMARY KEY IDENTITY(1,1),
    TransactionID INT,
    ProductID INT,
    Price DECIMAL(18, 2),
    Quantity INT,
    Total DECIMAL(18, 2),
    FOREIGN KEY (TransactionID) REFERENCES [Transaction](TransactionID),
    FOREIGN KEY (ProductID) REFERENCES tbl_products(product_id)
);
GO
