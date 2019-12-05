using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace razor_engine_learn
{
    class Program
    {
        static void Main(string[] args)
        {
            // var template = @"hogehoge @Model.Name...";
            // var model = new { Name = "hehehehe" };
            // var result = Engine.Razor.RunCompile(template, "templatekey", null, model);

            // Console.WriteLine(result);

            // Console.ReadKey();

            Execute2();
        }

        private static void Execute()
        {
            var config = new TemplateServiceConfiguration();
            config.Language = Language.CSharp;
            config.EncodedStringFactory = new RawStringFactory();

            var service = RazorEngineService.Create(config);
            Engine.Razor = service;

            var model = new { Name = "hehehehe" };

            var per = new Person { Name = "hehe" };

            var templateFile = @"../templates/test.cshtml";

            var template = new LoadedTemplateSource(File.ReadAllText(templateFile), templateFile);

            var result = Engine.Razor.RunCompile(template, "key", typeof(Person), per);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static void Execute2()
        {
            var config = new TemplateServiceConfiguration();
            config.Language = Language.CSharp;
            config.EncodedStringFactory = new RawStringFactory();

            var service = RazorEngineService.Create(config);
            Engine.Razor = service;

            var model = new { Name = "hehehehe", Age = 2, IsAge = true };

            var templateFile = @"../templates/template2.txt";

            var template = new LoadedTemplateSource(File.ReadAllText(templateFile), templateFile);

            var result = Engine.Razor.RunCompile(template, "key", null, model);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
