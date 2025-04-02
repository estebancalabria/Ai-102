import http.client, base64, json, urllib

key = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
endpoint = "https://ai-102-clase-dos.cognitiveservices.azure.com/"
texto = "Este texto esta en castellano y quiero que el servicio de azure me diga en que lenguaje esta correctamente"

#print(endpoint.rstrip("/").replace("https://",""))

conn = http.client.HTTPSConnection(endpoint.rstrip("/").replace("https://","") )

headers = {
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': key,
}

jsonBody = {
    "documents": [
        {
            "id": "1",
            "text": texto
        }
    ]
}

conn.request("POST", "/text/analytics/v3.1/languages?", str(jsonBody).encode("utf-8"), headers)

resp = conn.getresponse()
data = resp.read()
print(data.decode("utf-8"))