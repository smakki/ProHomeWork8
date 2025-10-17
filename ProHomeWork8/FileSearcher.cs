namespace ProHomeWork8;

public class FileSearcher
{
    public event EventHandler<FileArgs>? FileFound;

    public void Search(string path)
    {
        foreach (var file in Directory.GetFiles(path))
        {
            var args = new FileArgs(file);
            FileFound?.Invoke(this, args);

            if (!args.Cancel) continue;
            Console.WriteLine("Поиск отменён из обработчика.");
            return;
        }

        foreach (var dir in Directory.GetDirectories(path))
        {
            Search(dir);
        }
    }
}

public class FileArgs(string fileName) : EventArgs
{
    public string FileName { get; } = fileName;
    public bool Cancel { get; set; }
}