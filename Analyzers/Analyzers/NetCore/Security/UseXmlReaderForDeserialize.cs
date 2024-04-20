// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Analyzer.Utilities;
using Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Microsoft.NetCore.Analyzers.Security
{
    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    public sealed class UseXmlReaderForDeserialize : UseXmlReaderBase
    {
        internal const string DiagnosticId = "DN5369";

        internal static readonly DiagnosticDescriptor RealRule = DiagnosticDescriptorHelper.Create(
            DiagnosticId,
            Messages.UseXmlReaderForDeserialize,
            Message,
            DiagnosticCategory.Security,
            RuleLevel.IdeHidden_BulkConfigurable,
            description: Description,
            isPortedFxCopRule: false,
            isDataflowRule: false);

        protected override string TypeMetadataName => WellKnownTypeNames.SystemXmlSerializationXmlSerializer;

        protected override string MethodMetadataName => "Deserialize";

        protected override DiagnosticDescriptor Rule => RealRule;
    }
}
