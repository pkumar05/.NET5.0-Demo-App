CREATE TABLE [CP].[Orders] (
    [Id]          VARCHAR (36)   NOT NULL,
    [Name]        NVARCHAR (500) NULL,
    [ProductId]   VARCHAR (36)   NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Active]      BIT            DEFAULT ((1)) NOT NULL,
    [CreatedBy]    NVARCHAR (256) NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]    NVARCHAR (256) NULL,
    [UpdatedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProductId]) REFERENCES [CP].[Products] ([Id])
);

