﻿using System;
using System.Linq;
using System.Net;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.MSBuild;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace HearthDb.EnumsGenerator
{
	internal class Program
	{
		private const string File = "../../../HearthDb/Enums/Enums.cs";
		static void Main()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			string enums;
			using(var wc = new WebClient())
				enums = wc.DownloadString("https://api.hearthstonejson.com/v1/enums.cs?" + DateTime.Now.Ticks);
			var header = ParseLeadingTrivia(@"/* THIS FILE WAS GENERATED BY HearthDb.EnumsGenerator. DO NOT EDIT. */" + Environment.NewLine + Environment.NewLine);
			var members = ParseCompilationUnit(enums).Members;
			var first = members.First().WithLeadingTrivia(header);
			var @namespace = NamespaceDeclaration(IdentifierName("HearthDb.Enums")).AddMembers(new [] {first}.Concat(members.Skip(1)).ToArray());
			var root = Formatter.Format(@namespace, MSBuildWorkspace.Create());
			using(var sr = new StreamWriter(File))
				sr.Write(root.ToString());
		}
	}
}
