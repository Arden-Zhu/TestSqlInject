namespace TestSqlInject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTestDevContext db = new DataTestDevContext();
            var tests = db.sp148Test("a'b'c");
            Console.WriteLine(tests[tests.Count - 1]);
        }
    }
}