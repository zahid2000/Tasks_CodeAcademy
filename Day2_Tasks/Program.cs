//Task1 Run
//Write100Numbers();

//Task2 Run
//WriteTextReverse();

//Task3 Run
//CheckPrimeNumbers();

//Task4 Run
UserNumbers();

//------------------------------------Methods------------------------------------------------------//
#region Task1
// Task1-100'e kadar olan sayıların negatif ve pozitif halini yazdırın.değişken kullanmayınız :)
void Write100Numbers()
{
    foreach (int num in Enumerable.Range(0, 100))
    {
        Console.WriteLine($"Positive = {num} and Negative = {-num}");
    }
}
#endregion

#region Task2

//Task2-Kullanıcıdan aldığınız metinsel değeri tersten ekrana yazdırınız. örnek murat -> tarum
void WriteTextReverse()
{
    Console.WriteLine("Enter the text");
    string text = Console.ReadLine();
    Console.Write(text + " --> ");
    for (int i = text.Length - 1; i >= 0; i--)
    {
        Console.Write(text[i]);
    }
}
#endregion

#region Task3
//Task3-10 ile 20 arasındaki sayıları asal sayı olup olmadığını gönderdiğim tabloya göre ayrıştırınız
void CheckPrimeNumbers()
{
    int[] arr = { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    bool isPrime;
    for (int i = 0; i <= arr.Length; i++)
    {
        isPrime = true;
        for (int j = 2; j <=9; j++)
        {
            if (arr[i] % j == 0)
            {
                Console.WriteLine($"{arr[i]} = {j} * {arr[i] / j} ");
                isPrime = false;
                break;
            }
        }

        if (isPrime)
        {
            Console.WriteLine($"{arr[i]} is prime");
        }
    }
}

#endregion

#region Task4
//Task4-Kullanıcı dışarıdan dilediği kadar sayı girecek, her sayı girdikten sonra, sayı girmeye devam edip etmeyeceği sorulacak.
//kullanıcı y Y tuşuna basarsa, yeni bir sayı girmesi istenilecek  kullanıcı harici bir tuşa basar ise, içeriye aldığı sayılar içerisindeki
//tek sayılar içerisinde yer alan en büyü ve en küçün sayının biribirine olan farkını geriye dönecek
void UserNumbers()
{
    int[] oddNumbers = new int[0];
    while (true)
    {
        Console.WriteLine("Do you want to add new number? y/n");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "y")
        {
            Console.WriteLine("Enter the number");
            string answerNum = Console.ReadLine();
            if (string.IsNullOrEmpty(answerNum))
            {
                continue;
            }
            int num = int.Parse(answerNum);
            
            if (num % 2 == 1)
            {
                Array.Resize(ref oddNumbers, oddNumbers.Length + 1);
                oddNumbers[oddNumbers.Length - 1] = num;
            }

        }
       else if (string.IsNullOrEmpty(answer))
        {
            continue;
        }
        else
        {
            if (oddNumbers.Length==0)
            {
                Console.WriteLine("Don't find odd numbers");
                break;
            }
            if (oddNumbers.Length == 1)
            {
                Console.WriteLine($"Find one odd number : {oddNumbers[0]}");
                break;
            }
            else
            {
                int[] sortedArray = SortArray(oddNumbers);
                Console.WriteLine($"Min : {sortedArray[0]}, Max : {sortedArray[sortedArray.Length - 1]}");
                Console.WriteLine($"The difference between the largest and smallest numbers in odd numbers : {(Math.Abs(sortedArray[0] - sortedArray[sortedArray.Length - 1]))}");
                break;
            }
           
        }
    }
}

int[] SortArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = i; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                int a = arr[i];
                arr[i] = arr[j];
                arr[j] = a;
            }
        }
    }
    return arr;
} 
#endregion