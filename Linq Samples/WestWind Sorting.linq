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

//Sorting

//4 method of interest
//OrderBy the first sort in a query doing an ascending sort
//OrderByDescending the first sort in a query doing a descending sort
//ThenBy any other sort besides the 1st sort of a query doing an ascending sort
//ThenByDescending any other sort besides the 1st sort of a query doing a descending sort

//each method refers to a single attribute (field)
//can mix and match ascendings and descendings


Products
	.OrderBy(prd => prd.Category.CategoryName) //an ascending order by, the first field of ordering
	.ThenBy(prd => prd.ProductName) //ascending order by after the 1st sort


Products
	//.Where(prd => prd.Category.CategoryName.Contains("Seafood") || 
	//				prd.Category.CategoryName.Contains("Meat"))
	.OrderByDescending(prd => prd.Category.CategoryName) //an descending order by, the first field of ordering
	.ThenBy(prd => prd.ProductName) //ascending order by after the 1st sort
	.Where(prd => prd.Category.CategoryName.Contains("Seafood") ||
					prd.Category.CategoryName.Contains("Meat"))