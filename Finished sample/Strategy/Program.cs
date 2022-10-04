using Strategy;

var order = new Order("Marvin Software", 5, "Visual Studio License");
order.Export(new CsvExportService());
order.Export(new JsonExportService());