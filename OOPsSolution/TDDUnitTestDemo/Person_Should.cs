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

        [Fact]
        public void Create_an_Instance_Using_the_Greedy_Constructor_with_No_Employments()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data
            string expectedFristName = "Don";
            string expectedLastName = "Welch";
            ResidentAddress address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = address.ToString();

            //Act (the execution of your test)
            // sut : subject under test
            Person sut = new Person("Don","Welch",address,null);

            //Assert (testing of the results of the Act)
            sut.FirstName.Should().Be(expectedFristName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.ToString().Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }
        [Fact]
        public void Create_an_Instance_Using_the_Greedy_Constructor_with_Employments()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data
            string expectedFristName = "Don";
            string expectedLastName = "Welch";
            ResidentAddress address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = address.ToString();
            List<Employment> employments = Create_List_of_Employments();
            int expectedEmploymentCount = employments.Count();

            //Act (the execution of your test)
            // sut : subject under test
            Person sut = new Person("Don", "Welch", address, employments);

            //Assert (testing of the results of the Act)
            sut.FirstName.Should().Be(expectedFristName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.ToString().Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentCount);
        }
        [Fact]
        public void Return_the_Full_Name()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data
            string expectedFullName = "Welch, Don";
            ResidentAddress address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");
            List<Employment> employments = Create_List_of_Employments();
            Person sut = new Person("Don", "Welch", address, employments);

            //Act (the execution of your test)
            // sut : subject under test
            string fullname = sut.FullName;

            //Assert (testing of the results of the Act)
            fullname.Should().Be(expectedFullName);
          
        }


        #region Support Methods
        public List<Employment> Create_List_of_Employments()
        {
             List<Employment> employments = new List<Employment>();
            employments.Add(new Employment("Beginner Programmer", SupervisoryLevel.TeamMember, DateTime.Parse("Apr 20, 2019"), 2.5));
            employments.Add(new Employment("Beginner Programmer", SupervisoryLevel.TeamLeader, DateTime.Parse("Oct 2, 2021")));

            return employments;
        }
        #endregion
    }
}