CREATE TABLE [CP].[Customers] (
    [Id]              VARCHAR (36)    NOT NULL,
    [FullName]        NVARCHAR (500)  NULL,
    [Address]         NVARCHAR (500)  NULL,
    [Phone]           NVARCHAR (20)   NULL,
    [Email]           NVARCHAR (320)  NULL,
    [Description]     NVARCHAR (2000) NULL,
    [IsGoldMember]    BIT             DEFAULT ((0)) NOT NULL,
    [IsDiamondMember] BIT             DEFAULT ((0)) NOT NULL,
    [Active]          BIT             DEFAULT ((1)) NOT NULL,
    [CreatedBy]        NVARCHAR (256)  NOT NULL,
    [CreatedDate]     DATETIME        NOT NULL,
    [UpdatedBy]        NVARCHAR (256)  NULL,
    [UpdatedDate]     DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

