<Query Kind="Expression">
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

//Aggregrates
//Aggregrates can ONLY be used against a collection
//Count (number of),Min,Max,Average,Sum (the total of)
//Min, Max, Average and Sum NEED an expression in the method
//determine the size of a collection

//what is the number of products in the seafood category?

Products
	//.Where(prd => prd.Category.CategoryName.Contains("Seafood"))
	.Count(prd => prd.Category.CategoryName.Contains("Seafood"))


Products
	.Where(prd => prd.Category.CategoryName.Contains("Seafood"))
	.Max(prd => prd.UnitPrice)