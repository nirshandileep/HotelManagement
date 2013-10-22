INSERT INTO [dbo].[CreditCardType]
           ([Name]
           ,[ProcessingFee]
           ,[CompanyId]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[UpdatedUser]
           ,[UpdatedDate])

select 'AMEX', 0.00, 1, 1, GETUTCDATE(), NULL, NULL
UNION ALL
select 'VISA', 0.00, 1, 1, GETUTCDATE(), NULL, NULL
union all
select 'Master Card', 0.00, 1, 1, GETUTCDATE(), NULL, NULL

GO

INSERT INTO [dbo].[Status]
           ([StatusId]
           ,[StatusName]
           ,[StatusDescription]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[UpdatedUser]
           ,[UpdatedDate])
select 1 ,'Active' ,'Used for all Active instances' ,1 ,GETUTCDATE() ,null ,null
union all
select 2 ,'InActive' ,'Used for all In Active instances' ,1 ,GETUTCDATE() ,null ,null
union all
select 3 ,'Confirmed' ,'Reservation - Confirmed' ,1 ,GETUTCDATE() ,null ,null
union all
select 4 ,'Modify' ,'Reservation - Modify' ,1 ,GETUTCDATE() ,null ,null
union all
select 5 ,'Check in' ,'Reservation - Check in' ,1 ,GETUTCDATE() ,null ,null
union all
select 6 ,'Cancel' ,'Reservation - Cancel' ,1 ,GETUTCDATE() ,null ,null
union all
select 7 ,'No Show' ,'Reservation - No Show' ,1 ,GETUTCDATE() ,null ,null

GO

INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[EmailAddress]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[UpdatedUser]
           ,[UpdatedDate]
           ,[StatusId]
		   ,[CompanyId])
     VALUES
           ('admin'
           ,'a'
           ,'VinIt First'
           ,'VinIt Last'
           ,'VinIt@VinIt.com'
           ,1
           ,GETUTCDATE()
           ,null
           ,null
           ,1
           ,1)
GO


INSERT INTO [dbo].[CompanyType]
           ([CompanyTypeId]
           ,[CompanyTypeName]
           ,[CompanyTypeDescription]
           ,[UpdatedDate]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[UpdatedUser])
     VALUES
           (1
           ,'Hotel'
           ,'General Hotel'
           ,null
           ,1
           ,GETUTCDATE()
           ,null)
GO


INSERT INTO [dbo].[Company]
           ([CompanyName]
           ,[CompanyAddress]
           ,[CompanyCity]
           ,[CompanyEmail]
           ,[CompanyTelephone]
           ,[CompanyTypeId]
           ,[StatusId]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[UpdatedUser]
           ,[UpdatedDate])
     VALUES
           ('VinIt Hotels'
           ,'Company Address'
           ,'City'
           ,'Company Email'
           ,'1234567890'
           ,1
           ,1
           ,1
           ,GETUTCDATE()
           ,null
           ,null)
GO

INSERT INTO [dbo].[GuestType]
           ([GuestTypeName]
           ,[GuestTypeDescription]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[UpdatedUser]
           ,[UpdatedDate])
     VALUES
           ('Guest Type 1'
           ,'Guest Type 1'
           ,1
           ,GETUTCDATE()
           ,null
           ,null)
GO

INSERT INTO [dbo].[PaymentType]
           ([PaymentTypeName]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[UpdatedUser]
           ,[UpdatedDate])
select 'Cash', 1, GETUTCDATE() ,null ,null
union all
select 'Cheque', 1, GETUTCDATE() ,null ,null
union all
select 'Credit Card', 1, GETUTCDATE() ,null ,null
union all
select 'Paypal', 1, GETUTCDATE() ,null ,null
union all
select 'Other', 1, GETUTCDATE() ,null ,null

GO

