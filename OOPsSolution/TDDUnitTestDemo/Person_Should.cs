using OOPsReview;
using FluentAssertions;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        //Attribute title
        //  Fact: one test, test body contains all setup, execution and assert
        //  Theory: allows for multiple executions of the same test using different data input

        #region Valid Data Testing
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
            Person sut = new Person("Don", "Welch", address, null);

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
        [Fact]
        public void Return_the_Number_of_Employments()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data
            ResidentAddress address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");
            List<Employment> employments = Create_List_of_Employments();
            Person sut = new Person("Don", "Welch", address, employments);
            int expectednumberofemployments = employments.Count();

            //Act (the execution of your test)
            // sut : subject under test
            int numberofemployments = sut.NumberOfEmployments;

            //Assert (testing of the results of the Act)
            numberofemployments.Should().Be(expectednumberofemployments);

        }
        [Fact]
        public void Allow_Change_to_First_Name()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data

            Person sut = Create_Test_Person();
            string expectedfirstname = "Lowan";

            //Act (the execution of your test)
            // sut : subject under test
            sut.FirstName = expectedfirstname;

            //Assert (testing of the results of the Act)
            sut.FirstName.Should().Be(expectedfirstname);

        }
        [Fact]
        public void Allow_Change_to_Last_Name()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data

            Person sut = Create_Test_Person();
            string expectedlastname = "Behold";

            //Act (the execution of your test)
            // sut : subject under test
            sut.LastName = expectedlastname;

            //Assert (testing of the results of the Act)
            sut.LastName.Should().Be(expectedlastname);

        }
        [Fact]
        public void Allow_Change_to_Both_First_and_Last_Name()
        {
            //Arrange (setup)
            //prepare for the test: setting expected results, creating/declaring test data

            Person sut = Create_Test_Person();
            string expectedlastname = "Oying";
            string expectedfirstname = "Anne";
            string expectedfullname = $"{expectedlastname}, {expectedfirstname}";
            //string expectedfullname = expectedlastname + ", " + expectedfirstname;

            //Act (the execution of your test)
            // sut : subject under test
            sut.ChangeName(expectedfirstname, expectedlastname);

            //Assert (testing of the results of the Act)
            sut.FullName.Should().Be(expectedfullname);

        }
        [Fact]
        public void Add_a_New_Employment_to_HIstory()
        {
            //Arrange
            ResidentAddress address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");
            Employment employment1 = new Employment("Beginner Programmer", SupervisoryLevel.Entry, DateTime.Parse("Apr 20, 2019"), 2.5);
            Employment employment2 = new Employment("Programmer", SupervisoryLevel.TeamMember, DateTime.Parse("Oct 2, 2021"));
            Employment employment3 = new Employment("Lead", SupervisoryLevel.TeamLeader, DateTime.Parse("Sep 21, 2023"), 0);
            List<Employment> setupemployments = new List<Employment>()
            { employment1, employment2 };
            Person person = new Person("Don", "welch", address, setupemployments);

            //expected history of the list<Employment>
            //because the entire object structure including the GUID is checked
            //  the expected list of instance must be IDENTICAL in all aspected including the GUID
            //use the instance that your already used in your setup and your expected added instance
            List<Employment> expectedemployments = new List<Employment>()
            { employment1, employment2, employment3};



            //Act
            person.AddEmployment(employment3);

            //Assert
            person.NumberOfEmployments.Should().Be(3);

            //check the added instance is the actual instance that was passed
            person.EmploymentPositions[2].Should().BeSameAs(employment3);

            //check the contents of the entire collection to be identical to another collection
            person.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedemployments);

        }
        #endregion


        #region Invalid Data Testing
        [Theory]
        [InlineData(null, "Welch")]
        [InlineData("", "Welch")]
        [InlineData("   ", "Welch")]
        [InlineData("Don", null)]
        [InlineData("Don", "")]
        [InlineData("Don", "   ")]
        public void Throw_Exception_Creating_a_New_Person_with_Bad_Name_Using_Greedy_Constructor(string firstname, string lastname)
        {
            //Arrange
            ResidentAddress address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");

            //Act
            //capture the result of the act
            //not testing the data but the expected action of an exception being thrown
            Action action = () => new Person(firstname, lastname, address, null);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null, "Welch")]
        [InlineData("", "Welch")]
        [InlineData("   ", "Welch")]
        [InlineData("Don", null)]
        [InlineData("Don", "")]
        [InlineData("Don", "   ")]
        public void Throw_Exception_When_Changing_Name_with_Bad_Data(string firstname, string lastname)
        {
            //Arrange
            Person sut = Create_Test_Person();
            //Act
            //capture the result of the act
            //not testing the data but the expected action of an exception being thrown
            Action action = () => sut.ChangeName(firstname, lastname);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]

        public void Throw_Exception_When_Changing_FirstName_with_Bad_Data(string firstname)
        {
            //Arrange
            Person sut = Create_Test_Person();
            //Act
            //capture the result of the act
            //not testing the data but the expected action of an exception being thrown
            Action action = () => sut.FirstName = firstname;

            //Assert
            action.Should().Throw<ArgumentNullException>();

            //optionally you could check the contents of the error message
            action.Should().Throw<ArgumentNullException>().WithMessage("*must be supplied*");
        }

        #endregion


        #region Support Methods
        public List<Employment> Create_List_of_Employments()
        {
             List<Employment> employments = new List<Employment>();
            employments.Add(new Employment("Beginner Programmer", SupervisoryLevel.Entry, DateTime.Parse("Apr 20, 2019"), 2.5));
            employments.Add(new Employment("Programmer", SupervisoryLevel.TeamMember, DateTime.Parse("Oct 2, 2021")));

            return employments;
        }

        public Person Create_Test_Person()
        {
            ResidentAddress address = new ResidentAddress(123, "Maple St", "Edmonton", "AB", "T6Y7U8");
            List<Employment> employments = Create_List_of_Employments();
            return new Person("Don", "Welch", address, employments);
        }
        #endregion
    }
}