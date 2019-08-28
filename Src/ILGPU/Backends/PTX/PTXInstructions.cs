﻿// -----------------------------------------------------------------------------
//                                    ILGPU
//                     Copyright (c) 2016-2019 Marcel Koester
//                                www.ilgpu.net
//
// File: PTXInstructions.cs
//
// This file is part of ILGPU and is distributed under the University of
// Illinois Open Source License. See LICENSE.txt for details
// -----------------------------------------------------------------------------

using ILGPU.IR.Values;

namespace ILGPU.Backends.PTX
{
    /// <summary>
    /// Constains general PTX instructions.
    /// </summary>
    public static partial class PTXInstructions
    {
        /// <summary>
        /// Resolves a LEA operation.
        /// </summary>
        /// <param name="pointerType">The pointer type.</param>
        /// <returns>The resolved LEA operation.</returns>
        public static string GetLEAMulOperation(ArithmeticBasicValueType pointerType) =>
            LEAMulOperations[pointerType];

        /// <summary>
        /// Resolves a select-value operation.
        /// </summary>
        /// <param name="type">The basic value type.</param>
        /// <returns>The resolved select-value operation.</returns>
        public static string GetSelectValueOperation(BasicValueType type) =>
            SelectValueOperations[type];

        /// <summary>
        /// Resolves a compare operation.
        /// </summary>
        /// <param name="kind">The compare kind.</param>
        /// <param name="type">The type to compare.</param>
        /// <returns>The resolved compare operation.</returns>
        public static string GetCompareOperation(CompareKind kind, ArithmeticBasicValueType type) =>
            CompareOperations[(kind, type)];

        /// <summary>
        /// Resolves a convert operation.
        /// </summary>
        /// <param name="source">The source type to convert from.</param>
        /// <param name="target">The target type to convert to.</param>
        /// <returns>The resolved convert operation.</returns>
        public static string GetConvertOperation(ArithmeticBasicValueType source, ArithmeticBasicValueType target) =>
            ConvertOperations[(source, target)];

        /// <summary>
        /// Resolves an unary arithmetic operation.
        /// </summary>
        /// <param name="kind">The arithmetic kind.</param>
        /// <param name="type">The operation type.</param>
        /// <param name="fastMath">True, to use a fast-math operation.</param>
        /// <returns>The resolved arithmetic operation.</returns>
        public static string GetArithmeticOperation(
            UnaryArithmeticKind kind,
            ArithmeticBasicValueType type,
            bool fastMath)
        {
            var key = (kind, type);
            if (fastMath &&
                UnaryArithmeticOperationsFastMath.TryGetValue(key, out string operation))
                return operation;
            return UnaryArithmeticOperations[key];
        }

        /// <summary>
        /// Resolves a binary arithmetic operation.
        /// </summary>
        /// <param name="kind">The arithmetic kind.</param>
        /// <param name="type">The operation type.</param>
        /// <param name="fastMath">True, to use a fast-math operation.</param>
        /// <returns>The resolved arithmetic operation.</returns>
        public static string GetArithmeticOperation(
            BinaryArithmeticKind kind,
            ArithmeticBasicValueType type,
            bool fastMath)
        {
            var key = (kind, type);
            if (fastMath &&
                BinaryArithmeticOperationsFastMath.TryGetValue(key, out string operation))
                return operation;
            return BinaryArithmeticOperations[key];
        }

        /// <summary>
        /// Resolves a ternay arithmetic operation.
        /// </summary>
        /// <param name="kind">The arithmetic kind.</param>
        /// <param name="type">The operation type.</param>
        /// <returns>The resolved arithmetic operation.</returns>
        public static string GetArithmeticOperation(
            TernaryArithmeticKind kind,
            ArithmeticBasicValueType type)
        {
            var key = (kind, type);
            return TernaryArithmeticOperations[key];
        }

        /// <summary>
        /// Resolves an atomic operation.
        /// </summary>
        /// <param name="kind">The arithmetic kind.</param>
        /// <param name="requireResult">True, if the return value is required.</param>
        /// <returns>The resolved atomic operation.</returns>
        public static string GetAtomicOperation(AtomicKind kind, bool requireResult) =>
            AtomicOperations[(kind, requireResult)];

        /// <summary>
        /// Resolves an atomic-operation suffix.
        /// </summary>
        /// <param name="kind">The arithmetic kind.</param>
        /// <param name="type">The operation type.</param>
        /// <returns>The resolved atomic-operation suffix.</returns>
        public static string GetAtomicOperationSuffix(AtomicKind kind, ArithmeticBasicValueType type) =>
            AtomicOperationsTypes[(kind, type)];

        /// <summary>
        /// Resolves an address-space-cast operation.
        /// </summary>
        /// <param name="convertToGeneric">True, to convert to the generic address space.</param>
        /// <returns>The resolved address-space-cast operation.</returns>
        public static string GetAddressSpaceCast(bool convertToGeneric) =>
            AddressSpaceCastOperations[convertToGeneric ? 0 : 1];

        /// <summary>
        /// Resolves an address-space-cast suffix.
        /// </summary>
        /// <param name="abi">The current ABI.</param>
        /// <returns>The resolved address-space-cast suffix.</returns>
        public static string GetAddressSpaceCastSuffix(ABI abi) =>
            AddressSpaceCastOperationSuffix[abi.PointerBasicValueType == BasicValueType.Int32 ? 0 : 1];

        /// <summary>
        /// Resolves a barrier operation.
        /// </summary>
        /// <param name="kind">The barrier kind.</param>
        /// <returns>The resolved barrier operation.</returns>
        public static string GetBarrier(BarrierKind kind) =>
            BarrierOperations[(int)kind];

        /// <summary>
        /// Resolves a predicate-barrier operation.
        /// </summary>
        /// <param name="kind">The barrier kind.</param>
        /// <returns>The resolved predicate-barrier operation.</returns>
        public static string GetPredicateBarrier(PredicateBarrierKind kind) =>
            PredicateBarrierOperations[(int)kind];

        /// <summary>
        /// Resolves a memory-barrier operation.
        /// </summary>
        /// <param name="kind">The barrier kind.</param>
        /// <returns>The resolved memory-barrier operation.</returns>
        public static string GetMemoryBarrier(MemoryBarrierKind kind) =>
            MemoryBarrierOperations[(int)kind];

        /// <summary>
        /// Resolves a shuffle operation.
        /// </summary>
        /// <param name="kind">The barrier kind.</param>
        /// <returns>The resolved shuffle operation.</returns>
        public static string GetShuffleOperation(ShuffleKind kind) =>
            ShuffleOperations[(int)kind];
    }
}
