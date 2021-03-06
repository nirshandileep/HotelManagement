/****** Object:  StoredProcedure [dbo].[usp_CustomerInsert]    Script Date: 10/21/2013 06:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_CustomerInsert] 
    @CompanyId int,
    @CustomerName nvarchar(100),
    @MemberCode nvarchar(50),
    @Gender varchar(10),
    @GuestTypeId int,
    @Phone nvarchar(25),
    @Fax nvarchar(25),
    @Mobile nvarchar(25),
    @Email nvarchar(50),
    @CompanyName nvarchar(100),
    @CompanyAddress nvarchar(150),
    @CompanyNotes nvarchar(MAX),
    @BillingAddress nvarchar(MAX),
    @BillingCity nvarchar(50),
    @BillingState nvarchar(50),
    @BillingCountryId int,
    @BillingPostCode nvarchar(50),
    @PassportNumber nvarchar(50),
    @PassportCountryOfIssue int,
    @PassportExpirationDate datetime,
    @CCType int,
    @CCNo int,
    @CCExpirationDate datetime,
    @CCNameOnCard nvarchar(100),
    @Car nvarchar(50),
    @CarLicensePlate nvarchar(50),
    @DriverLicense nvarchar(50),
    @StatusId int,
    @CreatedUser int,
    @CreatedDate datetime,    
    @IsDeleted bit
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Customer] ([CompanyId], [CustomerName], [MemberCode], [Gender], [GuestTypeId], [Phone], [Fax], [Mobile], [Email], [CompanyName], [CompanyAddress], [CompanyNotes], [BillingAddress], [BillingCity], [BillingState], [BillingCountryId], [BillingPostCode], [PassportNumber], [PassportCountryOfIssue], [PassportExpirationDate], [CCType], [CCNo], [CCExpirationDate], [CCNameOnCard], [Car], [CarLicensePlate], [DriverLicense], [StatusId], [CreatedUser], [CreatedDate],  [IsDeleted])
	VALUES ( @CompanyId, @CustomerName, @MemberCode, @Gender, @GuestTypeId, @Phone, @Fax, @Mobile, @Email, @CompanyName, @CompanyAddress, @CompanyNotes, @BillingAddress, @BillingCity, @BillingState, @BillingCountryId, @BillingPostCode, @PassportNumber, @PassportCountryOfIssue, @PassportExpirationDate, @CCType, @CCNo, @CCExpirationDate, @CCNameOnCard, @Car, @CarLicensePlate, @DriverLicense, @StatusId, @CreatedUser, @CreatedDate,  @IsDeleted)
	
               
	COMMIT
