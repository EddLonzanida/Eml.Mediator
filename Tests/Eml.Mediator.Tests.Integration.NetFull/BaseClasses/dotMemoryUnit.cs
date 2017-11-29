using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.dotMemoryUnit;

namespace Eml.Mediator.Tests.Integration.NetFull.BaseClasses
{
    internal class DotMemoryUnit : IDisposable
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private DotMemoryUnit()
        {
            // frame1 is DotMemoryUnit.Support() method; frame2 is "test" method
            DotMemoryUnitController.TestStart(new StackTrace().GetFrame(2).GetMethod());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IDisposable Support()
        {
            return new DotMemoryUnit();
        }

        public void Dispose()
        {
            DotMemoryUnitController.TestEnd();
        }
    }
}
