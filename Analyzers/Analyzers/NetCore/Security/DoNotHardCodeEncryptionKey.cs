// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Analyzer.Utilities.FlowAnalysis.Analysis.TaintedDataAnalysis;
using Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.NetCore.Analyzers.Security.Helpers;

namespace Microsoft.NetCore.Analyzers.Security
{
    using static MicrosoftNetCoreAnalyzersResources;

    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    public class DoNotHardCodeEncryptionKey : SourceTriggeredTaintedDataAnalyzerBase
    {
        internal static readonly DiagnosticDescriptor Rule = SecurityHelpers.CreateDiagnosticDescriptor(
            "DN5390",
            Messages.DoNotHardCodeEncryptionKey,
            Messages.DoNotHardCodeEncryptionKeyMessage,
            RuleLevel.Disabled,
            isPortedFxCopRule: false,
            isDataflowRule: true,
            isReportedAtCompilationEnd: false,
            descriptionResourceStringName: Messages.DoNotHardCodeEncryptionKeyDescription);

        protected override SinkKind SinkKind => SinkKind.HardcodedEncryptionKey;

        protected override DiagnosticDescriptor TaintedDataEnteringSinkDescriptor => Rule;
    }
}
