using System.Reflection;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyDescription("An ASI plugin for Grand Theft Auto V, which allows running scripts written in any .NET language in-game.")]
[assembly: AssemblyCopyright("Copyright © 2015 crosire")]
[assembly: AssemblyTitle("Community Script Hook V .NET")]
[assembly: SecurityRules(SecurityRuleSet.Level1)]
[assembly: AssemblyVersion("3.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
