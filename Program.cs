using System;
using DesignPatterns.CreationalBuilder;
using DesignPatterns.CodeBuilder;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(Environment.NewLine);
            Demo demoBuilder = new Demo();
            demoBuilder.RunDemoBuilder();
            Console.WriteLine(Environment.NewLine);
            // var cb = new Variable("Name", "string");
            // Console.WriteLine(cb.ToStringIntend(0));
            var cb = new CodeBuilderRunner();
            cb.runner();

        }
    }
}
