using System;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;

namespace Logic.Tests
{
    [TestFixture]
    internal class MasterServiceTests
    {
        private AlgoService _as;
        private DataService _ds;
        private MasterService _ms;

        [SetUp]
        public void TestSetup()
        {
            _as = new AlgoService();
            _ds = new DataService(0);
            _ms = new MasterService(_as, _ds);
            
        }

        [Test]
        public void Ctor_When_Instances_given_Is_AlgoService_and_Is_DataService_Then_OK()
        {
            //Act and Assert
            Assert.IsInstanceOf<AlgoService>(_ms.GetAlgoService);
            Assert.IsInstanceOf<DataService>(_ms.GetDataService);
        }

        [Test]
        public void GetDoubleSum_When_given_null_data_Then_throw_exception()
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => _ms.GetDoubleSum());
        }

        [Test]
        public void GetAverage_When_given_null_data_Then_throw_exception()
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => _ms.GetAverage());
        }

        [Test]
        public void GetDoubleSum_When_given_few_elements_Then_verify_result()
        {
            //Arrange
            var fakeObj = A.Fake<IAlgoService>();
            var ds = new DataService(2);
            ds.AddItem(5);
            ds.AddItem(2);

            A.CallTo(() => fakeObj.DoubleSum(ds.GetAllData())).Returns(14);
            var ms = new MasterService(fakeObj, ds);

            //Act
            var result = ms.GetDoubleSum();

            //Assert
            Assert.AreEqual(14, result);
        }

        [Test]
        public void GetMinValuesFromLists_When_given_empty_data_Then_throw_exception()
        {
            //Arrange
            var lst = new List<List<int>>(2);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => _ms.GetMinValuesFromLists(lst));
        }

        [Test]
        public void GetMinValuesFromLists_When_given_collection_size_more_than_4_Then_throw_exception()
        {
            //Arrange
            var lst = new List<List<int>>(5)
            {
                new List<int>(3) { 1,2,3},
                new List<int>(3) { 1,2,3},
                new List<int>(3) { 1,2,3},
                new List<int>(3) { 1,2,3},
                new List<int>(3) { 1,2,3}
            };

            //Act and Assert
            Assert.Throws<ArgumentException>(() => _ms.GetMinValuesFromLists(lst));
        }
    }
}
