CREATE TABLE [dbo].[Pages]
(
	[Page_id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Page_name] nvarchar(70) NOT NULL ,
	[Page_status] smallint NOT NULL ,
	[Page_creation_date] Datetime NOT NULL ,
	[Page_modification_date] Datetime NOT NULL ,
	[Page_creation_user] INT NOT NULL ,
	[Page_modification_user] INT NOT NULL ,
	[Page_type] smallint Not NULL,
	CONSTRAINT f_Page_status FOREIGN KEY ([Page_status]) REFERENCES LookupValues(lv_id),
	CONSTRAINT f_Page_type FOREIGN KEY ([Page_type]) REFERENCES LookupValues(lv_id),
	CONSTRAINT f_Page_creation_user FOREIGN KEY ([Page_creation_user]) REFERENCES Users(Usr_id),
	CONSTRAINT f_Page_modification_user FOREIGN KEY ([Page_modification_user]) REFERENCES Users(Usr_id),
)
