/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CityCode]
      ,[CityName]
      ,[CityActive]
  FROM [eAirline].[dbo].[DestinationMaster]