CREATE TABLE [dbo].[LookupValues]
(
	[lv_id] smallint NOT NULL PRIMARY KEY identity(1,1),
	[lv_lt_id] smallint NOT NULL,
	[lv_value]  nvarchar(40) Not NULL,
	[lv_value_ar]  nvarchar(40) Not NULL,
	CONSTRAINT  f_lv_lt_id FOREIGN KEY ([lv_lt_id]) REFERENCES LookupTitles(Lt_id),
)
