using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace StreamingService_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string path = "contents.txt";

            StreamingPlatform platform = new StreamingPlatform();

            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Split('|');

                if (parts[0] == "Movie")
                {
                    platform.AddContent(
                        new Movie(new Video(parts[1], int.Parse(parts[2])))
                    );
                }
                else if (parts[0] == "Series")
                {
                    var videos = parts[2].Split(';')
                        .Select(v =>
                        {
                            string[] data = v.Split(':');
                            return new Video(data[0], int.Parse(data[1]));
                        })
                        .ToList();

                    platform.AddContent(new Series(parts[1], videos));
                }
            }

            contentDataGrid.ItemsSource = platform.GetContent().Select(content => new
            {
                Title = content.GetTitle(),
                Type = content is Movie ? "Film" : "Sorozat",
                Length = content.GetLength()
            }).ToList();
        }
    }
}