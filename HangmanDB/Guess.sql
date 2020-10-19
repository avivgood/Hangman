CREATE TABLE [dbo].[Guess]
(
	[pid] INT NOT NULL PRIMARY KEY, 
    [gid] INT NOT NULL PRIMARY KEY, 
    [guess] NVARCHAR(1) NOT NULL PRIMARY KEY
    FOREIGN KEY (pid) REFERENCES Participation(pid),
	FOREIGN KEY (gid) REFERENCES Participation(gid)
)
