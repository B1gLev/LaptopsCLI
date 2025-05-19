using LaptopsCLI;

var laptops = new List<Laptop>();

using var sr = new StreamReader(@"../../../src/laptops.txt");
sr.ReadLine();
while(!sr.EndOfStream) laptops.Add(new(sr.ReadLine()));

Console.WriteLine("5. feladat - Kiírás");
laptops.Select((k, i) => new { Index = i + 1, Key = k }).ToList()
    .ForEach(x => Console.WriteLine($"{x.Index}. {x.Key} | {x.Key.Price * 4.12:00} HUF"));

Console.WriteLine("\n6. feladat - Keresés");
var intelCoreSeven = laptops.Where(x => x.CPU.Contains("Intel Core i7") && x.Storage.Contains("SSD")).Select((k, i) => new { Index = i + 1, Key = k }).ToList();
intelCoreSeven.ForEach(x => Console.WriteLine($"[{x.Index}] {x.Key}"));
Console.WriteLine($"A laptopok átlag ára: {intelCoreSeven.Average(x => x.Key.Price)} INR");

Console.WriteLine("\n7. feladat - Faájlba írás");
using var sw = new StreamWriter(@"../../../src/cheap.txt");
laptops.Where(x => x.Category.CategoryName.Equals("Gaming")).OrderBy(x => x.Price).ToList().Take(20)
    .ToList().ForEach(x => sw.WriteLine($"{x.Manufacturer.ManufacturerName} {x.Model}" +
    $"\n\t{x.CPU}" +
    $"\n\t{x.Storage}" +
    $"\n\t{x.Screen}"));