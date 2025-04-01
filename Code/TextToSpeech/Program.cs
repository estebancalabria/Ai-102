using Microsoft.CognitiveServices.Speech;

// Creates an instance of a speech config with specified subscription key and service region.
string subscriptionKey = "f8fa8f5cb07541579fc0e0890c2899c3";
string subscriptionRegion = "eastus";

var config = SpeechConfig.FromSubscription(subscriptionKey, subscriptionRegion);
// Note: the voice setting will not overwrite the voice element in input SSML.
config.SpeechSynthesisVoiceName = "es-UY-ValentinaNeural";

string text = "Los servicios de voz unificados proporcionan una gran variedad de capacidades de generación y reconocimiento de voz, incluidas la transcripción, la conversión de texto a voz y la traducción de voz. El servicio de voz proporciona un amplio abanico de características de reconocimiento y generación de voz, como la transcripción de voz, la conversión de texto a voz, la traducción de voz y el reconocimiento del hablante.";

// use the default speaker as audio output.
using (var synthesizer = new SpeechSynthesizer(config))
{
    using (var result = await synthesizer.SpeakTextAsync(text))
    {
        if (result.Reason == ResultReason.SynthesizingAudioCompleted)
        {
            Console.WriteLine($"Speech synthesized for text [{text}]");
        }
        else if (result.Reason == ResultReason.Canceled)
        {
            var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
            Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

            if (cancellation.Reason == CancellationReason.Error)
            {
                Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                Console.WriteLine($"CANCELED: Did you update the subscription info?");
            }
        }
    }    
}
