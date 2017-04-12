// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Internal.TypeSystem;

namespace Internal.IL.Stubs
{
    // Functionality related to deterministic ordering of types
    partial class DelegateMarshallingMethodThunk
    {
        protected internal override int ClassCode => 1018037605;

        protected internal override int CompareToImpl(MethodDesc other, TypeSystemComparer comparer)
        {
            var otherMethod = (DelegateMarshallingMethodThunk)other;

            int result = (IsOpenStaticDelegate ? 0 : 1) - (otherMethod.IsOpenStaticDelegate ? 0 : 1);
            if (result != 0)
                return result;

            return comparer.Compare(_delegateType, otherMethod._delegateType);
        }
    }
}