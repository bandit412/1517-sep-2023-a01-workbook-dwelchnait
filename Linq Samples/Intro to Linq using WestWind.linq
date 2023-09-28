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

//Queries can be written in two style

//Query Syntax
from anyrow in Shippers
select anyrow

//Method Syntatx
Shippers
   .Select(anyrow => anyrow.CompanyName)
   
   
//Filtering
//you use the where clause (query syntax) or the .Where() method
//the conditions are setup as you would in C#
//beware that linqpad may NOT like some C# syntax (DateTime)
//beware that Linq is converted to sql which may not
//	like certain C# syntax because sql cannot convert

//note that the method syntax makes use of the Lambda expression
//Lambdas are common when performing Linq withy the method syntax
//.Where(lambda expression)
//.Where( x => condition [logical operator condition2 ...])
//.Where( x => x.FreightCharge >= 20.00)

//Method Syntax
Shipments
	.Where( x => x.FreightCharge >= 300.00m)
	.Select(x => x)
	
//query syntax
from x in Shipments
where x.FreightCharge >= 300.00m
select x

Shipments
	.Where(x => x.ShipViaShipper.CompanyName.Contains("Ship"))