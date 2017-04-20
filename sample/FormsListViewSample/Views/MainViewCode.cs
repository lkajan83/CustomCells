using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FormsListViewSample
{
    public class MainViewCode : ContentPage
    {
        public ObservableCollection<VeggieViewModel> veggies { get; set; }
        public MainViewCode()
        {
            veggies = new ObservableCollection<VeggieViewModel>();

            #region istView - ListView            
            ListView lstView = new ListView
            {
                SeparatorColor = Color.FromHex("#FFFF9808"),
                ItemTemplate = new DataTemplate(typeof(CustomVeggieCell)),
                RowHeight = 60,
                ItemsSource = veggies,

            };
            #endregion
            

            veggies.Add(new VeggieViewModel { Name = "Tomato", Type = "Fruit", Image = "tomato.png" });
            veggies.Add(new VeggieViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "lettuce.png" });
            veggies.Add(new VeggieViewModel { Name = "Zucchini", Type = "Vegetable", Image = "zucchini.png" });
            Content = lstView;
        }

        public class CustomVeggieCell : ViewCell
        {
            public CustomVeggieCell()
            {
                //instantiate each of our views
                var image = new Image();
                var nameLabel = new Label();
                var typeLabel = new Label();
                var verticaLayout = new StackLayout();
                var horizontalLayout = new StackLayout() { BackgroundColor = Color.Olive };

                //set bindings
                nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
                typeLabel.SetBinding(Label.TextProperty, new Binding("Type"));
                image.SetBinding(Image.SourceProperty, new Binding("Image"));

                //Set properties for desired design
                horizontalLayout.Orientation = StackOrientation.Horizontal;
                horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
                image.HorizontalOptions = LayoutOptions.End;
                nameLabel.FontSize = 24;

                //add views to the view hierarchy
                verticaLayout.Children.Add(nameLabel);
                verticaLayout.Children.Add(typeLabel);
                horizontalLayout.Children.Add(verticaLayout);
                horizontalLayout.Children.Add(image);

                // add to parent view
                View = horizontalLayout;
            }
        }
    }
}


