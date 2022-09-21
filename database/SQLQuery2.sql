/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [AirplaneID]
      ,[AirpalneType]
      ,[AirplaneCapacity]
  FROM [eAirline].[dbo].[AirplaneMaster]