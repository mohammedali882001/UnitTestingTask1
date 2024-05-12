using CarFactoryLibrary;
using Xunit;

namespace CarFactoryLibrary2
{
    public class BMWTest
    {
        [Fact]
        public void When_EqualVelocityAndMode_Then_ReturnsTrue()
        {
            // Arrange
            BMW bmw1 = new BMW {
                velocity = 0,
                drivingMode = DrivingMode.Forward
            };
            BMW bmw2 = new BMW {
                velocity = 0,
                drivingMode = DrivingMode.Forward
            };

            // Act
            bool result = bmw1.Equals(bmw2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void When_VelocityInRange_Then_TimeToCoverDistanceInRange()
        {
            // Arrange
            BMW bmw = new BMW {
                velocity = 10
            };

            // Act
            double time = bmw.TimeToCoverDistance(100);

            // Assert
            Assert.InRange(time, 5, 15);
        }

        [Fact]
        public void When_VelocityOutOfRange_Then_TimeToCoverDistanceOutOfRange()
        {
            // Arrange
            var bmw = new BMW 
            {
                velocity = 10
            };

            // Act
            double time = bmw.TimeToCoverDistance(100);

            // Assert
            Assert.NotInRange(time, 5, 6);
        }

        [Fact]
        public void When_DirectionIsBackward_Then_ReturnsBackwardString()
        {
            // Arrange
            BMW bmw = new BMW
            {
                drivingMode = DrivingMode.Backward
            };

            // Act
            string direction = bmw.GetDirection();

            // Assert
            Assert.Equal(DrivingMode.Backward.ToString(), direction);
            Assert.EndsWith("rd", direction);
            Assert.Contains("wa", direction);
            Assert.DoesNotContain("mm", direction);
        }

        [Fact]
        public void When_DirectionIsStopped_Then_ReturnsStoppedString()
        {
            // Arrange
            BMW bmw = new BMW 
            { 
                drivingMode = DrivingMode.Stopped 
            };

            // Act
            string direction = bmw.GetDirection();

            // Assert
            Assert.StartsWith("S", direction);
            Assert.Matches("^S.*", direction);
        }

        [Fact]
        public void When_GetMyCarCalled_Then_ReturnsNotNull()
        {
            // Arrange
            BMW bmw = new BMW();

            // Act
            Car car = bmw.GetMyCar();

            // Assert
            Assert.NotNull(car);
        }

        [Fact]
        public void When_GetMyCarCalledTwice_Then_ReturnsDifferentCars()
        {
            // Arrange
            BMW bmw1 = new BMW();
            BMW bmw2 = new BMW();

            // Act
            Car car1 = bmw1.GetMyCar();
            Car car2 = bmw2.GetMyCar();

            // Assert
            Assert.NotSame(car1, car2);
        }

        [Fact]
        public void When_NewCarTypeIsBMW_Then_ReturnsBMWType()
        {
            // Act
            Car car = CarFactory.NewCar(CarTypes.BMW);

            // Assert
            Assert.IsType<BMW>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
        }

        [Fact]
        public void When_NewCarTypeIsHonda_Then_ThrowsNotImplementedException()
        {
            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car result = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
