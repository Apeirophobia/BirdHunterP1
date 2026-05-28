namespace BirdHunterP
{
    public partial class MainPage : ContentPage
    {
        VerticalStackLayout vst;
        ScrollView sv;
        public List<ContentPage> Lehed = new List<ContentPage>() {new GamePage() };
        public List<string> LeheNimed = new List<string>() { "Mäng" };

        public MainPage()
        {
            // Title = "Avaleht";
            vst = new VerticalStackLayout() { Padding = 20, Spacing = 15 };
            for (int i = 0; i < Lehed.Count; i++)
            {
                Button nupp = new Button
                {
                    Text = LeheNimed[i],
                    FontSize = 36,
                    FontFamily = "Segoe Script MT Bold",
                    BackgroundColor = Colors.GreenYellow,
                    TextColor = Colors.Black,
                    CornerRadius = 10,
                    HeightRequest = 60,
                    ZIndex = i
                };

                vst.Add(nupp);
                nupp.Clicked += (sender, e) =>
                {
                    var valik = Lehed[nupp.ZIndex];
                    Navigation.PushAsync(valik);
                };

            }

            sv = new ScrollView { Content = vst };
            Content = sv;
        }

    }
}
