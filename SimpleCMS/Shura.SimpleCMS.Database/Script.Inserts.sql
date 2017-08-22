﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


SET IDENTITY_INSERT [dbo].[LookupTitles] ON 
INSERT [dbo].[LookupTitles] ([lt_Id], [lt_title], [lt_title_ar]) VALUES (1, N'Status', N'الحالة')
INSERT [dbo].[LookupTitles] ([lt_Id], [lt_title], [lt_title_ar]) VALUES (2, N'PageType', N'نوع الصفحة')
SET IDENTITY_INSERT [dbo].[LookupTitles] OFF 
GO

SET IDENTITY_INSERT [dbo].[LookupValues] ON 
INSERT [dbo].[LookupValues] ([lv_id], [lv_lt_id], [lv_value],[lv_value_ar]) VALUES (1,1, N'Active', N'نشط')
INSERT [dbo].[LookupValues] ([lv_id], [lv_lt_id], [lv_value],[lv_value_ar]) VALUES (2,1, N'Inactive', N'غير نشط')
INSERT [dbo].[LookupValues] ([lv_id], [lv_lt_id], [lv_value],[lv_value_ar]) VALUES (3,2, N'StartPage', N'صفحة بداية')
INSERT [dbo].[LookupValues] ([lv_id], [lv_lt_id], [lv_value],[lv_value_ar]) VALUES (4,2, N'NormalPage', N'صفحة عادية')
INSERT [dbo].[LookupValues] ([lv_id], [lv_lt_id], [lv_value],[lv_value_ar]) VALUES (5,2, N'GalleryPage', N'صفحة صور')
SET IDENTITY_INSERT [dbo].[LookupValues] OFF