using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Translation;

String key = "6HrZWqr7Dejthnfx1Jr1Wfaxtxu2IvhQmYlG84K3S8VQBW3ADX0mJQQJ99BDACYeBjFXJ3w3AAAYACOGYMQs";
String region = "eastus";

SpeechTranslationConfig config = SpeechTranslationConfig.FromSubscription(key, region);
config.SpeechRecognitionLanguage = "es-ES"; // The language you want to recognize
config.AddTargetLanguage("pt"); // The language you want to translate to
config.AddTargetLanguage("en"); // The language you want to translate to

TranslationRecognizer recognizer = new TranslationRecognizer(config);

Console.WriteLine("Speak into your microphone.");

TranslationRecognitionResult  result = await recognizer.RecognizeOnceAsync();

if (result.Reason == ResultReason.TranslatedSpeech)
{
    Console.WriteLine($"Recognized: {result.Text}");
    Console.WriteLine();
    Console.WriteLine($"Translated to Portugues: {result.Translations["pt"]}");
    Console.WriteLine();
    Console.WriteLine($"Translated to Ingles: {result.Translations["en"]}");
}
else
{
    Console.WriteLine("No speech could be recognized.");
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
