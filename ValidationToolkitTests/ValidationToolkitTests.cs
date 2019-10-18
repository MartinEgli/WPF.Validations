// -----------------------------------------------------------------------
// <copyright file="ValidationToolkitTests.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.Tests
{
    using Bfa.Common.Validations;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidationToolkitTests
    {
        private const string constraint1 = "AAA";

        private const string constraint2 = "BBB";

        private readonly ValidationErrorContainer container = new ValidationErrorContainer();

        [TestMethod]
        public void Test_ValidationError_Equality()
        {
            var propertyName = "property_X";

            // err1 and err2 are the same error as far as the error container is concerned.
            var err1 = new ValidationError(propertyName, constraint1, "Some error message");
            var err2 = new ValidationError(propertyName, constraint1, "Another error message");

            // err3 and err4 are the same error as far as the error container is concerned.
            var err3 = new ValidationError(propertyName, constraint2, "Yet another error message");
            var err4 = new ValidationError(propertyName, constraint2, "Yet another error message, again");

            Assert.AreEqual(
                err1,
                err2,
                "The validation errors err1 and err2 refer to the same validation constraint and should be 'equal'");
            Assert.AreEqual(
                err3,
                err4,
                "The validation errors err1 and err2 refer to the same validation constraint and should be 'equal'");
            Assert.AreNotEqual(
                err1,
                err3,
                "The validation errors err1 and err3 refer to different validation constraint and should not be 'equal'");

            //
            // Check different validation errors do not interfer with each other.
            //
            Assert.IsTrue(this.container.AddError(err1), "Failed to add error 'err1'");
            Assert.IsTrue(this.container.ErrorCount >= 0);

            Assert.IsFalse(this.container.AddError(err2), "Added duplicate error 'err2'");
            Assert.IsTrue(this.container.ErrorCount >= 0, "");

            Assert.IsTrue(this.container.AddError(err3), "Failed to add error 'err3'");
            Assert.IsTrue(this.container.ErrorCount >= 0, "");

            Assert.IsFalse(this.container.AddError(err4), "Added duplicate error 'err4'");
            Assert.IsTrue(this.container.ErrorCount >= 0, "");

            Assert.IsTrue(err1.Id == err2.Id, "'err1' and 'err2' not reported as the same error.");
            Assert.IsTrue(err2.Id != err3.Id, "'err2' and 'err3' reported as the same error.");
            Assert.IsTrue(err3.Id == err4.Id, "'err3' and 'err4' not reported as the same error.");

            this.container.RemoveError(propertyName, err2.Id);
            this.container.RemoveError(propertyName, err3.Id);
            Assert.IsTrue(this.container.ErrorCount == 0, "Error container still contains errors.");
        }
    }
}