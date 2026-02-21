using System;
using System.Globalization;
using System.Threading.Tasks;
using NorthwindSurfer.Data;
using NorthwindSurfer.Service;

namespace NorthwindSurfer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Optional: decimal parse uchun (nuqta/vergul muammosi bo'lmasin)
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            var db = new DbContext();

            var categoryService = new CategoryService(db);
            var customerService = new CustomerService(db);
            var orderService = new OrderService(db);
            var productService = new ProductService(db);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== NorthwindSurfer Console ===");
                Console.WriteLine("1) Categories");
                Console.WriteLine("2) Customers");
                Console.WriteLine("3) Orders");
                Console.WriteLine("4) Products");
                Console.WriteLine("0) Exit");
                Console.Write("Tanlang: ");

                var mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        await CategoriesMenu(categoryService);
                        break;

                    case "2":
                        await CustomersMenu(customerService);
                        break;

                    case "3":
                        await OrdersMenu(orderService);
                        break;

                    case "4":
                        await ProductsMenu(productService);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Noto'g'ri tanlov!");
                        Pause();
                        break;
                }
            }
        }

        // -------------------- CATEGORIES --------------------
        static async Task CategoriesMenu(CategoryService categoryService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Categories Menu ===");
                Console.WriteLine("1) Create");
                Console.WriteLine("2) List all");
                Console.WriteLine("3) Get by id");
                Console.WriteLine("4) Update");
                Console.WriteLine("5) Delete");
                Console.WriteLine("0) Back");
                Console.Write("Tanlang: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("CategoryName: ");
                            var name = Console.ReadLine() ?? "";

                            Console.Write("Description: ");
                            var desc = Console.ReadLine() ?? "";

                            await categoryService.CreateCategoryAsync(name, desc);
                            Console.WriteLine("✅ Created!");
                            Pause();
                            break;
                        }

                    case "2":
                        {
                            var list = await categoryService.GetAllCategoriesAsync();
                            Console.WriteLine($"Count: {list.Count}");
                            foreach (var c in list)
                            {
                                Console.WriteLine($"{c.CategoryID} | {c.CategoryName} | {c.Description}");
                            }
                            Pause();
                            break;
                        }

                    case "3":
                        {
                            int id = ReadInt("CategoryID: ");
                            var c = await categoryService.GetCategoryByIdAsync(id);
                            if (c == null) Console.WriteLine("❌ Not found");
                            else Console.WriteLine($"{c.CategoryID} | {c.CategoryName} | {c.Description}");
                            Pause();
                            break;
                        }

                    case "4":
                        {
                            int id = ReadInt("CategoryID: ");
                            Console.Write("CategoryName: ");
                            var name = Console.ReadLine() ?? "";

                            Console.Write("Description: ");
                            var desc = Console.ReadLine() ?? "";

                            await categoryService.UpdateCategoryAsync(id, name, desc);
                            Console.WriteLine("✅ Updated!");
                            Pause();
                            break;
                        }

                    case "5":
                        {
                            int id = ReadInt("CategoryID: ");
                            await categoryService.DeleteCategoryAsync(id);
                            Console.WriteLine("✅ Deleted!");
                            Pause();
                            break;
                        }

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Noto'g'ri tanlov!");
                        Pause();
                        break;
                }
            }
        }

        // -------------------- CUSTOMERS --------------------
        static async Task CustomersMenu(CustomerService customerService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Customers Menu ===");
                Console.WriteLine("1) Create");
                Console.WriteLine("2) List all");
                Console.WriteLine("3) Get by id");
                Console.WriteLine("4) Update");
                Console.WriteLine("5) Delete");
                Console.WriteLine("0) Back");
                Console.Write("Tanlang: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("CompanyName: "); var company = Console.ReadLine() ?? "";
                            Console.Write("ContactName: "); var contact = Console.ReadLine() ?? "";
                            Console.Write("ContactTitle: "); var title = Console.ReadLine() ?? "";
                            Console.Write("Address: "); var address = Console.ReadLine() ?? "";
                            Console.Write("City: "); var city = Console.ReadLine() ?? "";
                            Console.Write("Region: "); var region = Console.ReadLine() ?? "";
                            Console.Write("PostalCode: "); var postal = Console.ReadLine() ?? "";
                            Console.Write("Country: "); var country = Console.ReadLine() ?? "";
                            Console.Write("Phone: "); var phone = Console.ReadLine() ?? "";
                            Console.Write("Fax: "); var fax = Console.ReadLine() ?? "";

                            await customerService.CreateCustomerAsync(company, contact, title, address, city, region, postal, country, phone, fax);
                            Console.WriteLine("✅ Created!");
                            Pause();
                            break;
                        }

                    case "2":
                        {
                            var list = await customerService.GetAllCustomersAsync();
                            Console.WriteLine($"Count: {list.Count}");
                            foreach (var c in list)
                            {
                                Console.WriteLine($"{c.CustomerID} | {c.CompanyName} | {c.ContactName} | {c.Phone}");
                            }
                            Pause();
                            break;
                        }

                    case "3":
                        {
                            Console.Write("CustomerID (string): ");
                            var id = Console.ReadLine() ?? "";
                            var c = await customerService.GetCustomerByIdAsync(id);
                            if (c == null) Console.WriteLine("❌ Not found");
                            else Console.WriteLine($"{c.CustomerID} | {c.CompanyName} | {c.ContactName} | {c.Phone}");
                            Pause();
                            break;
                        }

                    case "4":
                        {
                            Console.Write("CustomerID (string): "); var id = Console.ReadLine() ?? "";
                            Console.Write("CompanyName: "); var company = Console.ReadLine() ?? "";
                            Console.Write("ContactName: "); var contact = Console.ReadLine() ?? "";
                            Console.Write("ContactTitle: "); var title = Console.ReadLine() ?? "";
                            Console.Write("Address: "); var address = Console.ReadLine() ?? "";
                            Console.Write("City: "); var city = Console.ReadLine() ?? "";
                            Console.Write("Region: "); var region = Console.ReadLine() ?? "";
                            Console.Write("PostalCode: "); var postal = Console.ReadLine() ?? "";
                            Console.Write("Country: "); var country = Console.ReadLine() ?? "";
                            Console.Write("Phone: "); var phone = Console.ReadLine() ?? "";
                            Console.Write("Fax: "); var fax = Console.ReadLine() ?? "";

                            await customerService.UpdateCustomerAsync(id, company, contact, title, address, city, region, postal, country, phone, fax);
                            Console.WriteLine("✅ Updated!");
                            Pause();
                            break;
                        }

                    case "5":
                        {
                            Console.Write("CustomerID (string): ");
                            var id = Console.ReadLine() ?? "";
                            await customerService.DeleteCustomerAsync(id);
                            Console.WriteLine("✅ Deleted!");
                            Pause();
                            break;
                        }

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Noto'g'ri tanlov!");
                        Pause();
                        break;
                }
            }
        }

        // -------------------- ORDERS --------------------
        static async Task OrdersMenu(OrderService orderService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Orders Menu ===");
                Console.WriteLine("1) Create");
                Console.WriteLine("2) List all (with Customer join)");
                Console.WriteLine("3) Get by id (with Customer join)");
                Console.WriteLine("4) Update");
                Console.WriteLine("5) Delete");
                Console.WriteLine("0) Back");
                Console.Write("Tanlang: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            int customerId = ReadInt("CustomerID (int): ");
                            int employeeId = ReadInt("EmployeeID (int): ");

                            DateTime? orderDate = ReadNullableDate("OrderDate (yyyy-MM-dd or empty): ");
                            DateTime? requiredDate = ReadNullableDate("RequiredDate (yyyy-MM-dd or empty): ");
                            DateTime? shippedDate = ReadNullableDate("ShippedDate (yyyy-MM-dd or empty): ");

                            int shipVia = ReadInt("ShipVia (int): ");
                            decimal freight = ReadDecimal("Freight (decimal): ");

                            Console.Write("ShipName: "); var shipName = Console.ReadLine() ?? "";
                            Console.Write("ShipAddress: "); var shipAddress = Console.ReadLine() ?? "";
                            Console.Write("ShipCity: "); var shipCity = Console.ReadLine() ?? "";
                            Console.Write("ShipRegion: "); var shipRegion = Console.ReadLine() ?? "";
                            Console.Write("ShipPostalCode: "); var shipPostal = Console.ReadLine() ?? "";
                            Console.Write("ShipCountry: "); var shipCountry = Console.ReadLine() ?? "";

                            await orderService.CreateOrderAsync(customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight,
                                shipName, shipAddress, shipCity, shipRegion, shipPostal, shipCountry);

                            Console.WriteLine("✅ Created!");
                            Pause();
                            break;
                        }

                    case "2":
                        {
                            var list = await orderService.GetAllOrdersAsync();
                            Console.WriteLine($"Count: {list.Count}");
                            foreach (var o in list)
                            {
                                var customerName = o.Customer?.CompanyName ?? "N/A";
                                Console.WriteLine($"{o.OrderID} | Customer: {customerName} | OrderDate: {o.OrderDate}");
                            }
                            Pause();
                            break;
                        }

                    case "3":
                        {
                            int id = ReadInt("OrderID: ");
                            var o = await orderService.GetOrderByIdAsync(id);
                            if (o == null) Console.WriteLine("❌ Not found");
                            else
                            {
                                var customerName = o.Customer?.CompanyName ?? "N/A";
                                Console.WriteLine($"{o.OrderID} | Customer: {customerName} | OrderDate: {o.OrderDate}");
                            }
                            Pause();
                            break;
                        }

                    case "4":
                        {
                            int orderId = ReadInt("OrderID: ");
                            int customerId = ReadInt("CustomerID (int): ");
                            int employeeId = ReadInt("EmployeeID (int): ");

                            DateTime? orderDate = ReadNullableDate("OrderDate (yyyy-MM-dd or empty): ");
                            DateTime? requiredDate = ReadNullableDate("RequiredDate (yyyy-MM-dd or empty): ");
                            DateTime? shippedDate = ReadNullableDate("ShippedDate (yyyy-MM-dd or empty): ");

                            int shipVia = ReadInt("ShipVia (int): ");
                            decimal freight = ReadDecimal("Freight (decimal): ");

                            Console.Write("ShipName: "); var shipName = Console.ReadLine() ?? "";
                            Console.Write("ShipAddress: "); var shipAddress = Console.ReadLine() ?? "";
                            Console.Write("ShipCity: "); var shipCity = Console.ReadLine() ?? "";
                            Console.Write("ShipRegion: "); var shipRegion = Console.ReadLine() ?? "";
                            Console.Write("ShipPostalCode: "); var shipPostal = Console.ReadLine() ?? "";
                            Console.Write("ShipCountry: "); var shipCountry = Console.ReadLine() ?? "";

                            await orderService.UpdateOrderAsync(orderId, customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight,
                                shipName, shipAddress, shipCity, shipRegion, shipPostal, shipCountry);

                            Console.WriteLine("✅ Updated!");
                            Pause();
                            break;
                        }

                    case "5":
                        {
                            int id = ReadInt("OrderID: ");
                            await orderService.DeleteOrderAsync(id);
                            Console.WriteLine("✅ Deleted!");
                            Pause();
                            break;
                        }

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Noto'g'ri tanlov!");
                        Pause();
                        break;
                }
            }
        }

        // -------------------- PRODUCTS --------------------
        static async Task ProductsMenu(ProductService productService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Products Menu ===");
                Console.WriteLine("1) Create");
                Console.WriteLine("2) List all (with Category join)");
                Console.WriteLine("3) Get by id (with Category join)");
                Console.WriteLine("4) Update");
                Console.WriteLine("5) Delete");
                Console.WriteLine("0) Back");
                Console.Write("Tanlang: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("ProductName: "); var name = Console.ReadLine() ?? "";
                            int supplierId = ReadInt("SupplierID (int): ");
                            int categoryId = ReadInt("CategoryID (int): ");
                            Console.Write("QuantityPerUnit: "); var qpu = Console.ReadLine() ?? "";

                            decimal unitPrice = ReadDecimal("UnitPrice (decimal): ");
                            short unitsInStock = ReadShort("UnitsInStock (short): ");
                            short unitsOnOrder = ReadShort("UnitsOnOrder (short): ");
                            short reorderLevel = ReadShort("ReorderLevel (short): ");
                            bool discontinued = ReadBool("Discontinued (true/false): ");

                            await productService.CreateProductAsync(name, supplierId, categoryId, qpu, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
                            Console.WriteLine("✅ Created!");
                            Pause();
                            break;
                        }

                    case "2":
                        {
                            var list = await productService.GetAllProductsAsync();
                            Console.WriteLine($"Count: {list.Count}");
                            foreach (var p in list)
                            {
                                var cat = p.Category?.CategoryName ?? "N/A";
                                Console.WriteLine($"{p.ProductId} | {p.ProductName} | Category: {cat} | Price: {p.UnitPrice}");
                            }
                            Pause();
                            break;
                        }

                    case "3":
                        {
                            int id = ReadInt("ProductID: ");
                            var p = await productService.GetProductByIdAsync(id);
                            if (p == null) Console.WriteLine("❌ Not found");
                            else
                            {
                                var cat = p.Category?.CategoryName ?? "N/A";
                                Console.WriteLine($"{p.ProductId} | {p.ProductName} | Category: {cat} | Price: {p.UnitPrice}");
                            }
                            Pause();
                            break;
                        }

                    case "4":
                        {
                            int productId = ReadInt("ProductID: ");
                            Console.Write("ProductName: "); var name = Console.ReadLine() ?? "";
                            int supplierId = ReadInt("SupplierID (int): ");
                            int categoryId = ReadInt("CategoryID (int): ");
                            Console.Write("QuantityPerUnit: "); var qpu = Console.ReadLine() ?? "";

                            decimal unitPrice = ReadDecimal("UnitPrice (decimal): ");
                            short unitsInStock = ReadShort("UnitsInStock (short): ");
                            short unitsOnOrder = ReadShort("UnitsOnOrder (short): ");
                            short reorderLevel = ReadShort("ReorderLevel (short): ");
                            bool discontinued = ReadBool("Discontinued (true/false): ");

                            await productService.UpdateProductAsync(productId, name, supplierId, categoryId, qpu, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
                            Console.WriteLine("✅ Updated!");
                            Pause();
                            break;
                        }

                    case "5":
                        {
                            int id = ReadInt("ProductID: ");
                            await productService.DeleteProductAsync(id);
                            Console.WriteLine("✅ Deleted!");
                            Pause();
                            break;
                        }

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Noto'g'ri tanlov!");
                        Pause();
                        break;
                }
            }
        }

        // -------------------- HELPERS --------------------
        static void Pause()
        {
            Console.WriteLine("\nDavom etish uchun Enter bosing...");
            Console.ReadLine();
        }

        static int ReadInt(string label)
        {
            while (true)
            {
                Console.Write(label);
                var s = Console.ReadLine();
                if (int.TryParse(s, out var v)) return v;
                Console.WriteLine("❌ int bo'lishi kerak!");
            }
        }

        static short ReadShort(string label)
        {
            while (true)
            {
                Console.Write(label);
                var s = Console.ReadLine();
                if (short.TryParse(s, out var v)) return v;
                Console.WriteLine("❌ short bo'lishi kerak!");
            }
        }

        static decimal ReadDecimal(string label)
        {
            while (true)
            {
                Console.Write(label);
                var s = Console.ReadLine();
                if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v)) return v;
                Console.WriteLine("❌ decimal bo'lishi kerak! (Masalan: 12.5)");
            }
        }

        static bool ReadBool(string label)
        {
            while (true)
            {
                Console.Write(label);
                var s = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                if (s == "true" || s == "1" || s == "yes" || s == "ha") return true;
                if (s == "false" || s == "0" || s == "no" || s == "yoq" || s == "yo'q") return false;
                Console.WriteLine("❌ true/false kiriting (masalan: true yoki false)");
            }
        }

        static DateTime? ReadNullableDate(string label)
        {
            while (true)
            {
                Console.Write(label);
                var s = (Console.ReadLine() ?? "").Trim();
                if (string.IsNullOrEmpty(s)) return null;

                if (DateTime.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                    return dt;

                Console.WriteLine("❌ Sana formati yyyy-MM-dd bo'lsin. Masalan: 2026-02-21");
            }
        }
    }
}