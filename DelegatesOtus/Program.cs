﻿// See https://aka.ms/new-console-template for more information

using DelegatesOtus;
using DelegatesOtus.Extensions;
using DelegatesOtus.FileSearch;
using Microsoft.Extensions.Configuration;

Console.WriteLine($"GetMax function testing.");
var items = new List<string> { "apple","smart-contract", "banana", "cherry", "date", "eggplant" };
var maxItem = items.GetMax(item => item.Length);

Console.WriteLine("List of words: ");
var combined = string.Join(", ", items);
Console.WriteLine(combined);
Console.WriteLine($"Max item by length: {maxItem}");
Console.WriteLine($"________________________");
maxItem = items.GetMax(item => item.Last());
Console.WriteLine("List of words: ");
combined = string.Join(", ", items);
Console.WriteLine(combined);
Console.WriteLine($"Max item by last symbol: {maxItem}");
Console.WriteLine($"________________________");

var builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();
string? searchDirectory = config["SearchDirectory"];
string? cancelFile = config["CancelFile"];

var logger = new ConsoleLogger();
var searcher = new FileSearcher(logger);
var handler = new FileEventHandler(searcher,logger, cancelFile);
if (searchDirectory != null)
{
    searcher.SearchFiles(searchDirectory);
}
