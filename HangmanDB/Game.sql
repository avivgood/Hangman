CREATE TABLE [dbo].[Game]
(
	[gid] INT NOT NULL PRIMARY KEY, 
    [word] NVARCHAR(50) NOT NULL, 
    [MaxTries] INT NOT NULL, 
    [HasStarted] BIT NOT NULL, 
    [HasEnded] BIT NOT NULL
)
