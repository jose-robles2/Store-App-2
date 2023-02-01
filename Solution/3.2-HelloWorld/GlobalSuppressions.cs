// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

// add justification, also add to your readme.
[assembly: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:Closing brace should be followed by blank line", Justification = "<Sometimes creating a new line after an ending brace is redundant such as when we have an if statement that returns false, then right after the brace I can do return true. Since the code is related, it can be redundant to add the newLine.>", Scope = "member", Target = "~M:HelloWorld.Date.IsLeap(System.Double)~System.Boolean")]
