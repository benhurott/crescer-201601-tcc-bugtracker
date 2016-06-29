CREATE TABLE Activation(
	IDActivation int IDENTITY NOT NULL,
	Code varchar(500) NOT NULL,
	IDUser int NOT NULL,
	CONSTRAINT PK_IDActivation PRIMARY KEY(IDActivation),
	CONSTRAINT UK_Code UNIQUE(Code),
	CONSTRAINT FK_IDUser FOREIGN KEY(IDUser) REFERENCES [BugTracker].[dbo].[User](IDUser)
)
CREATE INDEX IX_Code
ON Activation (Code)