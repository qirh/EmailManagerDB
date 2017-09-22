CREATE TABLE Attachment(
    ATT_Order     INTEGER NOT NULL,
    ATT_Name      VARCHAR (50),
    ATT_Extention VARCHAR (5),
    ATT_File      VARCHAR (300) NOT NULL,
    MS_ID         INTEGER NOT NULL,
    CONSTRAINT Attachment_PK PRIMARY KEY CLUSTERED (ATT_Order, MS_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE TABLE Email_Account(
    Email_ID          INTEGER NOT NULL,
    Email_Address     VARCHAR (100) NOT NULL,
    Email_Password    VARCHAR (100) NOT NULL,
    Email_Preferences VARCHAR (100),
	Email_POP3		  BIT NOT NULL,
    User_ID           INTEGER NOT NULL,
    SP_ID             INTEGER NOT NULL,
    CONSTRAINT Email_Account_PK PRIMARY KEY CLUSTERED (Email_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE TABLE Email_Message(
    MS_ID                INTEGER NOT NULL,
    MS_Recipients_Sender VARCHAR (500) NOT NULL,
    MS_Subject           VARCHAR (50),
    MS_Body              VARCHAR (5000),
    MS_TimeStamp         DATETIME NOT NULL,
	MS_Sent              BIT NOT NULL,
    Email_ID             INTEGER NOT NULL,
    CONSTRAINT Email_Message_PK PRIMARY KEY CLUSTERED (MS_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE TABLE Received_Email(
    MS_ID INTEGER NOT NULL,
    MSR_Priority BIT,
    MSR_SpamFlag BIT,
	MSR_Read BIT,
    CONSTRAINT Received_Email_PK PRIMARY KEY CLUSTERED (MS_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE TABLE Sent_Email(
    MS_ID INTEGER NOT NULL,
    MSS_Importance_Flag BIT NOT NULL,
	MSS_Successfully_Sent BIT NOT NULL,
    CONSTRAINT Sent_Email_PK PRIMARY KEY CLUSTERED (MS_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE TABLE Server_Info(
    SV_ID       INTEGER NOT NULL,
    SV_Name     VARCHAR (100) NOT NULL,
    SV_Protocol VARCHAR (10) NOT NULL,
    SV_Port     NUMERIC (5) NOT NULL,
    SV_SSLFlag BIT NOT NULL,
    SV_STARTTLSFlag BIT NOT NULL,
    SP_ID INTEGER NOT NULL,
    CONSTRAINT Server_PK PRIMARY KEY CLUSTERED (SV_ID, SP_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE TABLE Service_Provider(
    SP_ID   INTEGER NOT NULL,
    SP_Name VARCHAR (50) NOT NULL,
    CONSTRAINT Service_Provider_PK PRIMARY KEY CLUSTERED (SP_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE TABLE User_Info(
    User_ID       INTEGER NOT NULL,
    User_Name     VARCHAR (50) NOT NULL,
    User_Password VARCHAR (50),
    CONSTRAINT User_Info_PK PRIMARY KEY CLUSTERED (User_ID)
WITH(
    ALLOW_PAGE_LOCKS = ON,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

ALTER TABLE Attachment
ADD CONSTRAINT Attachment_Email_Message_FK FOREIGN KEY(
MS_ID)
REFERENCES Email_Message(
MS_ID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

ALTER TABLE Email_Account
ADD CONSTRAINT Email_Account_Service_Provider_FK FOREIGN KEY(
SP_ID)
REFERENCES Service_Provider(
SP_ID)
ON DELETE No Action 
ON UPDATE No Action
GO

ALTER TABLE Email_Account
ADD CONSTRAINT Email_Account_User_Info_FK FOREIGN KEY(
User_ID)
REFERENCES User_Info(
User_ID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

ALTER TABLE Email_Message
ADD CONSTRAINT Email_Message_Email_Account_FK FOREIGN KEY(
Email_ID)
REFERENCES Email_Account(
Email_ID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

ALTER TABLE Sent_Email
ADD CONSTRAINT FK_ASS_1 FOREIGN KEY(
MS_ID)
REFERENCES Email_Message(
MS_ID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

ALTER TABLE Received_Email
ADD CONSTRAINT FK_ASS_2 FOREIGN KEY(
MS_ID)
REFERENCES Email_Message(
MS_ID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

ALTER TABLE Server_Info
ADD CONSTRAINT Server_Service_Provider_FK FOREIGN KEY(
SP_ID)
REFERENCES Service_Provider(
SP_ID)
ON DELETE CASCADE 
ON UPDATE CASCADE
GO

/* NOT GENERATED */

ALTER TABLE [Email].[dbo].[Email_Account]
ADD CONSTRAINT Email_Account_Unique UNIQUE(
User_ID, Email_Address)

ALTER TABLE [Email].[dbo].[User_Info]
ADD CONSTRAINT User_Info_Unique UNIQUE(
User_Name)

ALTER TABLE [Email].[dbo].[User_Info]
ADD CONSTRAINT User_Info_IDRange Check(
User_ID >= 1 and User_ID <= 10000)

ALTER TABLE [Email].[dbo].[Service_Provider]
ADD CONSTRAINT Service_Provider_IDRange Check(
SP_ID >= 20000 and SP_ID <= 25000)

ALTER TABLE [Email].[dbo].[Server_Info]
ADD CONSTRAINT Server_IDRange Check(
SV_ID >= 30000 and SV_ID <= 40000)

ALTER TABLE [Email].[dbo].[Email_Account]
ADD CONSTRAINT Email_Account_IDRange Check(
Email_ID >= 50000 and Email_ID <= 100000)

ALTER TABLE [Email].[dbo].[Email_Message]
ADD CONSTRAINT Email_Message_IDRange Check(
MS_ID >= 1000000 and MS_ID <= 6000000)