## WebApp
Este projeto representa uma Web API RESTful construída com ASP.NET Core. Seu principal objetivo é fornecer dados e funcionalidades através de endpoints HTTP bem definidos.<br>

#### Finalidade
Expor informações e/ou realizar operações específicas para serem consumidas por outros aplicativos (como o BFF, aplicações web front-end, aplicativos mobile, etc).<br>

#### Tecnologia
Desenvolvido utilizando o framework .NET e a arquitetura ASP.NET Core, oferecendo performance, escalibilidade e um modelo de desenvolvimento robusto.<br>

#### Padrão
Adota o padrão REST (Representational State Transfer), utilizando verbos HTTP(GET, POST, PUT, DELETE) para interagir com os recursos expostos.<br>

#### Formato de dados
Geralmente utiliza o formato JSON para a troca de dados entre a API e os clientes.<br>

#### Endpoints
Expõe um ou mais endpoints (URLs) que representam os recursos disponíveis. Cada endpoint pode aceitar diferentes verbos HTTP para realizar diferentes ações.<br>

#### Exemplo
O endpoint /WeatherForecast retorna uma previsão do tempo simulado.<br>

#### Desenvolvedores
Esta API serve como a camada de dados e lógica de negócioas do nosso sistema. Outros aplicativos (como o BFF) farão requisições para esta API para obter ou manipular informações. Qualquer alteração na lógica de negócios principal ou no acesso aos dados geralmente ocorrerá neste projeto.

#### Utilização desta API
#### * Consultar a documentação da API (geralmente gerada via Swagger/OpenAPI) para entender os endpoints disponíveis, os parâmetros esperados e os formatos de resposta.<br>

#### * Utilizar um cliente HTTP (como postman, insomnia, etc) para interagir com os endpoints da API.


#### Curl
curl --location 'https://localhost:7022/weatherforecast'