CREATE TABLE [CP].[ProductType] (
    [Id]          VARCHAR (36)    NOT NULL,
    [Name]        NVARCHAR (500)  NULL,
    [Code]        VARCHAR (100) NULL,
    [Description] NVARCHAR (2000) NULL,
    [Active]      BIT             DEFAULT ((1)) NOT NULL,
    [CreatedBy]    NVARCHAR (256)  NOT NULL,
    [CreatedDate] DATETIME        NOT NULL,
    [Updatedby]    NVARCHAR (256)  NULL,
    [UpdatedDate] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

