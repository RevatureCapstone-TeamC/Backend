/*******************************************************************************
   ECommerce Database - Version 1.0
   Script: ECommerceSQL.sql
   Description: Creates and populates the ECommerce database.
********************************************************************************/

/*******************************************************************************
   Drop Constraints
********************************************************************************/
ALTER TABLE [ecd].[Wishlist] DROP CONSTRAINT [fk_ProductId];
GO
ALTER TABLE [ecd].[Wishlist] DROP CONSTRAINT [fk_UserId];
GO

ALTER TABLE [ecd].[Deals] DROP CONSTRAINT [fk_Product_Id];
GO
ALTER TABLE [ecd].[Deals] DROP CONSTRAINT [fk_User_Id];
GO

ALTER TABLE [ecd].[Cart] DROP CONSTRAINT [fk_ProductID];
GO
ALTER TABLE [ecd].[Cart] DROP CONSTRAINT [fk_UserID];
GO
/*******************************************************************************
   Drop Tables
********************************************************************************/

   DROP TABLE [ecd].[Products];
   GO

   DROP TABLE [ecd].[Users];
   GO

   DROP TABLE [ecd].[Wishlist];
   GO

   DROP TABLE [ecd].[Deals];
   GO

   DROP TABLE [ecd].[Cart];
   GO

/*******************************************************************************
   Drop Schema
********************************************************************************/

   DROP SCHEMA [ecd];
   GO

/*******************************************************************************
   Create Schema
********************************************************************************/

   CREATE SCHEMA [ecd];
   GO

/*******************************************************************************
   Create Tables
********************************************************************************/

   CREATE TABLE [ecd].[Users]
   (
      [UserId] INT IDENTITY(1,1) NOT NULL,
      [UserFirstName] NVARCHAR(255) NOT NULL,
      [UserLastName] NVARCHAR(255) NOT NULL,
      [UserEmail] NVARCHAR(255) UNIQUE NOT NULL,
      [UserPassword] NVARCHAR(255) NOT NULL,
      [IfAdmin] BIT DEFAULT 0,
      CHECK ([UserEmail] LIKE '%@%.%')
   );
   GO

    /**
    Add foreign key to the products table for deals
    **/
   CREATE TABLE [ecd].[Products]
   (
      [ProductId] INT IDENTITY(1,1) NOT NULL,
      [ProductName] NVARCHAR(255) NOT NULL,
      [ProductQuantity] INT NOT NULL,
      [ProductPrice] DECIMAL(19, 4) NOT NULL,
      [ProductDescription] NVARCHAR(255),
      [ProductImage] NVARCHAR(255)
   );
   GO

   /**
   CREATE Table for wishlist
    wishlist_table {
        id (pk),
        user_id (fk),
        prod_id (fk)
    }
   **/
   
   CREATE TABLE [ecd].[Wishlist]
   (
      [WishlistId] INT IDENTITY(1,1) NOT NULL,
      [fk_ProductId] INT NOT NULL,
      [fk_UserId] INT NOT NULL
   );
   GO

   CREATE TABLE [ecd].[Cart]
   (
      [CartId] INT IDENTITY(1,1) NOT NULL,
      [fk_ProductID] INT NOT NULL,
      [fk_UserID] INT NOT NULL
   );
   GO

   /**
   CREATE Table for deals
    sales_table {
        id (pk),
        admin_id (fk),
        prod_id (fk),
        sale_amount DECIMAL(19,4)
    }
   **/

   CREATE TABLE [ecd].[Deals]
   (
      [DealId] INT IDENTITY(1,1) NOT NULL,
      [fk_Product_Id] INT NOT NULL,
      [SalePrice] DECIMAL(19, 4) NOT NULL
   );
   GO

/*******************************************************************************
   Create Primary Key References
********************************************************************************/

   ALTER TABLE [ecd].[Users]
      ADD CONSTRAINT [PK_UserId]
      PRIMARY KEY ([UserId]);
   GO

   ALTER TABLE [ecd].[Products]
      ADD CONSTRAINT [PK_ProductId]
      PRIMARY KEY ([ProductId]);
   GO

   ALTER TABLE [ecd].[Wishlist]
      ADD CONSTRAINT [PK_WishlistId]
      PRIMARY KEY ([WishlistId]);
   GO

   ALTER TABLE [ecd].[Deals]
      ADD CONSTRAINT [PK_DealId]
      PRIMARY KEY ([DealId]);
   GO

   ALTER TABLE [ecd].[Cart]
      ADD CONSTRAINT [PK_CartId]
      PRIMARY KEY ([CartId]);
   GO

   ALTER TABLE [ecd].[Wishlist] 
      ADD CONSTRAINT [ProductId] 
      FOREIGN KEY ([fk_ProductId])
      REFERENCES [ecd].[Products]([ProductId]);
   GO
   ALTER TABLE [ecd].[Wishlist] 
      ADD CONSTRAINT [UserId] 
      FOREIGN KEY ([fk_UserId])
      REFERENCES [ecd].[Users]([UserId]);
   GO

   ALTER TABLE [ecd].[Cart] 
      ADD CONSTRAINT [Product-ID] 
      FOREIGN KEY ([fk_ProductID])
      REFERENCES [ecd].[Products]([ProductId]);
   GO
   ALTER TABLE [ecd].[Cart] 
      ADD CONSTRAINT [User-ID] 
      FOREIGN KEY ([fk_UserID])
      REFERENCES [ecd].[Users]([UserId]);
   GO

   ALTER TABLE [ecd].[Deals] 
      ADD CONSTRAINT [Product_Id] 
      FOREIGN KEY ([fk_Product_Id])
      REFERENCES [ecd].[Products]([ProductId]);
   GO

/*******************************************************************************
   Seed Database
********************************************************************************/

INSERT INTO [ecd].[Users] ([UserFirstName], [UserLastName], [UserEmail], [UserPassword])
   VALUES
      ('John', 'Doe', 'John@no.com', 'JohnDoe'),
      ('Jane', 'Doe', 'Jane@no.com', 'JaneDoe'),
      ('Johnny', 'Doe', 'Johnny@no.com', 'JohnnyDoe'),
      ('Jannie', 'Doe', 'Jannie@no.com', 'JannieDoe');
GO

INSERT INTO [ecd].[Products] ([ProductName], [ProductQuantity], [ProductPrice], [ProductDescription], [ProductImage])
   VALUES
      ('Altoid Mint', 2, 2.99, 'Curiously strong mints', 'https://www.altoids.com/sites/g/files/fnmzdf651/files/migrate-product-files/khgaap6bku2q9b8qrioh.png'),
      ('S3 Watch', 4, 399.99, 'More computing power than the space shuttle!', 'https://image-us.samsung.com/SamsungUS/home/mobile/wearables/pdp/sm-r760ndaaxar/gallery/S3_Frontier_Front_1600x1200.jpg?$product-details-jpg$'),
      ('Lenovo Thinkpad', 3, 599.94, 'Not the worst laptop... but not the best. Just... OK', 'https://p1-ofp.static.pub/medias/bWFzdGVyfHJvb3R8Mjc4NTk5fGltYWdlL3BuZ3xoMWEvaGQxLzEwODIyNzQwNDc1OTM0LnBuZ3w1MzRhMTMxYzE3YmY4MTgyOWNmYWIxNjA3OGVjNjMzZjBiM2JlNGI0ZDkyNGY3ZTRhOGU5MmI2OTVjNWE2ZTJl/lenovo-laptop-thinkpad-l14-intel-hero1.png'),
      ('Garuda Arch Linux OS', 999, 0.0, 'Yeah, it''s a free OS. Yes, it''s real. Yes, you should check it out.', 'https://www.addictivetips.com/app/uploads/2021/11/garuda-desktop-installer.png'),
      ('Corsair K70 Mk II', 6, 240.00, 'High sensitivity keyboard for gamers and professionals alike.', 'https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491897_sd.jpg');
GO

INSERT INTO ecd.Wishlist(fk_ProductId, fk_UserId)
   VALUES 
      (3, 1),
      (5, 1),
      (5, 3)


SELECT * FROM [ecd].Users;
SELECT * FROM [ecd].Products;
