using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;

namespace Border_Corner_Bug {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new ContentPage();
            VerticalStackLayout vert = new();
            (MainPage as ContentPage).Content = vert;


            Border border = new();
            border.StyleId = "OUTER BORDER";
            border.BackgroundColor = Colors.DarkBlue;
            border.Padding = new Thickness(10);
            border.Margin = 0;
            border.StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(30), StrokeThickness = 0 };
            vert.Children.Add(border);

            Border innerBorder = new();
            innerBorder.StyleId = "INNER BORDER";
            innerBorder.HeightRequest = 60;
            innerBorder.BackgroundColor = Colors.White;
            //innerBorder.StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(20), StrokeThickness = 0 };
            innerBorder.Padding = 0;
            innerBorder.Margin = 0;
            border.Content = innerBorder;

            //==================================
            //CLICK TEST BEHAVIOR
            //==================================
            TapGestureRecognizer gesture = new();
            border.GestureRecognizers.Add(gesture);
            gesture.Tapped += delegate {
                Debug.WriteLine("BORDER WIDTH " + border.Bounds.Width + " INNER BORDER WIDTH " + innerBorder.Bounds.Width + " | DIFFERENCE " + (border.Bounds.Width - innerBorder.Bounds.Width)); 
                Debug.WriteLine("BORDER HEIGHT " + border.Bounds.Height + " INNER BORDER HEIGHT " + innerBorder.Bounds.Height + " | DIFFERENCE " + (border.Bounds.Height - innerBorder.Bounds.Height));
            };
        }
    }
}