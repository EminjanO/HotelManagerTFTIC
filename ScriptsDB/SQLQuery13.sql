/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [id]
      ,[firstname]
      ,[lastname]
      ,[email]
      ,[phone]
      ,[add_info]
      ,[created_at]
      ,[last_update]
      ,[isActive]
  FROM [HotelManager].[dbo].[guest]

  UPDATE guest SET firstname = Jean-Paul, lastname = Trois, email = J.P2@yolo.com, phone = 22222222222, add_info = NULL, last_update = 06-12-18 14:14:32 WHERE id = 10