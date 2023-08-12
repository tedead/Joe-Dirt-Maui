using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class AudioPlayerViewModel
    {
        readonly IAudioManager audioManager;

        public AudioPlayerViewModel(IAudioManager audioManager)
        {
            this.audioManager = audioManager;
        }

        public async void PlayAudio(string resource)
        {
            var audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(resource));

            audioPlayer.Play();
        }
    }
}
