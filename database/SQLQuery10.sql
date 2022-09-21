/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [UserId]
      ,[UserName]
      ,[UserPassword]
      ,[UserType]
      ,[UserActive]
      ,[UserCreateDate]
      ,[UserLastLoginDate]
  FROM [eAirline].[dbo].[UserMaster]