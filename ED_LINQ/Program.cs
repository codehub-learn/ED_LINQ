using ED_LINQ;
using System.Linq;

List<string> productslist = new List<string>() 
{ 
    "Laptop", "Mouse", "Keyboard", "Lamp" 
};

var firstlowercaseproduct = productslist
    .Where(pn => pn.StartsWith('L'))
    .Select(pn => pn.ToLower())
    .First();

Customer annaKarenina = new() { ID = 1, FirstName = "Anna", LastName = "Karenina", RegistrationDate = DateTime.Today };

List<Customer> customerslist = new List<Customer>()
{
    new() {ID= 1, FirstName = "Anna", LastName="Karenina", RegistrationDate = DateTime.Today},
    new() {ID= 2, FirstName = "John", LastName="Smith", RegistrationDate = DateTime.Today}
};

Dictionary<int, Customer> customersdict = new();
customersdict.Add(1, new Customer() { ID = 1, FirstName = "Anna", LastName = "Karenina", RegistrationDate = DateTime.Today });
customersdict.Add(2, new Customer() { ID = 2, FirstName = "John", LastName = "Smith", RegistrationDate = DateTime.Today });

var customersfromdict = customersdict.Where(c => c.Key == 1);
var customersfromdict2 = customersdict.Where(c => c.Value.FirstName == "Anna");


var productsfroml = productslist.Where(p => p.StartsWith('L'));
var prouctsfromlq = from p in productslist
                    where p.StartsWith('L')
                    select p;


var customerswithid1 = customerslist.Where(c => c.ID == 1);
var annakreninacustomers = customerslist.Where(c => c.FirstName == "Anna" && c.LastName == "Karenina");

Product id2 = Product.Products.Where(p => p.Id == 2).First(); 
Product id2s = Product.Products.Where(p => p.Id == 2).Single();

Product black = Product.Products.Where(p => p.Color == "Black").First(); //OK returns first black
//Product blacksingle = Product.Products.Where(p => p.Color == "Black").Single(); //Exception

//Product ghost = Product.Products.Where(p => p.Color == "NA").First(); //Exception
//Product ghostsingle = Product.Products.Where(p => p.Color == "NA").Single(); //Exception

Product? id2ornull = Product.Products.Where(p => p.Id == 2).FirstOrDefault();
Product? id2ornulllast = Product.Products.Where(p => p.Id == 2).LastOrDefault();
Product? id2srnull = Product.Products.Where(p => p.Id == 2).SingleOrDefault();

Product? id2ornullshort = Product.Products.SingleOrDefault(p => p.Id == 2); //Shorthand version

if (id2srnull == null)
{
    Console.WriteLine("product is null");
}

var productnames = Product.Products.Select(p => p.Name);

var orderedproducts = Product.Products
    .Where(p => p.Cost >= 500)
    .OrderBy(p => p.Name)
    .ThenBy(p => p.Color)
    .ThenBy(p => p.Price);

var orderedproductsdesc = Product.Products
    .Where(p => p.Cost >= 500)
    .OrderByDescending(p => p.Name) //First Descedning Order by Name Z-A
    .ThenByDescending(p => p.Color) //If same name then by color z-a
    .ThenBy(p => p.Price) //If same name and color order by price ascending (smallest to largest)
    .ToList();

var orderedproductsdesc2 = Product.Products
    .Where(p => p.Cost >= 500)
    .OrderByDescending(p => p.Name) //First Descedning Order by Name Z-A
    .ThenByDescending(p => p.Color) //If same name then by color z-a
    .ThenBy(p => p.Price) //If same name and color order by price ascending (smallest to largest)
    .ToDictionary(p => p.Id, p => p);

foreach (Product p in orderedproducts)
{
    Console.WriteLine(p.Name);
}

List<char> chars = new() { 'a', 'b', 'c' };
var CharsQuery = chars.Select(ch => ch); //Useless

chars.Remove('b');
foreach (char ch in CharsQuery)
{
    Console.WriteLine(ch); //a c
}


Console.WriteLine();