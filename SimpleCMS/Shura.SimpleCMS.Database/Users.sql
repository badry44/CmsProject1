CREATE TABLE [dbo].[Users]
(
	[Usr_id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Usr_username] nvarchar(40) NOT NULL,
	[Usr_password] nvarchar(200) NOT NULL,
	[Usr_email] nvarchar(200) NOT NULL,
	[Usr_creation_date] datetime Not NUll,
	[Usr_status] smallint NOT NULL,
	[Usr_last_valid_login] datetime NULL,
	[Usr_last_invalid_login] datetime NULL,
	CONSTRAINT f_Usr_status FOREIGN KEY ([Usr_status]) REFERENCES LookupValues(lv_id),
)
