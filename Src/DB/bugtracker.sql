CREATE
  TABLE Application
  (
    IDApplication INTEGER IDENTITY NOT NULL ,
    IDUser        INTEGER NOT NULL ,
    Title         VARCHAR (255) NOT NULL ,
    Description   VARCHAR (300) NOT NULL ,
    Url           VARCHAR (255) NOT NULL ,
    Active BIT NOT NULL ,
    Image      VARCHAR (255) ,
    SpecialTag VARCHAR (255)
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
    IDBugTracker  INTEGER IDENTITY NOT NULL ,
    IDApplication INTEGER NOT NULL ,
    OccurredDate  DATETIME NOT NULL ,
    Description TEXT NOT NULL ,
    Status INTEGER NOT NULL
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
    IDBugTrackerNavigation INTEGER IDENTITY NOT NULL ,
    IDBugTracker           INTEGER NOT NULL ,
    BrowserName            VARCHAR (100) NOT NULL ,
    BrowserVersion         VARCHAR (10) NOT NULL ,
    PlatformName           VARCHAR (100) NOT NULL
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
BugTrackerNavigation__IDX ON BugTrackerNavigation
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
    IDBugTrackerTag INTEGER IDENTITY NOT NULL ,
    IDBugTracker    INTEGER NOT NULL ,
    Name            VARCHAR (255) NOT NULL
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
    IDUser   INTEGER IDENTITY NOT NULL ,
    Name     VARCHAR (255) NOT NULL ,
    Email    VARCHAR (255) NOT NULL ,
    Password VARCHAR (255) ,
    Active BIT NOT NULL ,
    AccountConfirmed BIT NOT NULL ,
    Image VARCHAR (255),
    HashCode       VARCHAR (500) NOT NULL
  )
  ON "default"
GO
CREATE UNIQUE NONCLUSTERED INDEX
User__Email ON "User"
(
  Email
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
    IDUserRecovery INTEGER IDENTITY NOT NULL ,
    IDUser         INTEGER NOT NULL ,
    RequestDate    DATETIME NOT NULL ,
    HashCode       VARCHAR (500) NOT NULL
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
