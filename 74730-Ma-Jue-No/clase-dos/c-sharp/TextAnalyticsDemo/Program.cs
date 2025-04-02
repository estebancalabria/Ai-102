using Azure;
using Azure.AI.TextAnalytics;

String endpoint = "https://ai-102-clase-dos.cognitiveservices.azure.com/";
String key = "5QdiL359JNug1j23ZUbH0D3NYWEYSDkvKR9UwaxmtYhVSBSWoZmWJQQJ99BDACYeBjFXJ3w3AAAAACOG7MUF";
String texto = "Este es un texto que quiero saber en que idioma esta";

AzureKeyCredential credential = new AzureKeyCredential(key);
TextAnalyticsClient client = new TextAnalyticsClient(new Uri(endpoint), credential);

var lenguaje = client.DetectLanguage(texto);
Console.WriteLine($"El idioma es: {lenguaje.Value.Name}");