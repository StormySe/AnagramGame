using System.Text;
namespace Anagram
{
	public class Anagram
	{
		public static void Main(string[] args)
		{
			string anagram = args[0];
			string input = default;

			Compare comparator = new Compare(anagram);

			while (true)
			{
				Console.WriteLine("Введите слово:");
				input = Console.ReadLine();
				
				if (input == "stop!")
					break;

				if (comparator.Is_anagram(input))
				{
					Console.WriteLine("Да!!! Это - анаграмма!");
				}
				else
				{
					Console.WriteLine("Нет! Это - не анаграмма!");
				}
			}
			
		}
	}

	class Compare
	{
		private string anagram;
		
		public Compare(string anagram)
		{
			anagram = sort(anagram);
			this.anagram = anagram;
		}

		public bool Is_anagram(string input)
		{
			string result = sort(input);
			bool ret = anagram.Contains(result) ? true : false;
			return ret;
		}

		private string sort(string input)
		{
			//selection sort
			int n = input.Length;
			StringBuilder inpt = new StringBuilder(input);

			for(int i = 0; i < n - 1; i++)
			{
				int min_index = i;
				for(int j = i + 1; j < n; j++)
				{
					if(inpt[j] < inpt[min_index])
						min_index = j;
				}

				char temp = inpt[min_index];
				inpt[min_index] = inpt[i];
				inpt[i] = temp;
			}
			input = inpt.ToString();
			return input;
		}
	}
}

