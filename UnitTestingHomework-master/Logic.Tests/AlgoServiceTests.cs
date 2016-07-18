using System;
using System.Collections.Generic;
using NUnit.Framework;
using FakeItEasy;

namespace Logic.Tests
{
    [TestFixture]
    internal class AlgoServiceTests
    {
        private AlgoService _as;

        [SetUp]
        public void TestSetup()
        {
            _as = new AlgoService();
        }

        [Test]
        public void Sqr_When_given_arg_verify_correct_result()
        {
            //Arrange
            var fake = A.Fake<IAlgoService>();
            A.CallTo(() => fake.Sqr(10)).Returns(100);

            //Act
            var result = fake.Sqr(10);

            //Assert
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void Sqr_When_given_arg_Then_return_correct_result()
        {
            //Act
            var result = _as.Sqr(12);

            //Assert
            Assert.That(result, Is.EqualTo(144));
        }

        [Test]
        public void Function_When_given_arg_b_below_zero_Then_throws_exception()
        {
            //Act and Assure
            Assert.Throws<ArgumentException>(() => _as.Function(2, -5, 1, 4));
        }

        [Test]
        public void Prop_MethodsCalledCount_When_methods_called_two_times_Then_prop_value_equals_two()
        {
            //Arrange
            List<int> list = new List<int>(3) { 1, 2, 3 };

            //Act
            _as.MinValue(list);
            _as.GetAverage(list);

            //Assure
            Assert.AreEqual(2, _as.MethodsCalledCount);
        }
    }
}
