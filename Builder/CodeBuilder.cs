using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CodeBuilder
{

    public class Variable
    {
        public string NameVariable, TypeVariable;
        private int codeIntend = 2;
        public List<Variable> variableList = new List<Variable>();
        public Variable()
        {
            
        }
        public Variable(string nameVariable, string typeVariable)
        {
            this.NameVariable = nameVariable;
            this.TypeVariable = typeVariable;
        }

        public string ToStringIntend(int intend)
        {
            var sb = new StringBuilder();
            var currentIntend =  new string(' ', codeIntend * intend);
            if(string.IsNullOrWhiteSpace(TypeVariable))
            {
                sb.Append($"{currentIntend}public class {NameVariable}\n{{\n");
            } 
            else 
            {
                sb.Append(new string(' ', codeIntend * (intend + 1))
                        +$"public {TypeVariable} {NameVariable};\n" );
            }           
            variableList.ForEach(v => sb.Append(v.ToStringIntend(intend+1)));
            return sb.ToString();
        }
        public override string ToString()
        {
             return ToStringIntend(0) + @"}"+ "\n";
        }

        
    }
    public class CodeBuilder
    {
        private readonly string nameVariable;
        Variable root = new Variable();

        public CodeBuilder(string rootName)
        {

            this.nameVariable = rootName;
            root.NameVariable = rootName;
        }

        public CodeBuilder AddVariable(string nameVariable, string typeVariable)
        {
            var v = new Variable(nameVariable, typeVariable);
            root.variableList.Add(v);
            return this;
        }
        

        
        public void Clear()
        {
            // root = new Variable{NameVariable = rootName};
        }


        public override string ToString()
        {
            return root.ToString();
        }
        
    }

    public class CodeBuilderRunner
    {
        public void runner()
        {
            // ordinary non-fluent builder
            var builder = new CodeBuilder("Person");
            builder.AddVariable("Name","string").AddVariable("Age","int");
            Console.WriteLine("Fluent invoke my builder");
            Console.WriteLine(builder.ToString());
        }
    }
}


// Desired output

// public class Person
// {
//     public string Name;
//     public string Age;
// }

// invoked by
// var cb = new CodeBuilder("Person").AddField("Name","string").AddField("Age","int");
// Console.WriteLine(cb);

