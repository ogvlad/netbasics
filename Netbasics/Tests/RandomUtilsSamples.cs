namespace Netbasics.Tests
{
    public class RandomUtilsSamples
    {
        public enum MySampleEnum
        {
            Val1,
            Val2,
            Val3,
            Val4,
        }

        public void MySampleTest()
        {
            var rnd = new RandomHelper();

            var testBool = rnd.RandomBool();

            var testString = rnd.RandomString();
            var testStringAllowedEmpty = rnd.RandomString(true);

            var testEnum = rnd.RandomEnum<MySampleEnum>();
            var testEnumWithExceptions = rnd.RandomEnum<MySampleEnum>(MySampleEnum.Val2);
        }
    }
}
