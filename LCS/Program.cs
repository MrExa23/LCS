string a = "ACDBACDB";
string b = "ABCDABCD";

int x = a.Length+1;
int y = b.Length+1;

int[,] dp = new int[x, y];
for (int i = 0; i < x; i++)
{
    dp[i,0] = 0;
}
for (int i = 0; i < y; i++)
{
    dp[0, i] = 0;
}

for (int i = 1; i < x; i++)
{
    for (int j = 1; j < y; j++)
    {
        if (a[i-1] == b[j-1])
        {
            dp[i, j] = dp[i - 1, j - 1] + 1;
        }
        else
        {
            if (dp[i, j - 1] > dp[i - 1, j])
            {
                dp[i, j] = dp[i, j - 1];
            }
            else
            {
                dp[i, j] = dp[i - 1, j];
            }
        }
    }
}

for (int i = 0; i < x; i++)
{
    for (int j = 0; j < y; j++)
    {
        Console.Write(dp[i, j]+" "); 
    }
    Console.WriteLine();
}
string s = "";
int e = x-2;
int f = y-2;
while (true)
{
    if (a[e] == b[f])
    {
        s += a[e];
        e--;
        f--;

    }
    else if (dp[e,f+1] > dp[e+1,f])
    {
        if(e!=0)
        e--;
    }
    else
    {
        if (f != 0)
            f--;
    }
    if(e < 0&&f<0)
    {
        break;
    }
}
string vysledek = "";
for (int i = 0;i < s.Length; i++)
{
    vysledek += s[s.Length-i-1];
}

Console.WriteLine();
Console.WriteLine(vysledek);
