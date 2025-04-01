
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Intent;



string rutaArchivo = @"C:\Proyectos\Whatsapp-Bot\src\audios\prueba.wav";
//Opus
//using (MediaFoundationReader mp3FileReader = new MediaFoundationReader(rutaArchivo))
//{
//  using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3FileReader))
// {
//   WaveFileWriter.CreateWaveFile("temp.wav", pcm);

SpeechConfig speechConfig = SpeechConfig.FromSubscription("f8fa8f5cb07541579fc0e0890c2899c3", "eastus");
speechConfig.SpeechRecognitionLanguage = "es-AR";

AudioConfig audioConfig = AudioConfig.FromWavFileInput(rutaArchivo);



Console.WriteLine("Vamos a hacer la conversion");

//IntentRecognizer recognizer = new IntentRecognizer(speechConfig, audioConfig);
SpeechRecognizer recognizer = new SpeechRecognizer(speechConfig, audioConfig);
//SpeechRecognitionResult result = await recognizer.RecognizeOnceAsync();
var result = await recognizer.RecognizeOnceAsync();
Console.WriteLine(result.ResultId);
Console.WriteLine(result.Reason);
Console.WriteLine(result.Text);

