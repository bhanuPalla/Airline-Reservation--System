/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [AdmID]
      ,[AdmFirstName]
      ,[AdmMiddleName]
      ,[AdmLastName]
      ,[AdmEmailID]
      ,[AdmLoginUserName]
      ,[AdmPassword]
  FROM [eAirline].[dbo].[AdminMaster]