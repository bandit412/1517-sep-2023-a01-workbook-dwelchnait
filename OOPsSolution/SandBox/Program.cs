// See https://aka.ms/new-console-template for more information

using OOPsReview;

Console.WriteLine("Hello, World!");

//demonstration of using a Record datatype

//create an instance
Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome);
Console.WriteLine(myHome.ToString());
Console.WriteLine($"City is {myHome.City}");

