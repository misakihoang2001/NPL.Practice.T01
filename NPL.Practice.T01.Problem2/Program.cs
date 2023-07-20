using System.Text;

public class Program
{
    static private List<string> GenerateEmailAddress(List<string> listEmployees)
    {
        List<string> result = new List<string>();
        List<string> employees = new List<string>();
        List<string> name = new List<string>();
        StringBuilder sb = new StringBuilder();
        string emailName = "@fsot.com.vn";
        for (int i = 0; i < listEmployees.Count; i++)
        {
            string[] arrStr = listEmployees[i].Split(" ");

            sb.Append(arrStr[arrStr.Length - 1].ToLower());
            //laasys chữ cái đầu mỗi khoảng trắng
            for (int j = 0; j < arrStr.Length - 1; j++)
            {
                sb.Append(arrStr[j].Substring(0,1).ToLower());
            }
            //đếm xem có bao nhiêu tên giống nhau để thêm số 
            int n = name.Where(x => x.Equals(sb.ToString())).Count();

            //đưa tên để có dữ liệu kiểm tra có tên này chưa
            name.Add(sb.ToString());
            if (n > 0)
            {
                sb.Append(n.ToString());
            }
            sb.Append(emailName);
            result.Add(sb.ToString());
            sb.Clear();
        }
        return result;

    }
    private static void main(string[] args)
    {
        List<string> employees = new List<string> { "Hoang Anh Thang", "Hoang Anh Thang", "Chow Nguyen San", "Li Yuan Chao" };

        List<string> output = GenerateEmailAddress(employees);
        output.ForEach(e => Console.WriteLine($" {e}"));
    }
}