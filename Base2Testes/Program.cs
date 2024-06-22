using System.Data;

await Exercicio1();

await Exercicio2();

await Exercicio3();


static async Task Exercicio1()
{
    HttpClient client = new HttpClient();
    string dataString = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/age-counting");

    dataString = dataString.Replace("{\"data\":\"", string.Empty);
    dataString = dataString.Replace("\"}", string.Empty);


    if (dataString != null)
    {
        var pairs = dataString.Split(", ");
        var items = new List<(string Key, int Age)>();

        for (var index = 0; index < pairs.Length; index += 2)
        {
            if (index + 1 >= pairs.Length)
                break;

            var firstPair = pairs[index].Split("=");
            var secondPair = pairs[index + 1].Split("=");

            if (firstPair.Length != 2 || secondPair.Length != 2)
                continue;

            if (firstPair[0] != "key" || secondPair[0] != "age")
                continue;

            items.Add((Key: firstPair[1], Age: int.Parse(secondPair[1])));
        }

        var count = items.Where(x => x.Age >= 50).Count();

        Console.WriteLine(count);
    }
}


static async Task Exercicio2()
{
    Console.WriteLine();

    string expression = "6*(4/2)+3*1";

    var result = new DataTable().Compute(expression, null);

    Console.WriteLine(result);
}


static async Task Exercicio3()
{
    Console.WriteLine();

    int[] arr = new int[] { 2, 3, 4, 1, 6, 10 };

    int rotacionar = arr[0];
    int[] novoArray = new int[arr.Length];

    for (int i = 1; i <= rotacionar; i++)
    {
        for (int n = 0; n < arr.Length; n++)
        {
            if (n == 0)
                novoArray[arr.Length - 1] = arr[n];
            else
                novoArray[n - 1] = (arr[n]);
        }

        novoArray.CopyTo(arr, 0);
    }


    string contatenado = string.Join("", novoArray);

    Console.WriteLine(contatenado);
}