﻿CREATE TABLE [dbo].[PagesContents]
(
	[Pc_id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Pc_page_id] INT NOT NULL,
	[Pc_name] nvarchar(70) NOT NULL,
	[Pc_Content] nvarchar(MAX) NOT NULL,
	[Pc_Status] smallint NOT NULL,
	[Pc_creation_date] Datetime NOT NULL,
	[Pc_modification_date] Datetime NOT NULL,
	[Pc_creation_user] INT NOT NULL,
	[Pc_modification_User] INT NOT NULL,
	CONSTRAINT f_Pc_page_id FOREIGN KEY ([Pc_page_id]) REFERENCES Pages(Page_id),
	CONSTRAINT f_Pc_Status FOREIGN KEY ([Pc_Status]) REFERENCES LookupValues(lv_id),
	CONSTRAINT f_Pc_creation_user FOREIGN KEY ([Pc_creation_user]) REFERENCES Users(Usr_id),
	CONSTRAINT f_Pc_modification_user FOREIGN KEY ([Pc_modification_User]) REFERENCES Users(Usr_id),
)
