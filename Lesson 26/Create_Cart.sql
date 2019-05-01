CREATE TABLE [dbo].[Cart] (
    [CartID]     INT IDENTITY (1, 1) NOT NULL,
    [ProductID]  INT NULL,
    [CustomerID] INT NULL,
    [Quantity]   INT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([CartID] ASC),
    CONSTRAINT [FK_Cart_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Cart_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID])
);
