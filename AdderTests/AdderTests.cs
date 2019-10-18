// -----------------------------------------------------------------------
// <copyright file="AdderTests.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AdderTests
{
    using System;

    using Adder;

    using Bfa.Common.WPF.Validations.ValidationTestGui;
    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AdderTests
    {
        private const double epsilon = 0.00005;

        [TestMethod]
        public void CheckAdditionService()
        {
            var x = 123.0;
            var y = 0.456;
            Assert.AreEqual(
                123.456,
                CalculationService.Add(x, y),
                epsilon,
                "The calculated value of X + Y is not correct");
        }

        [TestMethod]
        public void TestAddition()
        {
            AdderViewModelINotifyDataErrorInfo vm = null;
            try
            {
                vm = (AdderViewModelINotifyDataErrorInfo)Controller.CreateViewModel(
                    typeof(AdderViewModelINotifyDataErrorInfo));
            }
            catch (Exception)
            {
            }

            Assert.AreNotEqual(vm, null);

            // One of the fields is null => can't calculate.
            vm.X = null;
            vm.Y = 0.456;
            Assert.IsFalse(vm.CanCalculate(null));
            Assert.IsTrue(vm.HasErrors);
            Assert.AreEqual(vm.ValidationErrors.CurrentValidationError.ToString(), "X: is mandatory");

            // One of the fields is null => can't calculate.
            vm.X = 123.0;
            vm.Y = null;
            Assert.IsFalse(vm.CanCalculate(null));
            Assert.IsTrue(vm.HasErrors);
            Assert.AreEqual(vm.ValidationErrors.CurrentValidationError.ToString(), "Y: is mandatory");

            // One of the fields is null => can't calculate.
            vm.X = null;
            vm.Y = null;
            Assert.IsTrue(vm.HasErrors);
            Assert.IsFalse(vm.CanCalculate(null));
            Assert.AreEqual(vm.ValidationErrors.CurrentValidationError.ToString(), "Y: is mandatory");

            // Should be able to calculate when both inputs are valid numbers.
            vm.X = 123.0;
            vm.Y = 0.456;
            Assert.IsFalse(vm.HasErrors);
            Assert.IsTrue(vm.CanCalculate(null));
            Assert.AreEqual(vm.ValidationErrors.CurrentValidationError, null);

            Assert.AreEqual(
                123.456,
                CalculationService.Add(vm.X.Value, vm.Y.Value),
                epsilon,
                "The calculated value of X + Y is not correct");

            // One of the fields is negative => can't calculate.
            vm.X = -1.0;
            vm.Y = 123.0;
            Assert.IsFalse(vm.CanCalculate(null));
            Assert.IsTrue(vm.HasErrors);
            Assert.AreEqual(vm.ValidationErrors.CurrentValidationError.ToString(), "X: must be non-negative");

            // One of the fields is negative => can't calculate.
            vm.X = 123.0;
            vm.Y = -1.0;
            Assert.IsFalse(vm.CanCalculate(null));
            Assert.IsTrue(vm.HasErrors);
            Assert.AreEqual(vm.ValidationErrors.CurrentValidationError.ToString(), "Y: must be non-negative");

            // One of the fields is negative => can't calculate.
            vm.X = -1.0;
            vm.Y = -2.0;
            Assert.IsFalse(vm.CanCalculate(null));
            Assert.IsTrue(vm.HasErrors);
            Assert.AreEqual(vm.ValidationErrors.CurrentValidationError.ToString(), "Y: must be non-negative");
        }
    }
}