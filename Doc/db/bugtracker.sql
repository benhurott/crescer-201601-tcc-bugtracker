CREATE
  TABLE Application
  (
    IDApplication INTEGER NOT NULL ,
    IDUser        INTEGER NOT NULL ,
    Title         VARCHAR (255) NOT NULL ,
    Description   VARCHAR (300) NOT NULL ,
    Url           VARCHAR (255) NOT NULL ,
    Active BIT NOT NULL ,
    HashCode   VARCHAR (500) NOT NULL ,
    Image      VARCHAR (255) ,
    SpecialTag VARCHAR (255)
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
Application__IDApplication ON Application
(
  IDApplication
)
ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
Application__IDUser ON Application
(
  IDUser
)
ON "default"
GO
ALTER TABLE Application ADD CONSTRAINT Application_PK PRIMARY KEY CLUSTERED (
IDApplication)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE BugTracker
  (
    IDBugTracker  INTEGER NOT NULL ,
    IDApplication INTEGER NOT NULL ,
                  DATE DATETIME NOT NULL ,
    Description TEXT NOT NULL ,
    Status CHAR (1) NOT NULL
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
BugTracker__IDBugTracker ON BugTracker
(
  IDBugTracker
)
ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
BugTracker__IDApplication ON BugTracker
(
  IDApplication
)
ON "default"
GO
ALTER TABLE BugTracker ADD CONSTRAINT BugTrucker_PK PRIMARY KEY CLUSTERED (
IDBugTracker)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE BugTrackerNavigation
  (
    IDBugTrackerNavigation INTEGER NOT NULL ,
    IDBugTracker           INTEGER NOT NULL ,
    BrowserDescription     VARCHAR (500) NOT NULL ,
    SODescription          VARCHAR (255) NOT NULL
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
BugTrackerNavigation__IDBugTrackerNavigation ON BugTrackerNavigation
(
  IDBugTrackerNavigation
)
ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
BugTrackerNavigation__IDBugTracker ON BugTrackerNavigation
(
  IDBugTracker
)
ON "default"
GO
ALTER TABLE BugTrackerNavigation ADD CONSTRAINT BugTrackerNavigation_PK PRIMARY
KEY CLUSTERED (IDBugTrackerNavigation)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE BugTrackerTag
  (
    IDBugTrackerTag INTEGER NOT NULL ,
    IDBugTracker    INTEGER NOT NULL ,
    Name            VARCHAR (255) NOT NULL
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
BugTrackerTag__IDBugTrackerTag ON BugTrackerTag
(
  IDBugTrackerTag
)
ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
BugTrackerTag__IDBugTracker ON BugTrackerTag
(
  IDBugTracker
)
ON "default"
GO
ALTER TABLE BugTrackerTag ADD CONSTRAINT BugTrackerTag_PK PRIMARY KEY CLUSTERED
(IDBugTrackerTag)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE "User"
  (
    IDUser   INTEGER NOT NULL ,
    Nome     VARCHAR (255) NOT NULL ,
    Email    VARCHAR (255) NOT NULL ,
    Password VARCHAR (255) NOT NULL ,
    Active BIT NOT NULL ,
    AccountConfirmed BIT NOT NULL ,
    Image VARCHAR (255)
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
User__IDUser ON "User"
(
  IDUser
)
ON "default"
GO
ALTER TABLE "User" ADD CONSTRAINT User_PK PRIMARY KEY CLUSTERED (IDUser)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE UserRecovery
  (
    IDUserRecovery INTEGER NOT NULL ,
    IDUser         INTEGER NOT NULL ,
    RequestDate    DATETIME NOT NULL ,
    HashCode       VARCHAR (500) NOT NULL
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
UserRecovery__IDUserRecovery ON UserRecovery
(
  IDUserRecovery
)
ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
UserRecovery__IDUser ON UserRecovery
(
  IDUser
)
ON "default"
GO
ALTER TABLE UserRecovery ADD CONSTRAINT UserRecovery_PK PRIMARY KEY CLUSTERED (
IDUserRecovery)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

ALTER TABLE Application
ADD CONSTRAINT Application_User_FK FOREIGN KEY
(
IDUser
)
REFERENCES "User"
(
IDUser
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE BugTrackerNavigation
ADD CONSTRAINT BugTrackerNavigation_BugTracker_FK FOREIGN KEY
(
IDBugTracker
)
REFERENCES BugTracker
(
IDBugTracker
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE BugTrackerTag
ADD CONSTRAINT BugTrackerTag_BugTracker_FK FOREIGN KEY
(
IDBugTracker
)
REFERENCES BugTracker
(
IDBugTracker
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE BugTracker
ADD CONSTRAINT BugTracker_Application_FK FOREIGN KEY
(
IDApplication
)
REFERENCES Application
(
IDApplication
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE UserRecovery
ADD CONSTRAINT UserRecovery_User_FK FOREIGN KEY
(
IDUser
)
REFERENCES "User"
(
IDUser
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO