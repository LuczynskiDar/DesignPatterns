using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CodeBuilder
{

    public class Variable
    {
        private string NameVariable, TypeVariable;
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
            sb.Append($"{currentIntend}public class {NameVariable}\n{{");

            if (!string.IsNullOrWhiteSpace(TypeVariable))
            {
                sb.Append(new string(' ', codeIntend * (intend + 1)));
                sb.Append(TypeVariable);
                sb.Append("\n");
            }
            
            
            variableList.ForEach(v => sb.Append(v.ToStringIntend(intend+1)));
            sb.Append( "\n"+ @"}");
            return sb.ToString();
        }
        public override string ToString()
        {
             return ToStringIntend(0);
        }

        

    }
    public class CodeBuilder
    {
        private readonly string rootName;
        Variable root = new Variable();

        public CodeBuilder(string rootName)
        {
            this.rootName = rootName;
        }

        public CodeBuilder AddVariable(string nameVariable, string typeVariable)
        {
            var v = new Variable(nameVariable, typeVariable);
            root.variableList.Add(v);
            return this;
        }
        

        public override string ToString()
        {
            return root.ToString();
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

