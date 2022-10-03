using System.Text;
namespace Anagram
{
    public class Program
    {
        public static void Main(string[] Args)
        {
			string GetAnagram = Args[0];
			Anagram anagram = new Anagram(GetAnagram);
			
			Console.WriteLine($"Введите анаграмму для слова {GetAnagram}");
			while (true)
			{
				string attempt = Console.ReadLine();
				if (attempt == "stop!")
					break;

				anagram.TryAnagram = attempt;
				if (anagram.Compare())
					Console.WriteLine("Да! Это анаграмма!");
				else
					Console.WriteLine("Нет! Это не анаграмма");
			}
        }
    }

	public class Anagram
	{
		private string anagram;
		private string try_anagram;

		public Anagram(string anagram)
		{
			this.anagram = Sort(anagram);
		}

		public string TryAnagram
		{
			set 
			{
				try_anagram = value;
			}
		}

		public bool Compare()
		{
			if (Equals(anagram, Sort(try_anagram)))
				return true;
			else
				return false;
			
		}

		private string Sort(string param_str)
		{
			//selection sort algorithm
			StringBuilder str = new StringBuilder(param_str); //strings are immutable, so I need to use StringBuilder here
			int size = str.Length;
			for (int i = 0; i < size - 1; i++)
			{
				int min = i;
				for (int j = i + 1; j < size; j++)
				{
					if (str[j] < str[min])
						min = j;
				}
				
				char temp = str[min];
				str[min] = str[i];
				str[i] = temp;
			}
			return str.ToString();
		}
	}
}
