// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Analyzer.Utilities;
using Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.NetCore.Analyzers.Security.Helpers;

namespace Microsoft.NetCore.Analyzers.Security
{
    /// <summary>
    /// For detecting deserialization with <see cref="T:System.Runtime.Serialization.Formatters.Binary.NetDataContractSerializer"/> when its Binder property is not set.
    /// </summary>
    [SuppressMessage("Documentation", "CA1200:Avoid using cref tags with a prefix", Justification = "The comment references a type that is not referenced by this compilation.")]
    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    public class DoNotUseInsecureDeserializerNetDataContractSerializerWithoutBinder : DoNotUseInsecureDeserializerWithoutBinderBase
    {
        internal static readonly DiagnosticDescriptor RealBinderDefinitelyNotSetDescriptor =
            SecurityHelpers.CreateDiagnosticDescriptor(
                "DN2311",
                Messages.NetDataContractSerializerDeserializeWithoutBinderSetTitle,
                Messages.NetDataContractSerializerDeserializeWithoutBinderSetMessage,
                RuleLevel.Disabled,
                isPortedFxCopRule: false,
                isDataflowRule: true,
                isReportedAtCompilationEnd: true);

        internal static readonly DiagnosticDescriptor RealBinderMaybeNotSetDescriptor =
            SecurityHelpers.CreateDiagnosticDescriptor(
                "DN2312",
                Messages.NetDataContractSerializerDeserializeMaybeWithoutBinderSetTitle,
                Messages.NetDataContractSerializerDeserializeMaybeWithoutBinderSetMessage,
                RuleLevel.Disabled,
                isPortedFxCopRule: false,
                isDataflowRule: true,
                isReportedAtCompilationEnd: true);

        protected override string DeserializerTypeMetadataName =>
            WellKnownTypeNames.SystemRuntimeSerializationNetDataContractSerializer;

        protected override string SerializationBinderPropertyMetadataName => "Binder";

        protected override ImmutableHashSet<string> DeserializationMethodNames =>
            SecurityHelpers.NetDataContractSerializerDeserializationMethods;

        protected override DiagnosticDescriptor BinderDefinitelyNotSetDescriptor => RealBinderDefinitelyNotSetDescriptor;

        protected override DiagnosticDescriptor BinderMaybeNotSetDescriptor => RealBinderMaybeNotSetDescriptor;
    }
}
