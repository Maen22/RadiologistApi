using System;
using System.Collections.Generic;
using Xunit;

namespace RadApiTests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2,2));
        }

        [Fact]
        public void FailingTest()  
        {
            Assert.Equal(4, Add(2, 2));
        }

        private int Add(int v1, int v2)
        {
            return v1 + v2;
        }
    }
}
