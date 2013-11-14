CREATE TABLE [dbo].[Cat]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Color] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [OwnerId] INT NULL, 
    CONSTRAINT [FK_Cat_ToOwner] FOREIGN KEY (OwnerId) REFERENCES [Owner](OwnerId)
)
