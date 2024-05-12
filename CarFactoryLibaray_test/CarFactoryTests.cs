using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibaray_test
{
    public class CarFactoryTests
    {
        [Fact]
        public void NewCar_CarTypeAudi_null()
        {
            // Arrange

            // Act
            Car? car = CarFactory.NewCar(CarTypes.Audi);

            // Reference Asserts
            Assert.Null(car);
        }
        [Fact]
        public void NewCar_CarTypeBMW_BMW()
        {
            // Arrange

            // Act
            Car? car = CarFactory.NewCar(CarTypes.BMW);

            // Reference Asserts
            Assert.NotNull(car);

            // Type Asserts
            Assert.IsType<BMW>(car);
            Assert.IsNotType<Toyota>(car);

            Assert.IsAssignableFrom<Car>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
            Assert.IsAssignableFrom<Car>(new Toyota());
        }

        [Fact]
        public void NewCar_CarTypeHonda_Exception()
        {
            // Arrange

            

            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }
            
    }
}
