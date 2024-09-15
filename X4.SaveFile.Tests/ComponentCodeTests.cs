using X4.SaveFile.Objects.Implementations;

namespace X4.SaveFile.Tests
{
    [TestClass]
    public class ComponentCodeTests
    {
        [TestMethod]
        public void CanParse()
        {
            Assert.IsTrue(Code.TryParse("ASD-000", out var originalCode));
            Assert.AreEqual(originalCode.PrefixCode, "ASD");
            Assert.AreEqual(originalCode.Id, 0);
            Assert.AreEqual("ASD-000", originalCode.Value);
        }

        [TestMethod]
        public void CanImplicitConvert()
        {
            Code code = "PAY-567";
            Assert.AreEqual(code.PrefixCode, "PAY");
            Assert.AreEqual(code.Id, 567);
            Assert.AreEqual("PAY-567", code.Value);
        }

        [TestMethod]
        public void FailParseWhenIdUpperBoundViolation()
        {
            Assert.IsFalse(Code.TryParse("ASD-1000", out var originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
        }

        [TestMethod]
        public void FailParseWhenIdNotNumeric()
        {
            Assert.IsFalse(Code.TryParse("ASD-A00", out var originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
            Assert.IsFalse(Code.TryParse("ASD-0S0", out originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
            Assert.IsFalse(Code.TryParse("ASD-00D", out originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
            Assert.IsFalse(Code.TryParse("ASD-ASD", out originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
        }

        [TestMethod]
        public void FailParseWhenPrefxNotLetters()
        {
            Assert.IsFalse(Code.TryParse("1SD-000", out var originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
            Assert.IsFalse(Code.TryParse("A1D-000", out originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
            Assert.IsFalse(Code.TryParse("AS1-000", out originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
        }

        [TestMethod]
        public void FailParseWhenPrefxTooLong()
        {
            Assert.IsFalse(Code.TryParse("ASDF-000", out var originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
        }

        [TestMethod]
        public void FailParseWhenPrefxTooShort()
        {
            Assert.IsFalse(Code.TryParse("AS-000", out var originalCode));
            Assert.AreEqual(originalCode, Code.Empty);
        }

        [TestMethod]
        public void CanIncrement()
        {
            Assert.IsTrue(Code.TryParse("ASD-000", out var originalCode));
            var incrementedCode = originalCode + 1;
            Assert.AreEqual(incrementedCode.PrefixCode, "ASD");
            Assert.AreEqual(incrementedCode.Id, 1);
            Assert.AreEqual("ASD-000", originalCode.Value);
            Assert.AreEqual("ASD-001", incrementedCode.Value);
        }

        [TestMethod]
        public void CanDecrement()
        {
            Assert.IsTrue(Code.TryParse("ASD-999", out var originalCode));
            var decrementedCode = originalCode - 1;
            Assert.AreEqual(decrementedCode.PrefixCode, "ASD");
            Assert.AreEqual(decrementedCode.Id, 998);
            Assert.AreEqual("ASD-999", originalCode.Value);
            Assert.AreEqual("ASD-998", decrementedCode.Value);
        }
    }
}