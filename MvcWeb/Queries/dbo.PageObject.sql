CREATE TABLE [dbo].[PageObject] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]  VARCHAR (200) PRIMARY KEY,
    [order] INT           DEFAULT ((0)) NOT NULL
);

