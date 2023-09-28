<Query Kind="Statements">
  <Connection>
    <ID>9b0f865a-0b16-4877-abe4-c69087d4fadf</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>WestWind</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Finding something in a collection

//Any does not return an actual record set, instead it returns a true or false
if(Territories
.Any(r => r.TerritoryDescription.Equals("Redmond") ))
{
	Console.WriteLine("yeah Redmond exists");
}

var foundit = Territories
				.Where(r => r.TerritoryDescription.Contains("ed"));
				
//to display results in LinqPad, use the LinqPad method .Dump()
foundit.Dump();

//find the first seafood item that exceeds 5.00
//display the first seafood item that exceeds 5.00

//FirstOrDefault() 
//looks for the first instance in a collection that matches
//	the given criteria and returns that criteria
//if no match for the given criteria exists a null value is returned

var seafooditem = Products
				.Where(prd => prd.UnitPrice > 55.00m &&
						prd.Category.CategoryName.Equals("Seafood"))
				.FirstOrDefault();
seafooditem.Dump();