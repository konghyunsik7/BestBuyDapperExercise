using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BestBuyDapperExercise;
//^^^^MUST HAVE USING DIRECTIVES^^^^


var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);


var dapperDepartmentRepository1 = new DapperDepartmentRepository(conn);
Console.WriteLine("Here is the list of the departments");


var depts = dapperDepartmentRepository1.GetAllDepartments();

foreach (var item in depts)
{
    Console.WriteLine($"Department ID:{item.DepartmentId} & Department Name: {item.Name}");
    Console.WriteLine();
    Console.WriteLine();
    
}

Console.WriteLine("Do you want to insert another department? yes/no");
var userInput = Console.ReadLine();

if (userInput.ToLower() == "yes")
{
    Console.WriteLine("What is the name of the department?");
    userInput = Console.ReadLine();
    dapperDepartmentRepository1.InsertDepartments(userInput);
    foreach (var item in depts)
    {
        Console.WriteLine($"Department ID:{item.DepartmentId} & Department Name: {item.Name}");
    }
}

// EXERCISE 2 

// Create a DapperProductRepository Class that conforms to the IProductRepository interface *************************

DapperProductRepository repoProd = new DapperProductRepository(conn);

Console.WriteLine("Hello user, please provide a new product's name:");
var userInputProduct = Console.ReadLine();
Console.WriteLine("Hello user, please provide this new product's price:");
double userInputPrice = double.Parse(Console.ReadLine());
Console.WriteLine("Hello user, please provide this new product's category ID:");
int userInputCategoryID = int.Parse(Console.ReadLine());

repoProd.CreateProduct(userInputProduct, userInputPrice, userInputCategoryID);

var products = repoProd.GetAllProducts();
foreach (var item in products)
{
    Console.WriteLine($"Product ID: {item.ProductID} Name: {item.Name} Price: {item.Price}");
    Console.WriteLine();
}

//Bonus - Create the UpdateProduct method in the DapperProductRepository class and implement in Program.cs**************************


Console.WriteLine("Hello user, please provide a product ID to update: ");
int userInputProductID = int.Parse(Console.ReadLine());
Console.WriteLine("Hello user, please provide an updated product's price:");
double userInputProductPrice = double.Parse(Console.ReadLine());

repoProd.UpdateProduct(userInputProductID, userInputProductPrice);

// Extra Bonus - Create the DeleteProduct method. HINT: You will need to delete records from the Sales table and the Reviews table where that Product may be referenced. You can do this all in the DeleteProduct method you are creating.******************

Console.WriteLine("Hello user, please provide a product ID to delete: ");
int userInputDeleteProductID = int.Parse(Console.ReadLine());

repoProd.DeleteProduct(userInputDeleteProductID);