﻿CREATE TABLE [dbo].[Cat]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Color] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL
)