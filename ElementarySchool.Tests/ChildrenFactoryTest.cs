using System.Linq;
using ElementarySchool.Entities;
using Xunit;
using Xunit.Abstractions;

namespace ElementarySchool.Tests
{
    public class ChildrenFactoryTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly ChildrenFactory _factory = new();

        public ChildrenFactoryTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void RandomManyTest()
        {
            var count = _factory.RandomMany(19).Count();
            Assert.Equal(19, count);
        }
        
        [Fact]
        public void RandomTest()
        {
            var child = _factory.Random();
            var secondChild = _factory.Random();
            Assert.NotNull(child);
            Assert.IsType<Child>(child);
            Assert.NotSame(child, secondChild);
            Assert.InRange(child.Age, 5, 15);
        }
        
        [Fact]
        public void RandomMaleTest()
        {
            var male = _factory.RandomMale();
            _testOutputHelper.WriteLine(male.ToString());
            Assert.NotNull(male);
            Assert.True(male.Sex);
            Assert.False(!male.Sex);
        }
        
        [Fact]
        public void RandomFemaleTest()
        {
            var female = _factory.RandomFemale();
            _testOutputHelper.WriteLine(female.ToString());
            Assert.NotNull(female);
            Assert.False(female.Sex);
            Assert.True(!female.Sex);
        }
    }
}