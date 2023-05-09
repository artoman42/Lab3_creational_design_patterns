using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using BLL;
using DAL;

namespace UIL
{
    public class Runner : IRunner
    {
        private readonly UILConfiguration _configuration;
        private readonly IEntrantsInput _input;
        private readonly IOutput _output;
        private string path;

        public Runner(IOptions<UILConfiguration> config, IEntrantsInput input, IOutput output)
        {
            _configuration = config.Value;
            _input = input;
            path = _configuration.DefaultFolder;
            _output = output;
        }
        public void Run() {
            ExportFactory exportFactory = new ExportFactory();
            ImporterFactory importerFactory = new ImporterFactory();
            while (true)
            {
                Console.WriteLine("1 - Entry and saving./n 2 - Loading");
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter Amount of entrants :");
                            int Amount;
                            while (!int.TryParse(Console.ReadLine(), out Amount))
                            {
                                Console.WriteLine("Invalid input. Please enter an integer.");
                            }
                            var list = _input.Input(Amount);
                            Console.WriteLine("Enter format to save \".txt\", \".xml\", \".json\"");
                            string extension = Console.ReadLine();
                            IExporter exporter = exportFactory.Create(extension);
                            Console.WriteLine("Enter file name : ");
                            string fileName = Console.ReadLine();
                            exporter.Export(list, path + fileName + extension);
                            break;
                        case "2":
                            Console.WriteLine("Write file name with extension to Load");
                            fileName = Console.ReadLine();
                            IImporter importer = importerFactory.Create(Path.GetExtension(fileName));
                            _output.WriteToConsole(importer.Import(path + fileName));
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}
