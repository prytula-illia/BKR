using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using DTOs;

namespace BLL.Services
{
    public class DotNetCompilerService : IDotNetCompilerService
    {
        public CodeDto Compile(CodeDto code)
        {
            string codeToCompile = @"
                namespace DotNetTraining
                {
                    " + code.CodeToCompile + @"
                }";

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(codeToCompile);

            string assemblyName = Path.GetRandomFileName();
            var refPaths = new[] {
                typeof(object).GetTypeInfo().Assembly.Location,
                typeof(Console).GetTypeInfo().Assembly.Location,
                Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), "System.Runtime.dll")
            };
            MetadataReference[] references = refPaths.Select(r => MetadataReference.CreateFromFile(r)).ToArray();

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    var res = "Compilation failed!";
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        res += $"\t{diagnostic.Id}: {diagnostic.GetMessage()}";
                    }

                    return new CodeDto
                    {
                        CodeToCompile = res
                    };
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    var sw = new StringWriter();
                    Console.SetOut(sw);
                    Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
                    var type = assembly.GetType("DotNetTraining.Program");
                    var instance = assembly.CreateInstance("DotNetTraining.Program");
                    var meth = type.GetMember("Main").First() as MethodInfo;
                    meth.Invoke(instance, Array.Empty<object>());


                    return new CodeDto
                    {
                        CodeToCompile = sw.GetStringBuilder().ToString()
                    };
                }
            }
        }
    }
}
