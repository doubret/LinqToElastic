namespace Test
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using LinqToElastic;
    using ElasticApi.Connections;

    public class tutu
    {
		public double Double { get; set; }
	}

    public class tata
    {
        public int Int { get; set; }
        public string String { get; set; }
        public int[] Array { get; set; }
		public tutu Tutu { get; set; }
    }

    public class Settings
    {
        public int A
        {
            get
            {
                return 2;
            }
        }
    }

    class Program
    {
        static int bla()
        {
            return 2;
        }

        private static int A
        {
            get
            {
                return 2;
            }
        }

        public static Settings Settings
        {
            get
            {
                return new Settings();
            }
        }

        private static bool bbb()
        {
            return false;
        }

        static void Main(string[] args)
        {
            var connection = new FakeConnection(new Uri("http://localhost:9200"));

            IEnumerable<int> r = new[] { 1, 2, 3 };
                int v = 2;

                var context = new ElasticContext(connection);

                var queryable = context
                    .Query<tata>("toto", "tata")
                    .Query(x => x
                        .Where(y => y.Int == 2)
                        .Query(y => y
                            .Where(z => z.String == "tutu")
                        )
                    )
                    .Where(y => true && y.Int == 2 || false)
                    .Where(y => y.Int == 2)
                    .Where(z => z.String == "tutu")
                    .Where(z => z.Array.Contains(1) || r.Contains(z.Int))
                    //.Where(z => z.Array.ContainsAll(r))
                    .Where(z => z.Array.ContainsAll(1, 2, 3))
                    .OrderBy(x => x.Int)
                    .Where(x => x.Int > 4 && x.Int > 3)
                    .Where(x => x.Int.Exists ())
                    .Where(x => x.String.Missing ())
                    .Where(x => x.Tutu.Double.Equals (42))
                    .Where(x => x.Tutu.Double > 2 + Settings.A + 4)
                    .Where(x => (x.Int < 2 || x.String == "tutu") == false)
                    .Where(x => x.Int.Exists () == true)
                    //.Where(x => bbb() == bbb())
                    //.Where(x => !bbb())
                    //.Where(x => true)
                    .Where(x => x.Int.Missing() == false)
                    .Where(x => !!!x.String.Missing ())
                    .Skip(0)
                    .Take(10)
                    .ToList();
        }
    }
}
