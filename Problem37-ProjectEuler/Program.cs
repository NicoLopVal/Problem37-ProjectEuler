
List<double> allPrimes = new();
List<double> truncableNum = new();
allPrimes.Add(2);
allPrimes.Add(3);
allPrimes.Add(5);
allPrimes.Add(7);

int totalCount = 0;
double totalSum = 0;
int totalPrimeTrunc = 11;
double numberCount = 11;

while (totalCount < totalPrimeTrunc)
{
    bool isPrime = true;
    foreach(double prime in allPrimes)
    {
        if(numberCount%prime == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
    {
        allPrimes.Add(numberCount);
        if(allDigitsArePrimes(numberCount) && allPrimesRemoving(numberCount))
        {
            totalCount++;
            totalSum = totalSum + numberCount;
            truncableNum.Add(numberCount);
        }
    }
    numberCount = numberCount + 2;

}

Console.WriteLine("The sum of the only eleven primes that are both truncatable from left to right and right to left is: " + totalSum);

bool allDigitsArePrimes(double number)
{
    bool allPrimes = true;

    foreach(char c in number.ToString())
    {
        string digit = c.ToString();
        if(digit == "0" || digit == "4" || digit == "6" || digit == "8")
        {
            allPrimes = false;
            break;
        }
    }
    return allPrimes;
}

bool allPrimesRemoving(double number)
{
    bool areAllPrimes = true;
    string strNumber = number.ToString();
    int j = strNumber.Length - 1;

    for(int i = 1; i < strNumber.Length; i++)
    {
        string subNum = strNumber.Substring(i);
        string subNum2 = strNumber.Substring(0, j);
        if(!allPrimes.Contains(Convert.ToDouble(subNum)) || !allPrimes.Contains(Convert.ToDouble(subNum2)))
        {
            areAllPrimes = false;
            return areAllPrimes;
        }
        j--;
    }

    return areAllPrimes;
}