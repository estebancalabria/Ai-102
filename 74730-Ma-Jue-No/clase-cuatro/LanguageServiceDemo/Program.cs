using Azure.AI.Language.Conversations;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;
using System.Text.Json;

String endpoint = "https://languaje4trainner.cognitiveservices.azure.com/";
String keys = "xxxxxxxxxxxxxxxxxxxxxxxxxxx"; // Replace with your key

ConversationAnalysisClient client = new ConversationAnalysisClient(new Uri(endpoint), new AzureKeyCredential(keys));

Console.WriteLine("Insert your question: ");
String question = Console.ReadLine()!;

 String projectName = "Clock";
 String deploymentName = "prod";
 var data = new
 {
     analysisInput = new
     {
         conversationItem = new
         {
             text = question,
             id = "1",
             participantId = "1",
         }
     },
     parameters = new
     {
         projectName,
         deploymentName,
         // Use Utf16CodeUnit for strings in .NET.
         stringIndexType = "Utf16CodeUnit",
     },
     kind = "Conversation",
 };

Response response = client.AnalyzeConversation(RequestContent.Create(data));
Console.WriteLine(JsonSerializer.Serialize(JsonDocument.Parse(response.Content.ToString()).RootElement, new JsonSerializerOptions { WriteIndented = true }));
dynamic jsonRespuesta = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
String intent = jsonRespuesta.result.prediction.topIntent;

String location = "Desconocida";
foreach (dynamic entity in jsonRespuesta.result.prediction.entities) {
    if (entity.category == "Location") {
        location = entity.text;
        break;
    }
}


Console.WriteLine($"Intent = {intent}");
Console.WriteLine($"Location = {location}");

//if (intent == "GetTime") {
//    ...
//}