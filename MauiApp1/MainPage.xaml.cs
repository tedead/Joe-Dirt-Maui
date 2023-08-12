using Plugin.Maui.Audio;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

    readonly IAudioManager audioManager;

    IAudioPlayer audioPlayer;

    public async void PlayAudio(string resource)
    {
        try
        {
            //var audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(resource));
            audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(resource));


            if (audioPlayer.IsPlaying)
            {
                audioPlayer.Stop();
            }

            audioPlayer.Play();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		//if (count == 1)
			//CounterBtn.Text = $"Clicked {count} time";
		//else
			//CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void OnButtonClick(object sender, EventArgs e)
    {
        try
        {
            Button button = (Button)sender;

            string parameter = button.CommandParameter.ToString();

            if (parameter.ToLowerInvariant().Equals("counter"))
            {
                Counter();
            }
            else
            {
                PlayAudio(parameter);
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur while playing the MP3 file.
            Console.WriteLine($"Error playing MP3: {ex.Message}");
        }
    }

    private void Counter()
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

