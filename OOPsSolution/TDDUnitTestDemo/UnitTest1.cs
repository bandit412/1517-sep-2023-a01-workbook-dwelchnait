using OOPsReview;
using FluentAssertions;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        //Attribute title
        //  Fact: one test, test body contains all setup, execution and assert
        //  Theory: allows for multiple executions of the same test using different data input

        [Fact]
        public void Create_an_Instance_Using_the_Default_Constructor()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data
            string expectedFristName = "unknown";
            string expectedLastName = "unknown";

            //Act (the execution of your test)
            // sut : subject under test
            Person sut = new Person();

            //Assert (testing of the results of the Act)
            sut.FirstName.Should().Be(expectedFristName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }
    }
}