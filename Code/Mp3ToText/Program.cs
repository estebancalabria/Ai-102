using Concentus.Structs;
using Concentus.Oggfile;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Intent;
using NAudio.Wave;
using System.Diagnostics;


//string rutaArchivo = @"C:\Proyectos\Whatsapp-Bot\src\audios\prueba.ogg";
string rutaArchivo = String.Empty;;

       //string[] args = Environment.GetCommandLineArgs();

        // Buscar el patrón "-FileName" seguido de un valor de nombre de archivo

if (args.Length==0)
{
   Console.WriteLine($"Usage {Process.GetCurrentProcess().ProcessName} -FileName <path_to_file>");
   return;
}

for (int i = 0; i < args.Length-1; i++)
{
    if (args[i].Equals("-FileName", StringComparison.OrdinalIgnoreCase))
    {
        // Verificar si hay un valor de nombre de archivo después del parámetro
        if (i + 1 < args.Length)
        {
            rutaArchivo = args[i + 1];
            if (!File.Exists(rutaArchivo)) 
            {
                Console.WriteLine($"File not found {rutaArchivo}");
                return;
            }
            // Puedes realizar cualquier acción adicional con el nombre de archivo
        }
        else
        {
            Console.WriteLine("Use -FileName <path_to_file>. <path_to_file> required.");
            return;
        }
        break;
    }
}

if (rutaArchivo.Equals(String.Empty))
{
   Console.WriteLine($"Usage {Process.GetCurrentProcess().ProcessName} -FileName <path_to_file>. -FileName required.");
   return;
}


//Opus
//using (MediaFoundationReader mp3FileReader = new MediaFoundationReader(rutaArchivo))
//{
//  using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3FileReader))
// {
//   WaveFileWriter.CreateWaveFile("temp.wav", pcm);

FileStream stream = new FileStream(rutaArchivo, FileMode.Open);
SpeechConfig speechConfig = SpeechConfig.FromSubscription("f8fa8f5cb07541579fc0e0890c2899c3", "eastus");
speechConfig.SpeechRecognitionLanguage = "es-AR";

PushAudioInputStream inputStream = AudioInputStream.CreatePushStream();
var decoder = new OpusDecoder(16000, 1);
var opus = new OpusOggReadStream(decoder, stream);

while (opus.HasNextPacket)
{
    short[] packet = opus.DecodeNextPacket();
    if (packet != null)
    {
        for (int i = 0; i < packet.Length; i++)
        {
            var bytes = BitConverter.GetBytes(packet[i]);
            inputStream.Write(bytes, bytes.Length);
        }
    }
}

//Console.WriteLine("Termino la conversion");
AudioConfig audioConfig = AudioConfig.FromStreamInput(inputStream);


// Ahora puedes utilizar el objeto audioConfig en las operaciones de reconocimiento de voz
// o síntesis de voz utilizando el servicio Speech de Microsoft Cognitive Services
/*using(SpeechRecognizer recognizer = new SpeechRecognizer(speechConfig, audioConfig)){
        recognizer.Recognizing += (s, e) => {
            Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
        };

        recognizer.Recognized += (s, e) => {
            var result = e.Result;
            Console.WriteLine($"Reason: {result.Reason.ToString()}");
            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                    Console.WriteLine($"Final result: Text: {result.Text}.");
            }
        };

        recognizer.Canceled += (s, e) => {
            Console.WriteLine(e.ErrorDetails);
            Console.WriteLine($"\n    Canceled. Reason: {e.Reason.ToString()}, CanceledReason: {e.Reason}");
        };

        recognizer.SessionStarted += (s, e) => {
            Console.WriteLine("\n    Session started event.");
        };

        recognizer.SessionStopped += (s, e) => {
            Console.WriteLine("\n    Session stopped event.");
        };

        // Starts continuous recognition. 
        // Uses StopContinuousRecognitionAsync() to stop recognition.
        await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

}*/


//Console.WriteLine("Vamos a hacer la conversion");

IntentRecognizer recognizer = new IntentRecognizer(speechConfig, audioConfig);
//SpeechRecognitionResult result = await recognizer.RecognizeOnceAsync();
var result = await recognizer.RecognizeOnceAsync();
//Console.WriteLine(result.ResultId);
//Console.WriteLine(result.Reason);
Console.WriteLine(result.Text);

//}
//}



   /*var config = SpeechConfig.FromSubscription("f8fa8f5cb07541579fc0e0890c2899c3", "eastus");
    config.SpeechRecognitionLanguage = "es-Ar";

    // Creates a speech recognizer from microphone.
    using (var recognizer = new SpeechRecognizer(config))
    {
        // Subscribes to events.
        recognizer.Recognizing += (s, e) => {
            Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
        };

        recognizer.Recognized += (s, e) => {
            var result = e.Result;
            Console.WriteLine($"Reason: {result.Reason.ToString()}");
            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                    Console.WriteLine($"Final result: Text: {result.Text}.");
            }
        };

        recognizer.Canceled += (s, e) => {
            Console.WriteLine(e.ErrorDetails);
            Console.WriteLine($"\n    Canceled. Reason: {e.Reason.ToString()}, CanceledReason: {e.Reason}");
        };

        recognizer.SessionStarted += (s, e) => {
            Console.WriteLine("\n    Session started event.");
        };

        recognizer.SessionStopped += (s, e) => {
            Console.WriteLine("\n    Session stopped event.");
        };

        // Starts continuous recognition. 
        // Uses StopContinuousRecognitionAsync() to stop recognition.
        await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

        do
        {
            Console.WriteLine("Press Enter to stop");
        } while (Console.ReadKey().Key != ConsoleKey.Enter);

        // Stops recognition.
        await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
        
    }*/