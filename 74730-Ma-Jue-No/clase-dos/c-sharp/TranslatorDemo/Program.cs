
using Azure.AI.Translation.Text;
using Azure;

String key = "5QdiL359JNug1j23ZUbH0D3NYWEYSDkvKR9UwaxmtYhVSBSWoZmWJQQJ99BDACYeBjFXJ3w3AAAAACOG7MUF";

TextTranslationClient client = new TextTranslationClient( new AzureKeyCredential(key), "eastus");

var traduccion = await client.TranslateAsync("en", "Este es un texto que quiero traducir", "es");
Console.WriteLine(traduccion.Value[0].Translations[0].Text);



