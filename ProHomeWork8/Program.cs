namespace ProHomeWork8
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person("Аня", 23),
                new Person("Борис", 31),
                new Person("Сергей", 28)
            };

            var oldest = people.GetMax(p => p.Age);
            Console.WriteLine($"Самый старший: {oldest.Name}, {oldest.Age} лет");
           
            var searcher = new FileSearcher();
            searcher.FileFound += OnFileFound;

            Console.WriteLine("Введите путь к каталогу:");
            var path = Console.ReadLine();

            searcher.Search(path);
        }
        
        private static void OnFileFound(object sender, FileArgs e)
        {
            Console.WriteLine($"Найден файл: {e.FileName}");

            if (!e.FileName.EndsWith(".exe")) return;
            Console.WriteLine("Файл .exe найден — останавливаем поиск.");
            e.Cancel = true;
        }
    }
}
