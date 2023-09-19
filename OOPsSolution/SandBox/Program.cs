// See https://aka.ms/new-console-template for more information

using OOPsReview;

Console.WriteLine("Hello, World!");

//demonstration of using a Record datatype

//create an instance
ResidentAddress myHome = new ResidentAddress(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome);
Console.WriteLine(myHome.ToString());
Console.WriteLine($"City is {myHome.City}");

//an example of Refactoring
//Refactor means to reduce and clean your code
bool flag = false;
if(myHome.Province.ToLower() == "ab")
{
    flag = true;
}
if (myHome.Province.ToLower() == "bc")
{
    flag = true;
}
if (myHome.Province.ToLower() == "sk")
{
    flag = true;
}
if (myHome.Province.ToLower() == "mn")
{
    flag = true;
}

//refactor to cleaner structure
switch (myHome.Province.ToLower())
{
    case "ab":
    case "bc":
    case "sk":
    case "mn":
        {
            flag= true;
            break;
        }
    default:
        {
            flag = false;
            break;
        }
}

//refactor to compound if
if (myHome.Province.ToLower() == "ab" ||
    myHome.Province.ToLower() == "bc" ||
    myHome.Province.ToLower() == "sk" ||
    myHome.Province.ToLower() == "mn")
{
    flag = true;
}