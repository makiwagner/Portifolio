## MeuBff

Este projeto implementa o padrão Backend For Frontend (BFF), atuando como uma camada intermediária entre uma ou mais aplicações cliente(por exemplo, um aplicativo web front-end) e uma ou mais APIs backend.

#### Finalidade
Simplificar e otimizar a comunicação entre os aplicativos cliente e as APIs backend. Ele agrega dados, transforma respostas e expõe uma intereface mais amigável e específica para as necessidades do cliente.<br>

#### Tecnologia
Construído com ASP.NET Core, aproveitando seus recursos para criar uma aplicação web que se comunica com outras APIs.

#### Padrão BFF
Adota o padrão BFF para resolver problemas como a complexidade de múltiplas chamadas de API diretamente do cliente, a necessidade de adaptar dados para diferentes interfaces e a preocupação com a segurança ao expor detalhes internos das APIs backend.<br>

#### Orquestração
O BFF pode orquestrar chamadas para múltiplas APIs backend, combinando os resultados em uma única resposta para o cliente.

#### Transformação
Ele pode transformar os dados recebidos das APIs backend para um formato mais conveniente para o consumo pelo cliente específico.

#### Segurança
O BFF pode centralizar a lógica de autenticação e autorização para o cliente, protegendo as APIs backend de acesso direto e potencialmente expondo apenas os dados necessários.

#### Comunicação com a API Backend
Este BFF se comunica com a WebApi (rodando em https://localhost/7022/ no nosso exemplo) para obter os dados necessários.

#### Para desenvolvedores
Este projeto serve como a ponte entre a interface do usuário e os serviços backend. As mudanças relacionadas à apresentação dos dados ou à lógica específica da interface do usuário geralmente ocorrerão aqui. O BFF ajuda a desacoplar o front-end do back-end, permitindo que cada parte evolua de forma mais independente.

### Utilização do BFF
#### * Consultar os endpoints expostos por este BFF. Eles são projetados para atender às necessidades específicas do(s) cliente(s) que ele serve.<br>

#### * Entender como este BFF consome os dados da(s) API(s) backend e como ele os transforma antes de retornar para o cliente.<br>

#### * Qualquer lógica de apresentação ou adaptação de dados para a interface do usuário estará principalmente localizada neste projeto.



Endpoint
curl --location 'https://localhost:7016/api/meubff/data'
