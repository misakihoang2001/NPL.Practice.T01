using System.Text;

internal class Program
{
    public class PhoneBook
    {
        private string name;
        private string email;
        private string address;
        private string phoneNumber;
        private static List<string> phoneData = new List<string>();
        private string relation;
        private static List<string> acceptedVal = new List<string> { "Family", "Colleague", "Friend", "Other" };

        public PhoneBook(string name, string email, string address, string phoneNumber, string relation)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Relation = relation;
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                string check = value;
                
                 
                string[] arrStr = check.Split(" ");
                if (check.Length != 12 || arrStr.Length != 3 || arrStr[0].Length != 3 || arrStr[1].Length != 3 || arrStr[2].Length != 4)
                {
                    throw new Exception("Input value is not correct!");
                }
                int firstNum = -1;

                if (!int.TryParse(check.Substring(0, 1), out firstNum) || firstNum != 0)
                {
                    throw new Exception("Input value is not correct!");
                }
                if (!int.TryParse(arrStr[0], out firstNum) || !int.TryParse(arrStr[1], out firstNum) || !int.TryParse(arrStr[2], out firstNum))
                {
                    throw new Exception("Input value is not correct!");
                }
                phoneNumber = check;
                phoneData.Add(phoneNumber);
            }
        }
        public string Relation
        {
            get => relation;
            set
            {
                string check = value;
                if (acceptedVal.Where(x => x.Equals(value)).Count() == 0)
                {
                    throw new Exception();
                }
                relation = check;


            }
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }

        public override string ToString()
        {
            return Name + " " + PhoneNumber+ " " + Email + " " + Address + " " + Relation; 
        }
    }

    public class PhoneBookManageMent
    {
        private List<PhoneBook> listPhoneBook = new List<PhoneBook>();
        
        //tạo add method
        public void Add(List<PhoneBook> phoneBook)
        {
            try
            {
                listPhoneBook.ForEach(x => listPhoneBook.Add(x));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public void Add(PhoneBook phoneBook) 
        {
            try
            {
                listPhoneBook.Add(phoneBook);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Tạo delete method
        public void Delete(string name)
        {
            PhoneBook test = listPhoneBook.Where(x => x.Name.Contains(name,StringComparison.OrdinalIgnoreCase)).First();
            if (test != null)
            {
                Console.WriteLine("Found that name");
                listPhoneBook.Remove(test);
                Console.WriteLine("Remove successfully");
                return;
            }
            Console.WriteLine("Can't find that number");
            Console.WriteLine("Can't removed unsuccessfully");
        }

        public void Sort()
        {
            listPhoneBook = listPhoneBook.OrderBy(x => x.Name).ToList();
        }
        //Tạo Find method
        public void Find(string name)
        {
            List<PhoneBook> test = listPhoneBook.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (test != null)
            {
                Console.WriteLine("Found that name");
                test.ForEach(x => Console.WriteLine(x));
                return;
            }
            Console.WriteLine("Can't find that number");
            Console.WriteLine("Can't removed unsuccessfully");
        }

        public override string ToString()
        {
            
            StringBuilder sb = new StringBuilder();
            listPhoneBook.ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString();
        }
    }

    public void main(string[] args)
    {
        //Tạo list để điền các datacontext
        List<PhoneBook> testPhoneList = new List<PhoneBook>()
        {
            new PhoneBook("Shawn","012 345 6789","shawn@gmail.com","Hanoi","Colleague"),
            new PhoneBook("Jiao","039 280 2235","Jiao@gmail.com","Danang","Family"),
            new PhoneBook("Shin","033 345 4563","shinji@gmail.com","Tokyo","Other"),
            new PhoneBook("Abu","023 555 2832","abuadi@gmail.com","Hanoi","Friend"),

        };
        PhoneBookManageMent phoneManage = new PhoneBookManageMent();
        phoneManage.Add(testPhoneList);
        Console.WriteLine(phoneManage);

        phoneManage.Delete("Abu");
        Console.WriteLine(phoneManage);

        phoneManage.Sort();
        Console.WriteLine(phoneManage);

        phoneManage.Find("Shawn");
        Console.WriteLine(phoneManage);






    }
}
