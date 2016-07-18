using System;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    internal class DataServiceTests
    {
        private DataService _ds; 

        [SetUp]
        public void TestSetup()
        {
            _ds = new DataService(5);
            _ds.AddItem(2);
            _ds.AddItem(8);
            _ds.AddItem(0);
            _ds.AddItem(11);
        }

        [TearDown]
        public void TestTearDown()
        {
            _ds.ClearAll();
        }

        [Test]
        public void RemoveAt_When_Index_In_range_Than_delete_and_When_Indexoutofrange_Then_exception()
        {
            //Act and Assert
            Assert.That(_ds.GetElementAt(3), Is.Not.Null);
            _ds.RemoveAt(1);
            Assert.Throws<ArgumentOutOfRangeException>(()=>_ds.GetElementAt(3));
        }
    }
}
