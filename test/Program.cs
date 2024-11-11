using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Buffers;

var summary = BenchmarkRunner.Run<BenchmarkExample>();

public class BenchmarkExample
{
    HashSet<string> hashSet;
    string[] stringArray;
    SearchValues<string> sv;

    [GlobalSetup]
    public void Setup()
    {
        hashSet = new HashSet<string>();
        stringArray = new string[10000];
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (int i = 0; i < 10000; i++)
        {
            int length = random.Next(10, 101);
            string randomString = new string(Enumerable.Range(0, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
            hashSet.Add(randomString);
            stringArray[i] = randomString;
        }
        sv = SearchValues.Create(stringArray, StringComparison.OrdinalIgnoreCase);
    }

    [Benchmark]
    public List<bool> HashSetSearchTest()
    {
        List<bool> list = new List<bool>();
        for(int i = 0;i < stringArray.Count();i++)
        {
            list.Add(hashSet.Contains(stringArray[i]));
        }
        return list;
    }
    [Benchmark]
    public List<bool> SearchValuesSearchTest()
    {
        List<bool> list = new List<bool>();
        for (int i = 0; i < stringArray.Count(); i++)
        {
            list.Add(sv.Contains(stringArray[i]));
        }
        return list;
    }
}