public class Program
{
    private static decimal[] DrawCricleChart(int[] charInput)
    {
        //Hàm này là chạy xử lý 
        int sum = charInput.Sum();
        decimal[] resultChart = new decimal[charInput.Length];
        for (int i = 0;i < resultChart.Length; i++)
        {
            resultChart[i] = (decimal) charInput[i] / sum * 100;
        }

        return resultChart;
    }

    public void Main(string[] args)
    {
        string str = Console.ReadLine();
        string[] arrStr = str.Split(" ");
        int[] arrInt = new int[arrStr.Length];
        int newChart = 0;
        bool check = true;

        for (int i = 0; i < arrStr.Length; i++)
        {
            if (!int.TryParse(arrStr[i], out arrInt[i]) || arrInt[i] <= 0)
            {
                Console.WriteLine("error");
                check = false;
                break;
            }
            newChart = arrInt[i] + newChart;
        }
        //Check nếu input là int thì sẽ đến đoạn này
        if (check)
        {
            decimal[] decimals = DrawCricleChart(arrInt);
            for (int j = 0;  j < decimals.Length; j++)
            {
                Console.Write($"{decimals[j].ToString(".##")} ");
            }


        }

    }
}