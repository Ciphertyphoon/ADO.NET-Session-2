Create procedure spGetProductInventoryById
@ProductId int
as
Begin
 Select Id, ProductName, UnitPrice 
 from tblProductInventory
 where Id = @ProductId
End