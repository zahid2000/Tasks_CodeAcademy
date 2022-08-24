using System.Text.Json;

//int[] elements = { 1, 2, 3, 2, 1, 4, 5, 6, 1 };
//string[] values = { "Kitab", "Defter", "Stol", "Stul", "Qelem" };
//Task1
//CheckElementHowManyTimesExists(elements);
//Task2
//CheckElementExistsInArray(elements, 11);

//Task3
//Console.WriteLine(JsonSerializer.Serialize(elements));
//Array.ForEach(values, Console.WriteLine);
//int count = 0;
//WriteAllElements(values);

//Task4
//string text = "Peşəkar Yetişdirmə Proqramı (PYP) Code Academy tərəfindən bootcamp metodu vasitəsilə ixtisaslaşmış kadrların formalaşdırılması" +
//              " məqsədilə həyata keçirilən xüsusi tədris proqramıdır. Proqram peşəkarların yeni bilik və bacarıqlar qazanaraq ixtisaslarını" +
//              " artırmalarına kömək etmək üçün yaradılıb.";
//string startWith = "Pro";
//WriteStartWithObj(text, startWith);

//Task5
//WriteArraysValue();
 
//Task6
//int[] arr1 = { 1, 2, 3, 4, 45, 5, 7, 8, 9, 12, 32 };
//int[] arr2 = { 1, 13, 3, 4, 44, 5, 7, 8, 22, 42, 32 };
//SeperateArraysElements(arr1, arr2);


//bir dizi içerisinde bir eleman birden fazla olup olmadığını kontrol eden bir kod bloğu
void CheckElementHowManyTimesExists(int[] elements)
{

    int[] existsElements = new int[0];
    int existsCount;
    for (int i = 0; i < elements.Length; i++)
    {
        existsCount = 0;
        if (Array.IndexOf(existsElements, elements[i]) == -1)
        {
            for (int j = i; j < elements.Length; j++)
            {
                if (elements[j] == elements[i])
                {
                    existsCount++;
                }
            }

            Array.Resize(ref existsElements, existsElements.Length + 1);
            existsElements[existsElements.Length - 1] = elements[i];
            Console.WriteLine($"Number  {elements[i]} exists {existsCount} times");
        }
    }
}
//dizi içerisinde bir elemanın var olup olmadığını kontrol ediniz, bu değer bool tipinde olacak
bool CheckElementExistsInArray(int[] elements, int checkedElement)
{
    var result = Array.IndexOf(elements, checkedElement) != -1;
    Console.WriteLine(result);
    return result;
}
//içerisinde birden fazla eleman tanımladığınız dizi içerisindeki elemanları, for, foreach, while, do-while döngüsü kullanmadan ekrana yazdırınız
void WriteAllElements(string[] values)
{

    if (count < values.Length)
    {

        Console.WriteLine(values[count]);
        count++;

        WriteAllElements(values);
    }
    else
    {
        count = 0;
    }

}
//metinsel bir dizi içerisindeki değerlerde,  verdiğiniz değer ile başlayan tüm elemanları ekrana yazdırınız.
void WriteStartWithObj(string text, string startWith)
{
    string[] values = text.Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
    var result = values.Where(v => v.StartsWith(startWith)).ToList();
    for (int i = 0; i < result.Count; i++)
    {
        Console.WriteLine(result[i]);
    }
}
//var olan 2 dizinin elemanlarını ekrana yazdırınız.
void WriteArraysValue()
{
    int[] elements = { 1, 2, 3, 2, 1, 4, 5, 6, 1 };
    string[] values = { "Kitab", "Defter", "Stol", "Stul", "Qelem" };
    for (int i = 0; i < elements.Length; i++)
    {
        Console.WriteLine(elements[i]);
    }
    for (int i = 0; i < values.Length; i++)
    {
        Console.WriteLine(values[i]);
    }
}
//sayısal 2 dizi içerisinde yer alan farklı elemanları yeni bir diziye, aynı olanları yeni bir diziye ekleyiniz.
void SeperateArraysElements(int[] arr1, int[] arr2)
{
    int[] sameElements = new int[0];
    int[] differentElements = new int[0];
    for (int i = 0; i < arr1.Length; i++)
    {
        if (Array.IndexOf(arr2, arr1[i]) != -1)
        {
            Array.Resize(ref sameElements, sameElements.Length + 1);
            sameElements[sameElements.Length - 1] = arr1[i];

        }
        else
        {
            Array.Resize(ref differentElements, differentElements.Length + 1);
            differentElements[differentElements.Length - 1] = arr1[i];

        }
    }
    for (int i = 0; i < arr2.Length; i++)
    {
        if (Array.IndexOf(sameElements, arr2[i]) != -1 || Array.IndexOf(differentElements, arr2[i]) != -1)
        {
            continue;
        }


        if (Array.IndexOf(arr1, arr2[i]) == -1)
        {
            Array.Resize(ref differentElements, differentElements.Length + 1);
            differentElements[differentElements.Length - 1] = arr2[i];

        }
      

    }

    Console.WriteLine("SameElements : "+JsonSerializer.Serialize(sameElements));
    Console.WriteLine("differentElements : " + JsonSerializer.Serialize(differentElements));
}