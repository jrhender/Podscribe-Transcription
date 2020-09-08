using Google.Cloud.Speech.V1;
using System;

namespace podScribe.Services
{
    public class SpeechToTextService
    {
        // The name of the local audio file to transcribe
        public static string DEMO_FILE = "audio.raw";
        public void Transcribe()
        {
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "en",
            }, RecognitionAudio.FromFile(DEMO_FILE));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
        }
    }
}