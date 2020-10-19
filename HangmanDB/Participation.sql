CREATE TABLE [dbo].[Participation]
(
	[pid] INT NOT NULL PRIMARY KEY, 
    [gid] INT NOT NULL PRIMARY KEY,
	[currWord] NVARCHAR(50) NULL, 
    [victory] BIT NULL, 
    FOREIGN KEY (pid) REFERENCES Player(pid),
	FOREIGN KEY (gid) REFERENCES Game(gid)
)
