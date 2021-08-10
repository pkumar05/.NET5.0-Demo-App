CREATE TABLE [CP].[CustomerOrders] (
    [Id]          VARCHAR (36)    NOT NULL,
    [CustomerId]  VARCHAR (36)    NOT NULL,
    [OrderId]     VARCHAR (36)   NULL,
    [Description] NVARCHAR (2000) NULL,
    [Active]      BIT             DEFAULT ((1)) NOT NULL,
    [CreatedBy]    NVARCHAR (256)  NOT NULL,
    [CreatedDate] DATETIME        NOT NULL,
    [UpdatedBy]    NVARCHAR (256)  NULL,
    [UpdatedDate] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [CP].[Customers]([Id]),
    FOREIGN KEY ([OrderId]) REFERENCES [CP].[Orders] ([Id])
);

