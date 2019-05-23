# entitysearch
Busca por entidade Google e Bing

Foram criados 2 recursos "Cognitive Services" no Azure, 1 para Entity Search e outro para Web Search.

O Web Search faz uma busca simples, retornando informações e links sobre a query;

O Entity Search consegue identificar a query como um objeto, entidade, onde fornece informações mais precisas sobre aquilo. O problema é que a busca precisa ser de um objeto conhecido. Caso contrário, ele não retorna objeto algum.


Nome do recurso no Azure para **Web Search**: resource2bingsearch

Endpoint do Web Search: https://eastus2.api.cognitive.microsoft.com/

Nome do recurso no Azure para **Entity Search**: buscaentidade




## Outras API's de busca por entidade:
### DuckDuckGo:
https://api.duckduckgo.com/?q=Banco%20do%20brasil&format=json


### Google Knowledge Graph Search API:
https://kgsearch.googleapis.com/v1/entities:search?query=Facebook&key=AIzaSyBmujT4B-OlmSbq8sy6yvVyzda8rmvXDXw&indent=True&languages=pt

- Para este, foi habilitado no projeto **TreinoNuvem** a consulta a esta API em específico do Google.
Existem outras API's disponíveis no Google, por exemplo 'Cloud Machine Learning Engine', ver em:
https://console.developers.google.com/apis/dashboard?hl=pt-br&project=treinonuvem
