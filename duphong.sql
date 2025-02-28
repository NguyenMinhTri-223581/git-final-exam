CREATE PROC USP_GetAccountByUserName
@UserName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = @UserName
END
GO

EXEC dbo.USP_GetAccountByUserName @UserName = N'dat2222'

SELECT COUNT( *) FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = N'tri1111' AND PASSWORD = N'tri1111'

CREATE PROC USP_Login
@UserName nvarchar(100) ,@Password nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = @Username and PASSWORD = @Password 
END
GO

SELECT * FROM dbo.BAN


 CREATE PROC USP_Table
AS

	SELECT TD.tenmon, HCT.COUNT,TD.gia, TD.gia*HCT.COUNT AS totalPrice FROM dbo. CTHOADON AS HCT, dbo.HOADON AS HD, dbo.THUCDON AS TD 
	WHERE HCT.IDHOADON = HD.ID AND HCT.IDTHUCDON = TD.ID AND HD.STATUS = 0 AND HD.IDBANG =6


	SELECT MAX(ID) FROM dbo. HOADON
	SELECT * FROM dbo. THUCDON
	SELECT * FROM dbo. LOAIMON
GO
EXEC dbo.USP_Table

UPDATE dbo.BAN SET STATUS = N'CÓ NGƯỜI' WHERE ID = 8




SELECT * FROM dbo.THUCDON WHERE idloai = 4

 -- cau truy vấn inser  thêm bill
 ALTER PROC USP_InsertBillInfo
    @idBill INT,
    @idFood INT,
    @count INT
AS
BEGIN
    DECLARE @isExistsBillInfo INT;
    DECLARE @foodCount INT = 1;

    -- Kiểm tra món ăn đã tồn tại chưa
    SET @isExistsBillInfo = ISNULL((SELECT ID FROM dbo.CTHOADON WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood), 0)

    IF (@isExistsBillInfo > 0)
    BEGIN
        -- Lấy số lượng hiện có
        SET @foodCount = (SELECT COUNT FROM dbo.CTHOADON WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood);
        
        -- Cập nhật số lượng mới
        UPDATE dbo.CTHOADON 
        SET COUNT = @foodCount + @count 
        WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood;
    END
    ELSE
    BEGIN
        -- Chèn mới nếu chưa có món ăn này trong hóa đơn
        INSERT INTO dbo.CTHOADON (IDHOADON, IDTHUCDON, COUNT)
        VALUES (@idBill, @idFood, @count);
    END
END;
EXEC USP_InsertBillInfo 1, 2, 3;
EXEC USP_InsertBillInfo 1, 4, 3;


ALTER PROCEDURE USP_InsertBillInfo  
    @idBill INT,  
    @idFood INT,  
    @count INT  
AS  
BEGIN  
    SET NOCOUNT ON;  

    -- Kiểm tra nếu bill đã tồn tại, thì chỉ cập nhật số lượng
    IF EXISTS (SELECT 1 FROM dbo.CTHOADON WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood)  
    BEGIN  
        UPDATE dbo.CTHOADON  
        SET COUNT = COUNT + @count  
        WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood;  
    END  
    ELSE  
    BEGIN  
        -- Nếu chưa có thì thêm mới
        INSERT INTO dbo.CTHOADON (IDHOADON, IDTHUCDON, COUNT)  
        VALUES (@idBill, @idFood, @count);  
    END  
END;

DECLARE @newID INT;
SET @newID = (SELECT ISNULL(MAX(ID), 0) + 1 FROM dbo.CTHOADON);

INSERT INTO dbo.CTHOADON (ID, IDHOADON, IDTHUCDON, COUNT)
VALUES (@newID, @idBill, @idFood, @count);
ALTER TABLE dbo.CTHOADON
DROP COLUMN ID;

ALTER TABLE dbo.CTHOADON
ADD ID INT IDENTITY(1,1) PRIMARY KEY;

SELECT name 
FROM sys.key_constraints 
WHERE type = 'PK_CTHOADON' 
AND parent_object_id = OBJECT_ID('dbo.CTHOADON');

ALTER TABLE dbo.CTHOADON DROP CONSTRAINT name_CTHOADON;
SELECT * 
FROM sys.objects 
WHERE parent_object_id = OBJECT_ID('dbo.CTHOADON') 
AND type IN ('PK', 'UQ', 'C', 'F', 'D');

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE TABLE_NAME = 'CTHOADON';

ALTER TABLE dbo.CTHOADON DROP CONSTRAINT PK__CTHOADON__ID;










 SELECT * FROM dbo.CTHOADON WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood


 ALTER PROC USP_InsertBill
 @idTable INT 
 AS
 BEGIN
	INSERT dbo.HOADON
			(NGAYVAO,
			NGAYRA,
			IDBANG,
			STATUS,
			GIAMGIA
			)
	VALUES
	(
		GETDATE(),
		NULL,
		@idTable,
		0,
		0
			)
 END
 GO
 EXEC USP_InsertBill    ;

 -- Thêm cột mới với IDENTITY
ALTER TABLE HOADON ADD new_id INT IDENTITY(1,1);

-- Nếu cần giữ lại giá trị cũ, cập nhật lại dữ liệu
UPDATE HOADON SET new_id = id;

-- Xóa cột cũ (nếu không còn cần thiết)
ALTER TABLE HOADON DROP COLUMN id;

-- Đổi tên cột mới thành id
EXEC sp_rename 'HOADON.new_id', 'id', 'COLUMN';

-- Đặt id làm khóa chính nếu cần
ALTER TABLE HOADON ADD CONSTRAINT PK_HOADON PRIMARY KEY (id);

SELECT name FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('HOADON');
ALTER TABLE OtherTable DROP CONSTRAINT FK_HOADON_OTHER_TABLE;

UPDATE dbo.HOADON set STATUS = 1 WHERE ID = 1
INSERT INTO dbo.CTHOADON (ID, IDHOADON, IDTHUCDON, COUNT)
VALUES (NEWID(), @idBill, @idFood, @count);

--caau truy vaans nhaapj vaof
CREATE PROC USP_InsertBillInfo
@idBill int, @idFood int, @count int
AS
BEGIN
	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	SELECT @isExitsBillInfo = ID, @foodCount = COUNT 
	FROM dbo.CTHOADON 
	WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood
	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		if (@newCount > 0)
		update dbo.CTHOADON set COUNT = @foodCount + @count WHERE IDTHUCDON = @idFood
		ELSE
			DELETE dbo.CTHOADON WHERE IDHOADON = @idBill AND IDTHUCDON = @idFood
	END
	ELSE
	BEGIN
		INSERT dbo.CTHOADON
			(IDHOADON, IDTHUCDON, COUNT)
		VALUES(
			@idBill,
			@idFood,
			@count)
	END
END 
GO
EXEC USP_InsertBillInfo 1,2,3
exec USP_InsertBill 1

-- suwr ly trigger
ALTER TRIGGER UTG_UpdateBillInfo
ON dbo.CTHOADON FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill=IDHOADON FROM inserted

	DECLARE @idTable INT
	SELECT @idTable = IDBANG FROM dbo.HOADON WHERE ID = @idBill AND STATUS = 0

	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.CTHOADON WHERE IDHOADON = @idBill

	IF (@count > 0)
	BEGIN

	PRINT @idTable
		PRINT @idBill
		PRINT @count

		UPDATE dbo.BAN SET STATUS = N'Trống'  WHERE ID = @idTable		
	END
	ELSE
	BEGIN

	PRINT @idTable
		PRINT @idBill
		PRINT @count
	UPDATE dbo.BAN SET STATUS = N'Có người'  WHERE ID = @idTable
	END
	
END
GO

ALTER TRIGGER UTG_UpdateTable
ON dbo.BAN FOR UPDATE
AS
BEGIN
	DECLARE @idTable INT
	DECLARE @startus NVARCHAR(100)

	SELECT @idTable = ID, @startus =inserted.STATUS FROM inserted

	DECLARE @idBill INT
	SELECT @idBill = ID FROM dbo.HOADON WHERE IDBANG =@idTable AND STATUS = 0

	DECLARE @coundBillInfo INT
	SELECT @coundBillInfo = COUNT(*) FROM dbo.CTHOADON WHERE IDHOADON = @idBill

	IF(@coundBillInfo > 0 AND @startus <> N'Có người')
		UPDATE dbo.BAN SET STATUS = N'Có người' WHERE ID = @idTable
	ELSE IF(@coundBillInfo <= 0 AND @startus <> N'Trống')
		UPDATE dbo.BAN SET STATUS = N'Trống' WHERE ID = @idTable


END
GO





--XOA

CREATE TRIGGER UTG_UpdateBill
ON dbo.HOADON FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = ID FROM inserted

	DECLARE @idTable INT

	SELECT @idTable = IDBANG FROM dbo.HOADON WHERE ID = @idBill 

	DECLARE @count int = 0

	SELECT @count = COUNT(*) FROM dbo.HOADON WHERE IDBANG = @idTable AND STATUS = 0

	IF (@count = 0)
		UPDATE dbo.BAN SET STATUS = N'Trống' WHERE ID = @idTable

	END
GO
--XOA
DELETE dbo.CTHOADON
DELETE dbo.HOADON

ALTER TABLE dbo.HOADON
ADD GIAMGIA INT

UPDATE dbo.HOADON SET GIAMGIA = 0
--chuyeenr ban
SELECT * FROM dbo.HOADON



DECLARE @idBillNew int = 36

SELECT ID INTO IDBillInfoTable FROM dbo.CTHOADON WHERE IDHOADON = @idBillNew

DECLARE @idBillOld INT = 20

UPDATE dbo. CTHOADON SET IDHOADON = @idBillOld WHERE ID IN (SELECT * from dbo.IDBillInfoTable)
-- Xoa trigger
ALTER PROC USP_SwitchTabel
@idTable int, @idTable2 int
AS
BEGIN
		DECLARE @idFirtBill INT
		DECLARE @idSeconrBill INT

		DECLARE @idFirstTablEmty INT = 1
		DECLARE @idSeconrTablEmty INT = 1

		SELECT @idSeconrBill = ID FROM dbo. HOADON WHERE IDBANG = @idTable2 AND STATUS = 0
		SELECT @idFirtBill = ID FROM dbo. HOADON WHERE IDBANG = @idTable AND STATUS = 0


		 PRINT @idFirtBill
		 PRINT @idSeconrBill
		 PRINT '------------'

		IF (@idFirtBill IS NULL)
		BEGIN
		PRINT'0000001'
				INSERT dbo.HOADON
			(NGAYVAO,
			NGAYRA,
			IDBANG,
			STATUS)
	VALUES
	   (
		GETDATE(),
		NULL,
		@idTable,
		0)
		SELECT @idFirtBill = MAX(ID) FROM dbo.HOADON WHERE IDBANG = @idTable AND STATUS = 0

		END

		SELECT @idFirstTablEmty = COUNT(*) FROM dbo.CTHOADON WHERE IDHOADON = @idFirtBill

		 PRINT @idFirtBill
		 PRINT @idSeconrBill
		 PRINT '------------'

		IF (@idSeconrBill IS NULL)
		BEGIN
		PRINT'0000002'
				INSERT dbo.HOADON
			(NGAYVAO,
			NGAYRA,
			IDBANG,
			STATUS
			
			)
	VALUES
	   (
		GETDATE(),
		NULL,
		@idTable2,
		0
		)

		SELECT @idSeconrBill = MAX(ID) FROM dbo.HOADON WHERE IDBANG = @idTable2 AND STATUS = 0

		

		END

		SELECT @idSeconrTablEmty = COUNT(*) FROM dbo.CTHOADON WHERE IDHOADON = @idSeconrBill

		 PRINT @idFirtBill
		 PRINT @idSeconrBill
		 PRINT '------------'

		SELECT ID INTO IDBillInfoTable FROM dbo.CTHOADON WHERE IDHOADON = @idSeconrBill

		UPDATE dbo.CTHOADON SET IDHOADON = @idSeconrBill WHERE IDHOADON = @idFirtBill
		UPDATE dbo.CTHOADON SET IDHOADON = @idFirtBill WHERE ID IN (SELECT * FROM IDBillInfoTable)

		DROP TABLE IDBillInfoTable

		IF(@idFirstTablEmty = 0)
			UPDATE dbo.BAN SET STATUS = N'Trống' WHERE ID = @idTable2
		IF(@idSeconrTablEmty = 0)
			UPDATE dbo.BAN SET STATUS = N'Trống' WHERE ID = @idTable
END
GO

exec USP_SwitchTabel
@idTable = 5 , @idTable2 = 6 


ALTER PROC USP_GetListBillByDate
@checkin date, @checkOut date
as
BEGIN
	SELECT t.TEN AS [Tên bàn],b.TONGTIEN AS [Tổng tiền],NGAYVAO AS [Ngày Vào], NGAYRA AS [Ngày Ra], GIAMGIA AS [Giảm giá] FROM dbo.HOADON AS b, dbo.BAN AS t, dbo.CTHOADON AS hd, dbo.THUCDON AS td 
	WHERE NGAYVAO >= @checkin AND NGAYRA <= @checkOut AND b.STATUS = 1
	AND t.ID = b.IDBANG 
END
GO

DELETE dbo.HOADON
DELETE dbo.CTHOADON

ALTER TABLE dbo.HOADON ADD TONGTIEN FLOAT

SELECT * from dbo.THUCDON
 SELECT * FROM dbo.LOAIMON WHERE ID =1

 INSERT dbo.THUCDON (ID,tenmon, idloai, gia) VALUES (N'', 0, 0, 0)

 -- Tạo cột mới với IDENTITY
ALTER TABLE DBO.BAN ADD ID_NEW INT IDENTITY(1,1);

-- Sao chép dữ liệu từ cột cũ sang cột mới
UPDATE LOAIMON SET ID_NEW = ID;

-- Xóa cột cũ
ALTER TABLE LOAIMON DROP COLUMN ID;

-- Đổi tên cột mới thành ID
EXEC sp_rename 'LOAIMON.ID_NEW', 'ID', 'COLUMN';

SELECT name, is_identity 
FROM sys.columns 
WHERE object_id = OBJECT_ID('dbo.LOAIMON');



EXEC sp_fkeys @pktable_name = 'HOADON';
ALTER TABLE BAN DROP CONSTRAINT PK__BAN__3214EC270AD2A005;
ALTER TABLE HOADON DROP CONSTRAINT FK_HOADON_BAN
SELECT name
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('CTHOADON');
INSERT INTO THUCDON(tenmon,idloai,gia ) VALUES (1, 2, 3);

UPDATE dbo.THUCDON SET tenmon = N'', idloai = 4, gia = 0 WHERE  ID= 4

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.CTHOADON FOR Delete
AS
BEGIN
	DECLARE @idBillInfo INT
	Declare @idBill INT
	SELECT @idBillInfo = ID, @idBill = deleted.IDHOADON FROM deleted

	Declare @idTable INT
	SELECT @idTable = IDBANG FROM  dbo.HOADON WHERE ID = @idBill

	DECLARE @count INT = 0

	SELECT @count = COUNT(*) FROM dbo.CTHOADON AS bi, dbo.HOADON WHERE IDHOADON = @idBill AND HOADON.ID = @idBillInfo

	IF (@count = 0)
		UPDATE dbo.BAN SET STATUS = N'Trống' WHERE ID = @idTable

END
GO
SELECT * FROM dbo.TAIKHOAN WHERE TEN =N''


ALTER TABLE dbo. TAIKHOAN

ADD CONSTRAINT DF_TAIKHAON_PASSWORD DEFAULT '0' FOR PASSWORD;




SELECT * FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = 'tri1111'
SELECT TEN , TENTAIKHOAN , TYPE FROM dbo.TAIKHOAN

SELECT * FROM dbo.BAN WHERE ID = 1
SELECT * FROM dbo.HOADON
INSERT dbo.LOAIMON (tenloai) VALUES ('đô chiên')
DELETE dbo.BAN 

-- Chèn dữ liệu vào bảng BAN trước
INSERT INTO dbo.BAN (ID, TEN, STATUS) VALUES ( N'Bàn 1', N'Trống')

-- Sau đó mới chèn dữ liệu vào bảng HOADON
INSERT INTO dbo.HOADON 
(NGAYVAO,NGAYRA,IDBANG,STATUS,GIAMGIA,TONGTIEN) 
VALUES ( GETDATE(),null, 1, 1, 0, 120000)
SELECT * FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = 'tri1111' 
SELECT * FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = 'tri1111'

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRighPass INT = 0

	SELECT @isRighPass = COUNT(*) FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = @userName AND PASSWORD = @password

	IF (@isRighPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword ='')
		BEGIN
			UPDATE dbo.TAIKHOAN SET TEN = @displayname WHERE TENTAIKHOAN = @userName
		END
		ELSE
			UPDATE dbo.TAIKHOAN SET TEN = @displayname, PASSWORD = @newPassword WHERE TENTAIKHOAN = @userName
	END

END
GO

EXEC USP_UpdateAccount tri1111 , NguyễnMinhTrí , tri1111 , 1

SELECT @isRighPass = COUNT(*) FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = @userName AND PASSWORD = @password
PRINT @isRighPass