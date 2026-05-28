using BirdHunterP.Models;
using Microsoft.Maui.Layouts;
using System.Threading.Tasks;

namespace BirdHunterP;

public partial class GamePage : ContentPage
{
    public Random rnd = new Random();
	public AbsoluteLayout birdLayout;
    public int score = 0;
    public Label scoreLabel;
    public Label birdCount;
    public List<Bird> birdList;
    public Button startButton;
    public GamePage()
    {

        birdList = new List<Bird>();

        /*
        for (int i = 0; i < 10; i++)
        {
            Bird bird = new Bird();
            birdList.Add(bird);
        }
        */

        startButton = new Button
        {
            Text = "Start",
            HeightRequest = 100,
            WidthRequest = 100
        };

        // birdList = FillBirds();

        birdLayout = new AbsoluteLayout { };

        /*
        foreach (Bird bird in birdList)
        {
            birdLayout.Children.Add(bird.image);
            AbsoluteLayout.SetLayoutBounds(bird.image, new Rect((float)rnd.Next(1, 10) / 10, (float)rnd.Next(1, 10) / 10, bird.image.Width, bird.image.Height));
            AbsoluteLayout.SetLayoutFlags(bird.image, AbsoluteLayoutFlags.PositionProportional);
        }
        */

        // birdLayout.Add(new Bird().image);

        scoreLabel = new Label()
        {
            Text = "Score: " + score.ToString(),
            WidthRequest = 100,
            HeightRequest = 20
        };

        birdCount = new Label()
        {
            Text = birdList.Count.ToString(),
            WidthRequest = 100,
            HeightRequest = 20

        };

        birdLayout.Add(scoreLabel);
        AbsoluteLayout.SetLayoutBounds(scoreLabel, new Rect((float)0.5, (float)0.15, scoreLabel.Width, scoreLabel.Height));
        AbsoluteLayout.SetLayoutFlags(scoreLabel, AbsoluteLayoutFlags.PositionProportional);

        birdLayout.Add(birdCount);
        AbsoluteLayout.SetLayoutBounds(birdCount, new Rect((float)0.25, (float)0.15, birdCount.Width, birdCount.Height));
        AbsoluteLayout.SetLayoutFlags(birdCount, AbsoluteLayoutFlags.PositionProportional);

        birdLayout.Add(startButton);
        AbsoluteLayout.SetLayoutBounds(startButton, new Rect((float)0.5, (float)0.5, birdCount.Width, birdCount.Height));
        AbsoluteLayout.SetLayoutFlags(startButton, AbsoluteLayoutFlags.PositionProportional);

        startButton.Pressed += Start;
        // VerticalStackLayout vst = new VerticalStackLayout() { Children = {scoreLabel, birdLayout}};

        BackgroundColor = Colors.Cyan;
        
        Content = birdLayout;
	}

    public List<Bird> FillBirds()
    {
        List<Bird> birdlist = new List<Bird>();
        for (int i = 0; i < 10; i++)
        {
            Bird bird = new Bird();

            TapGestureRecognizer tap = new TapGestureRecognizer();
            bird.image.GestureRecognizers.Add(tap);

            tap.Tapped += (s, e) =>
            {
                score += bird.value;
                bird.image.Source = "birbcry2.png";
                BirdDemolition(bird);
                
            };

            birdlist.Add(bird);
        }
        return birdlist;
    }

    public void UpdateScore()
    {
        scoreLabel.Text = "Score: " + score.ToString();
        birdCount.Text = birdList.Count.ToString(); 
    }

    public void GenerateBird()
    {
        Bird bird = new Bird();

        TapGestureRecognizer tap = new TapGestureRecognizer();
        bird.image.GestureRecognizers.Add(tap);
        tap.Tapped += (s, e) =>
        {
            score += bird.value;
            bird.image.Source = "birbcry2.png";
            BirdDemolition(bird);
        };

        birdList.Add(bird);

        birdLayout.Children.Add(bird.image);
        AbsoluteLayout.SetLayoutBounds(bird.image, new Rect((float)rnd.Next(1, 10) / 10, (float)rnd.Next(1, 10) / 10, bird.image.Width, bird.image.Height));
        AbsoluteLayout.SetLayoutFlags(bird.image, AbsoluteLayoutFlags.PositionProportional);
    }

    public async Task BirdDemolition(Bird bird)
    {
        double interval = 400;
        uint animlength = (uint)interval;

        await Task.WhenAll(
            bird.image.TranslateToAsync(0, -800, animlength, Easing.CubicIn)
            );

        birdList.Remove(bird);
        birdLayout.Remove(bird.image);
        UpdateScore();
        GenerateBird();

    }
    public void PositionBirds()
    {
        foreach (Bird bird in birdList)
        {
            birdLayout.Children.Add(bird.image);
            AbsoluteLayout.SetLayoutBounds(bird.image, new Rect((float)rnd.Next(1, 10) / 10, (float)rnd.Next(1, 10) / 10, bird.image.Width, bird.image.Height));
            AbsoluteLayout.SetLayoutFlags(bird.image, AbsoluteLayoutFlags.PositionProportional);
        }
    }

    public void Start(object sender, EventArgs e)
    {
        birdList = FillBirds();
        PositionBirds();
        UpdateScore();
        startButton.IsEnabled = false;
        startButton.IsVisible = false;
    }


}