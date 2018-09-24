namespace Tests
{
    public class TestCase
    {
        private readonly string _caseName;
        public object Value { get; }
        public object Expectation { get; }

        public TestCase(object value, object expectation = null, string caseName = null)
        {
            _caseName = caseName;
            Value = value;
            Expectation = expectation;
        }


        public override string ToString()
        {
            return (_caseName ?? Value).ToString();
        }
    }
}