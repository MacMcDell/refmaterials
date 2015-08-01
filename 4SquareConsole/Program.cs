using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FourSquareAPIConsume;
using Newtonsoft.Json.Linq;


namespace _4SquareConsole
{

    class gens<T>
    {
        public T[] ArrSort(T[] inputarray)
        {
            Array.Sort(inputarray);
            return inputarray;
        }

    }



    class Program
    {


        private static void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var gq = new gens<int>();
            int[] nums = { 3, 2, 1 };
            var rq = gq.ArrSort(nums);
            Console.WriteLine(string.Join(",", rq));
            Console.ReadLine();

            var lst1 = new string[] { "one", "two", "three" };
            var asdfasd = new gens<string>();
            lst1 = asdfasd.ArrSort(lst1);
            Console.WriteLine(string.Join(",", lst1));
            Console.ReadLine();


            return;

            var d = new dogdirector();
            idogs bread = null;

            bread = new pitty();
            d.dogbuilder(bread);
            Console.WriteLine("bread name {0} - {1} ", bread.dog.name, bread.dog.weight);

            var r = new Random();
            Func<int> rand = () => r.Next(1, 100);
            for (int i = 0; i < 10; i++)
            {
                var x = rand();
                Console.WriteLine("number {0}: {1}", x, (x % 3 == 0));


            }

            Console.ReadLine();
            return;


            Func<int, bool> xx = i => i < 4;
            Console.WriteLine(xx(2));


            Expression<Func<int, bool>> zz = i => i < 4;
            var delzz = zz.Compile();
            Console.WriteLine(delzz(2));


            var a1 = Augmenter.GetAugmenter();
            var a2 = Augmenter.GetAugmenter();

            if (a1 == a2)
                Console.WriteLine("same instance");

            for (int i = 0; i < 100; i++)
            {
                a2.increase();
                Console.WriteLine(a1.Server);
            }


            var af = new AnimalFactory().GetAnimal(AnimalFactory.animals.Cat);
            var cat = af();
            var chicken = (Animal.Chicken)new AnimalFactory().GetAnimal(AnimalFactory.animals.Chicken).Invoke();

            Console.WriteLine(cat.speak());
            Console.WriteLine(chicken.speak());
            Console.WriteLine("ENter cmd");
            var cmd = Console.ReadLine();
            Console.WriteLine(chicken.Thecmd(cmd));

            Console.ReadLine();

            return;
            var l = new int[] { 1, 1, 2 };
            removedupes(ref l);

            foreach (var i in l)
            {
                Console.WriteLine(i);
            }



            var rpts = "aaabcbba";
            Console.WriteLine(compress(rpts));
            var rpts1 = "abcdefg";
            Console.WriteLine(compress(rpts1));
            var rpts2 = "aaabaaaaaaaaa";
            Console.WriteLine(compress(rpts2));


            Console.WriteLine(isSubstring("waterbottle", "erbottlewat"));
            //Console.WriteLine(isSubstring("errottlewat","waterbottle"));// missing b
            //Console.WriteLine(isSubstring("errbottlewat", "waterbbottle")); //missing b



            Console.ReadLine();
            return;


            Console.WriteLine(ispermutation("abc", "cab"));
            Console.WriteLine(ispermutation("dabc", "cab"));
            Console.WriteLine(ispermutation("dabc", "dcab"));



            var h = new Hashtable();
            h.Add(1, "asdfaf");
            h.Add(2, "asdfasfasd");

            Console.WriteLine(h[3]);


            var s = "abc";

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                for (int j = 1; j < s.Length; j++)
                {
                    if (i != j)
                    {
                        if (s[i] == s[j])
                            Console.WriteLine("multiple chars");
                    }

                }

            }

            var inputs = "Mr. John Smith";
            Console.WriteLine(spaces(inputs));



            //var s = "abc123"; 
            //Console.WriteLine(s[2]);
            //Console.ReadLine(); 

            var ages = new int[] { 21, 34, 12, 14, 25, 25, 25, 12 };


            var queryLastNames = ages.OrderBy(x => x).GroupBy(x => x);

            var z = from x in ages
                    orderby x
                    group x by x
                        into g
                        select new { item = g.Key, count = g.Count() };

            Console.WriteLine(Math.Pow(2, 2));

            foreach (var VARIABLE in z)
            {
                Console.WriteLine("item {0} / count {1}", VARIABLE.item, VARIABLE.count);
            }


            foreach (var item in queryLastNames)
            {
                Console.WriteLine("Age {0} / Count {1}", item.Key, item.Count());
            }

            Console.ReadLine();
            return;





            asyncTask().Wait();
            Console.ReadLine();
        }

        private static void removedupes(ref int[] ints)
        {
            ints = ints.Distinct().ToArray(); // = ints.Distinct();

        }

        private static string isSubstring(string str1, string str2)
        {
            //str1 = xy = erbottlewat
            // x = er
            // y = bottlewat
            //str2 = yx = bottlewater


            if (str1.Length != str2.Length)
                return "length error";

            var s1s1 = str1 + str1;

            return s1s1.IndexOf(str2).ToString(CultureInfo.InvariantCulture);

        }

        private static string compress(string inputs)
        {

            var nevalue = from item in inputs
                          group item by item
                              into g
                              select g;
            var sb = new StringBuilder();
            foreach (var i in nevalue)
            {
                sb.Append(i.Key + i.Count().ToString());

            }

            return sb.ToString().Length < inputs.Length ? sb.ToString() : inputs;


        }

        private static string spaces(string s)
        {
            var r = new Regex(" ");
            return r.Replace(s, "%20");


        }

        private static bool ispermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            var str1Array = str1.ToCharArray();
            var str2Array = str2.ToCharArray();

            Array.Sort(str1Array);
            Array.Sort(str2Array);

            if (Enumerable.SequenceEqual(str1Array, str2Array))
                return true;

            return false;
        }


        private static async Task asyncTask()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.foursquare.com/v2/search/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("recommendations/?locale=en&explicit-lang=false&v=20150720&m=foursquare&query=coffee&limit=5&sw=49.22522116430232%2C-122.95804023742674&ne=49.28359588700294%2C-122.94190406799316&wsid=DBY05TZCT3PBHYGSA1FMNBXPBXPFGN&oauth_token=QEJ4AQPTMMNB413HGNZ5YDMJSHTOHZHMLZCAQCCLXIX41OMP");
                if (response.IsSuccessStatusCode)
                {

                    var json = await response.Content.ReadAsStringAsync();
                    //    dynamic obj = JsonConvert.DeserializeObject(json);

                    var obj = JObject.Parse(json);
                    var results = obj["response"]["group"]["results"].ToObject<Result[]>();
                    //       var meta = (string) obj["response"]["group"]["results"].ToString();
                    //   var meta = (string)obj.SelectToken("response");
                    //   var venue = await response.Content.ReadAsAsync<Venue>();
                    foreach (Result result in results)
                    {
                        Console.WriteLine(string.Format("Name: {0} Lat{1} / Long{2}", result.venue.name, result.venue.location.lat, result.venue.location.lng));
                    }
                }
            }
        }
    }
    public class Meta
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }

    public class AnnotatedGroupName
    {
    }

    public class ActiveFilters
    {
    }

    public class Location
    {
        public string address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string contextLine { get; set; }
        public long contextGeoId { get; set; }
        public List<string> formattedAddress { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string mapPrefix { get; set; }
        public string suffix { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public Icon icon { get; set; }
        public bool primary { get; set; }
    }

    public class Stats
    {
        public int checkinsCount { get; set; }
        public int usersCount { get; set; }
        public int tipCount { get; set; }
    }

    public class Price
    {
        public int tier { get; set; }
        public string message { get; set; }
        public string currency { get; set; }
    }

    public class Saves
    {
        public int count { get; set; }
        public List<object> groups { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public string canonicalUrl { get; set; }
        public string canonicalPath { get; set; }
        public List<Category> categories { get; set; }
        public bool verified { get; set; }
        public bool restricted { get; set; }
        public Stats stats { get; set; }
        public string urlSig { get; set; }
        public Price price { get; set; }
        public bool dislike { get; set; }
        public bool ok { get; set; }
        public Saves saves { get; set; }
    }

    public class Photo
    {
    }

    public class Snippets
    {
    }

    public class Result
    {
        public string displayType { get; set; }
        public Venue venue { get; set; }
        public Photo photo { get; set; }
        public Snippets snippets { get; set; }
    }

    public class Group
    {
        public AnnotatedGroupName annotatedGroupName { get; set; }
        public ActiveFilters activeFilters { get; set; }
        public List<Result> results { get; set; }
        public int totalResults { get; set; }
    }

    public class Context
    {
    }

    public class SuggestedModifications
    {
    }

    public class Ne
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Sw
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class SuggestedBounds
    {
        public Ne ne { get; set; }
        public Sw sw { get; set; }
    }

    public class Response
    {
        public Group group { get; set; }
        public Context context { get; set; }
        public SuggestedModifications suggestedModifications { get; set; }
        public string headerFullLocation { get; set; }
        public string headerLocationGranularity { get; set; }
        public SuggestedBounds suggestedBounds { get; set; }
    }

    public class RootObject
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }
}
