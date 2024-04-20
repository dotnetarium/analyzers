// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Analyzer.Utilities.FlowAnalysis.Analysis.TaintedDataAnalysis;
using Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.NetCore.Analyzers.Security.Helpers;

namespace Microsoft.NetCore.Analyzers.Security
{
    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    public class DoNotHardCodeCertificate : SourceTriggeredTaintedDataAnalyzerBase
    {
        internal static readonly DiagnosticDescriptor Rule = SecurityHelpers.CreateDiagnosticDescriptor(
            "DN5403",
            Messages.DoNotHardCodeCertificate,
            Messages.DoNotHardCodeCertificateMessage,
            RuleLevel.Disabled,
            isPortedFxCopRule: false,
            isDataflowRule: true,
            isReportedAtCompilationEnd: false,
            descriptionResourceStringName: Messages.DoNotHardCodeCertificateDescription);

        protected override SinkKind SinkKind => SinkKind.HardcodedCertificate;

        protected override DiagnosticDescriptor TaintedDataEnteringSinkDescriptor => Rule;
    }
}
