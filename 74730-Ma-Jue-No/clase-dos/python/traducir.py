import requests, json

key = "xxxxx"
endpoint = "https://api.cognitive.microsofttranslator.com/"

headers = {
    'Ocp-Apim-Subscription-Key': key,
    'Ocp-Apim-Subscription-Region': 'eastus',
    'Content-type': 'application/json',
}

body = [{ "text" : "Este es un ejemplo de texto que quiero traducir al ingles"}]

response = requests.post(endpoint + "/translate?api-version=3.0&from=es&to=en", headers=headers, json=body)

print(response.json())