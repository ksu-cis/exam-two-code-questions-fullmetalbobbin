using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }


        [Fact]
        public void CobblerClassShouldImplementINotifyPropertyChangedInterface()
        {
            var cobble = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobble);
        }


        [Fact]
        public void SpecifyingFruitFillingPropertyForCobblerShouldInvokePropertyChanged()
        {
            var fruityCobble = new Cobbler();

            Assert.PropertyChanged(fruityCobble, "Fruit", () => {
                fruityCobble.Fruit = FruitFilling.Peach;
            });

            Assert.PropertyChanged(fruityCobble, "Fruit", () => {
                fruityCobble.Fruit = FruitFilling.Cherry;
            });

            Assert.PropertyChanged(fruityCobble, "Fruit", () => {
                fruityCobble.Fruit = FruitFilling.Blueberry;
            });

        }


        [Fact]
        public void ChangingIceCreamPropertyShouldInvokePropertyChangedAndSpecialInstructions()
        {
            var coldCobble = new Cobbler();

            Assert.PropertyChanged(coldCobble, "WithIceCream", () => {
                coldCobble.WithIceCream = false;
            });

            var coldCobbleInstruct = new Cobbler();

            Assert.PropertyChanged(coldCobbleInstruct, "WithIceCream", () => {
                coldCobbleInstruct.WithIceCream = false;
            });

        }

    }
}
