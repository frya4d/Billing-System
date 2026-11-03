
    CREATE DATABASE BillingSystemDB;


USE BillingSystemDB;



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


    CREATE TABLE tbl_categories (
        category_id INT PRIMARY KEY IDENTITY(1,1),
        title NVARCHAR(100),
        description NVARCHAR(250)
    );


    INSERT INTO tbl_categories (title, description) 
    VALUES ('Phone', 'Smartphones and mobile devices'),
           ('Electronics', 'Electronic equipment and gadgets');



    CREATE TABLE tbl_products (
        product_id INT PRIMARY KEY IDENTITY(1,1),
        name NVARCHAR(100),
        category NVARCHAR(100),
        price decimal(10, 2),
        description NVARCHAR(250),
        quantity NVARCHAR(50),
        added_date NVARCHAR(50),
        added_by NVARCHAR(50)
    );

