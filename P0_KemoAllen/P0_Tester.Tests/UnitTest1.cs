using System;
using Xunit;
using P0_KemoAllen;
using Microsoft.EntityFrameworkCore;

namespace P0_Tester.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckUserName()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Customer testCust = new Customer();
            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //StoreRepositoryLayer repo = new StoreRepositoryLayer(context);
                testCust.UserName = "jr";

                context.Add(testCust);
                context.SaveChanges();
            }

            //Assert
            using(var context = new Store_DbContext(options))
            {
                Assert.Equal("jr", testCust.UserName);
            }
        }//UserName

        [Fact]
        public void CheckAddOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Order testOrder = new Order();
            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();  
                
                context.Add(testOrder);
                context.SaveChanges();
            }
            //Arrange
            using(var context = new Store_DbContext(options))
            {
                Assert.NotNull(testOrder.timeCreated);
            }
        }

        [Fact]
        public void CheckAddInventory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Inventory testInventory = new Inventory();
            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();  
                
                context.Add(testInventory);
                context.SaveChanges();
            }
            //Arrange
            using(var context = new Store_DbContext(options))
            {
                Assert.Equal(100, testInventory.inventoryQuantity);
            }
        }

        [Fact]
        public void CheckAddLocation()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Location testLoc = new Location();
            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //StoreRepositoryLayer repo = new StoreRepositoryLayer(context);
                testLoc.LocationName = "Kroger";

                context.Add(testLoc);
                context.SaveChanges();
            }

            //Assert
            using(var context = new Store_DbContext(options))
            {
                Assert.Equal("Kroger", testLoc.LocationName);
            }
        }

        [Fact]
        public void CheckAddProduct()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Product testProd = new Product();
            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //StoreRepositoryLayer repo = new StoreRepositoryLayer(context);
                testProd.UnitPrice = 4.50m;

                context.Add(testProd);
                context.SaveChanges();
            }

            //Assert
            using(var context = new Store_DbContext(options))
            {
                Assert.Equal(4.50m, testProd.UnitPrice);
            }
        }
        [Fact]
        public void CheckInventoryProductReference()
        {
           //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Product testProd = new Product();
            Inventory testInv = new Inventory();
            String prodName = "Device";

            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //StoreRepositoryLayer repo = new StoreRepositoryLayer(context);
                testProd.Description = prodName;
                testInv.inventoryProduct = testProd;

                context.SaveChanges();
            }

            //Assert
            using(var context = new Store_DbContext(options))
            {
                Assert.Equal(prodName, testInv.inventoryProduct.Description);
            } 
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void TestInvalidQuantity(int value)
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Product testProd = new Product();
            Inventory testInv = new Inventory();
            String prodName = "Corn";
            bool canCheckout;

            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreRepositoryLayer repo = new StoreRepositoryLayer(context);
                testProd.Description = prodName;
                testInv.inventoryProduct = testProd;

                canCheckout = repo.CheckIfQuantityAvailable(testInv, value);

                context.SaveChanges();
            }

            //Assert
            using(var context = new Store_DbContext(options))
            {
                Assert.False(canCheckout);
            } 
        }

        [Fact]
        public void TestTakeFromInventory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Product testProd = new Product();
            Inventory testInv = new Inventory();
            Order testOrder = new Order();
            String prodName = "Device";
            int num = 9;

            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreRepositoryLayer repo = new StoreRepositoryLayer(context);
                testProd.Description = prodName;
                testInv.inventoryProduct = testProd;

                repo.TakeFromInventoryAddToOrder(testInv, num, testOrder);

                context.SaveChanges();
            }

            //Assert
            using(var context = new Store_DbContext(options))
            {
                Assert.Equal(num, testOrder.orderQuantity);
            }
        }

        [Fact]
        public void CheckOrderLocationReference()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Store_DbContext>()
            .UseInMemoryDatabase(databaseName: "TestStore")
            .Options;

            Order testOrder = new Order();
            Location testLoc = new Location();
            
            String locName = "Testville";

            //Act
            using(var context = new Store_DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //StoreRepositoryLayer repo = new StoreRepositoryLayer(context);
                testLoc.LocationName = locName;
                testOrder.orderLocation = testLoc;

                context.SaveChanges();
            }

            //Assert
            using(var context = new Store_DbContext(options))
            {
                Assert.Equal(locName, testOrder.orderLocation.LocationName);
            }
        }

    }
}
