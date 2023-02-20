USE KinetEcoTRG;
GO

CREATE TABLE dbo.ProductCategories (
    CategoryID int IDENTITY PRIMARY KEY,
    CategoryName nvarchar(20),
    CreationDate datetime2,
    LastModifiedDate datetime2
);
GO


-- Trigger to fill CreationDate on row inserts:
CREATE OR ALTER TRIGGER dbo.tr_ProductCategoriesInsert
ON dbo.ProductCategories
AFTER INSERT
AS
BEGIN
	UPDATE dbo.ProductCategories
	SET CreationDate = GETDATE()
	FROM Inserted
	WHERE dbo.ProductCategories.CategoryID = Inserted.CategoryID;
END;
GO

-- Trigger to fill LastModifiedDate on row updates:
CREATE OR ALTER TRIGGER dbo.tr_ProductCategoriesUpdate
ON dbo.ProductCategories
AFTER UPDATE
AS
BEGIN
	UPDATE dbo.ProductCategories
	SET LastModifiedDate = GETDATE()
	FROM Inserted
	WHERE dbo.ProductCategories.CategoryID = Inserted.CategoryID;
END;
GO

-- Trigger to prevent row deletes:
CREATE OR ALTER TRIGGER tr_ProductCategoriesDelete
ON dbo.ProductCategories
INSTEAD OF DELETE
AS
BEGIN
	PRINT 'Delete operations are not allowed for the ProductCategories database table.'
	PRINT 'To delete a record, delete the trigger first.'
	ROLLBACK;
END;
GO

/* TEST SOLUTION */
SELECT * FROM dbo.ProductCategories;
GO

INSERT INTO dbo.ProductCategories (CategoryName)
VALUES
    ('Solar Panel'), ('Battery'), ('Wind Harvester')
;

UPDATE dbo.ProductCategories
SET CategoryName = 'Wind Turbine'
WHERE CategoryID = 3
;

DELETE FROM dbo.ProductCategories
WHERE CategoryID = 2;

SELECT * FROM dbo.ProductCategories;

/* REMOVE ProductCategories TABLE WHEN COMPLETE */
DROP TABLE dbo.ProductCategories;
GO