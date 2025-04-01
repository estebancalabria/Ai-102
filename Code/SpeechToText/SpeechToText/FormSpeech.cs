using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Intent;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace SpeechToText
{
    public partial class FormSpeech : Form
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);

        public FormSpeech()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            SpeechConfig speechConfig = SpeechConfig.FromSubscription("f8fa8f5cb07541579fc0e0890c2899c3", "eastus");
            speechConfig.SpeechRecognitionLanguage = "es-AR";
            AudioConfig audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            IntentRecognizer recognizer = new IntentRecognizer(speechConfig, audioConfig);

            recognizer.Recognized += Recognizer_Recognized;
            await recognizer.StartContinuousRecognitionAsync();

            /*var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = CancellationDetails.FromResult(result);
                MessageBox.Show(cancellation.Reason.ToString() + "  " + cancellation.ErrorDetails);
            }


            TextBox.CheckForIllegalCrossThreadCalls = false;
            this.textBox1.Text += result.Text;
            //String texto = result.Text;
            //MessageBox.Show(texto);*/
        }

        private void Recognizer_Recognized(object? sender, IntentRecognitionEventArgs e)
        {
            this.textBox1.Text += e.Result.Text;
        }


    }


}
