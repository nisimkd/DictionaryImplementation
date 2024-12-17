var dictionary = new DictionaryImplementation.MyDictionary();

dictionary.Put(17, 209);
dictionary.Put(82, 580);
dictionary.Put(1, 90);
dictionary.Put(18, 607);
dictionary.Put(16, 37);

dictionary.Put(0, 100);
dictionary.Put(16, 200);
dictionary.Put(32, 300);

Console.WriteLine($"Get value for key 17, should be 209:{dictionary.Get(17)}");
Console.WriteLine($"Get value for key 82, should be 580:{dictionary.Get(82)}");
Console.WriteLine($"Get value for key 1, should be 90:{dictionary.Get(1)}");
Console.WriteLine($"Get value for key 18, should be 607:{dictionary.Get(18)}");
Console.WriteLine($"Get value for key 16, should be 200:{dictionary.Get(16)}");
Console.WriteLine($"Get value for key 0, should be 100:{dictionary.Get(0)}");
Console.WriteLine($"Get value for key 16, should be 200:{dictionary.Get(16)}");
Console.WriteLine($"Get value for key 32, should be 300:{dictionary.Get(32)}");

try
{
    dictionary.Get(22);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}