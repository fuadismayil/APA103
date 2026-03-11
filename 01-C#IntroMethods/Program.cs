static double GetNumber()
{
    double num;

    while (true)
    {
        Console.WriteLine(">");
        if (double.TryParse(Console.ReadLine(), out num))
        {
            return num;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Please enter legit number!");
        }
    }
}



//1)Hər biri 2 parametr qəbul edib və riyazi əməlləri yerinə yetiren method
static double SumTwoNums(double num1, double num2)
{
    return num1 + num2;
}
//Console.WriteLine("Cemini tapmaq istediyiniz iki ededi daxil edin:");
//Console.WriteLine($"daxil etdiyiniz iki ededin cemi: {SumTwoNums(GetNumber(), GetNumber())}");


static double SubtractTwoNums(double num1, double num2)
{
    return num1 - num2;
}
//Console.WriteLine("Ferqini tapmaq istediyiniz iki ededi ardicil olaraq daxil edin:");
//Console.WriteLine($"daxil etdiyiniz iki ferqi cemi: {SubtractTwoNums(GetNumber(), GetNumber())}");


static double MultiplyTwoNums(double num1, double num2)
{
    return num1 * num2;
}
//Console.WriteLine("Hasilini tapmaq istediyiniz iki ededi daxil edin:");
//Console.WriteLine($"daxil etdiyiniz iki ededin hasili: {MultiplyTwoNums(GetNumber(), GetNumber())}");


static double DivideTwoNums(double num1, double num2)
{
    return num1/ num2;
}
//Console.WriteLine("Qismetini tapmaq üçün ilk boluneni sonra boleni daxil edin:");
//Console.WriteLine($"daxil etdiyiniz iki ededin qismeti: {DivideTwoNums(GetNumber(), GetNumber())}");


static double GetRemainderTwoNums(double num1, double num2)
{
    return num1 % num2;
}
//Console.WriteLine("Qaliqi tapmaq üçün iki eded daxil edin:");
//Console.WriteLine($"Qaliq: {GetRemainderTwoNums(GetNumber(), GetNumber())}");


static double RaiseToPower(double num1, double num2)
{
    double a = num1;
    for (double i = 1; i < num2; i++) num1 *= a;
    return num1;
}
//Console.WriteLine("Ededin quvveti neticesini almaq ucun ilk ededi daha sonra quvveti daxil edin:");
//Console.WriteLine(RaiseToPower(GetNumber(), GetNumber()));



//2)Verilen arqumentlere uygun tek ve cut edeleri tapan method.(14, 20, 35, 40, 57, 60, 100)
static void FindNumbers(params int[] numbers)
{
    Console.WriteLine("Cut ededler:");
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] % 2 == 0)
        {
            Console.Write(numbers[i] + " ");
        }
    }
    Console.WriteLine("\n\nTek ededler:");
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] % 2 != 0)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}
//FindNumbers(14, 20, 35, 40, 57, 60, 100);



//3)Verilmis arreyde elementlerin həm 4-ə, həm də 5-ə bölününen elementlerin cemini tapan method.[14, 20, 35, 40, 57, 60, 100]
int[] numbers = [14, 20, 35, 40, 57, 60, 100];
static int FindAndSum(int[] numbers)
{
    int sum=0;
    for (int i = 0; i < numbers.Length; i++)
    {

        if (numbers[i]%4==0 && numbers[i] % 5 == 0)
        {
            sum += numbers[i];
        }
    }
    return sum;
}
//Console.WriteLine(FindAndSum(numbers));



//4)Daxil edilmiş cümlədə daxil edilmis simvoldan nece eded olduğunu tapan Proqramın alqoritmini.(Cumle serbestdir).
static int FindLetterCount(string sentence, char letter)
{
    int letterCount = 0;
    for (int i = 0; i < sentence.Length; i++) {
        if (sentence[i] == letter)
        {
            letterCount++;
        }
    }
    return letterCount;
}
//Console.WriteLine(FindLetterCount(Console.ReadLine().ToLower(), char.Parse(Console.ReadLine().ToLower())));