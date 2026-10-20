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

namespace StreamingService_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StreamingPlatform platform = new StreamingPlatform();

            platform.AddContent(new Movie(new Video("Interstellar", 169)));
            platform.AddContent(new Movie(new Video("Inception", 148)));
            platform.AddContent(new Series("Stranger Things", [
                new Video("Első rész", 31),
                new Video("Második rész", 27)
            ]));

            contentDataGrid.ItemsSource = platform.GetContent().Select(content => new
            {
                Title = content.GetTitle(),
                Type = content is Movie ? "Film" : "Sorozat",
                Length = content.GetLength()
            }).ToList();
        }
    }
}