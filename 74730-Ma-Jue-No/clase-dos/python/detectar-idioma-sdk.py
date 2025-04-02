from azure.core.credentials import AzureKeyCredential
from azure.ai.textanalytics import TextAnalyticsClient

key = "xxxxxxxxxxxxx"
endpoint = "https://ai-102-clase-dos.cognitiveservices.azure.com/"
texto = "This is it. We are the champions. New York rules"

credential = AzureKeyCredential(key)
client = TextAnalyticsClient(endpoint=endpoint, credential=credential)
documents = [texto]
response = client.detect_language(documents = documents)

print(response)