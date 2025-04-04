using Microsoft.CognitiveServices.Speech;

String key = "xxxxxx";
String region = "eastus";


//
//Ejemplo Sintesis de voz
//

/*SpeechConfig config = SpeechConfig.FromSubscription(key, region);
//Defino el nombre de la voz que quiero
//config.SpeechSynthesisVoiceName = "es-ES-TristanMultilingualNeural";
config.SpeechSynthesisVoiceName = "es-MX-DaliaNeural";

SpeechSynthesizer synthesizer = new SpeechSynthesizer(config);

await synthesizer.SpeakTextAsync("Hola");
await synthesizer.SpeakTextAsync("Como estas?");

Console.WriteLine("Press any key to exit...");  
Console.ReadKey();*/


//
// Ejemplo Reconocimiento de Voz
//
SpeechConfig config = SpeechConfig.FromSubscription(key, region);
config.SpeechRecognitionLanguage = "es-AR";

SpeechRecognizer speechRecognizer = new SpeechRecognizer(config);
Console.WriteLine("Habla nomas....");
SpeechRecognitionResult result = await speechRecognizer.RecognizeOnceAsync();

if (result.Reason == ResultReason.RecognizedSpeech)
{
    Console.WriteLine($"Texto reconocido: {result.Text}");
}
else 
{
    Console.WriteLine("No se reconoció nada.");
}

Console.WriteLine("Press any key to exit...");  
Console.ReadKey();