CREATE TABLE PageViewObject
(
		[id] INT IDENTITY(1,1), 
        [name] VARCHAR(200) NOT NULL,
        [order] INT NOT NULL DEFAULT 0
)