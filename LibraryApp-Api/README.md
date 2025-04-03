## LibraryApp
# Descrição
O LibraryApp é uma aplicação Web API desenvolvida em C# que implementa um sistema de gerenciamento de biblioteca (CRUD). O projeto foi desenvolvido seguindo os princípios de arquitetura limpa e boas práticas de desenvolvimento de software, como DDD (Domain-Driven Design) , CQRS (Command Query Responsibility Segregation) , SOLID , injeção de dependência e testes unitários .

Com esta API, é possível realizar operações básicas de criação, leitura, atualização e exclusão de livros em uma biblioteca virtual. A aplicação utiliza SQL Server como banco de dados e foi projetada para ser escalável e testável.

# Estrutura do Projeto
O projeto está organizado em módulos separados para garantir uma arquitetura limpa e modular.

1. Domain:
   - Contém as entidades, agregados e interfaces de repositório. Representa o núcleo da lógica de domínio.

2. Application:
   - Implementa os casos de uso da aplicaçãoo usando padrões como CQRS.

3. Infrastructure:
   - Contém implementações concretas dos repositórios e configuração do banco de dados com EntityFrameworkCore.
  
4. CrossCutting: 
   - Configura aspectos transversais, como injeção de dependência.

5. Api:
   - Camada de API RESTful que expõe os endpoints para interação com o sistema.
  
6. Tests:
   - Testes unitários implementados com xUnit para validar a lógica de negócios e os comportamentos esperados.

# Tecnologia utilizada
- ASP.NET Core 9 : Framework para desenvolvimento da API Web.
- EntityFrameworkCore: ORM utilizado para interação com o banco de dados SQL Server.
- SQL Server: Banco de dados relacional para armazenamento dos dados da aplicação.
- xUnit: Framewor de testes unitários para validar a funcionalidade do sistema.
- CQRS: Padrão utilizado para separar operações de leitura e escrita.
- Dependency Injection: Injeção de dependência configurada no módulo CrossCutting para facilitar a manutenção e testabilidade.
- Swagger/OpenAPI: Documentação interativa da API para facilitar os testes e integraçoes.

# Como Executar o Projeto
Pré-requisitos
- .NET SKD 9
- SQL Server 2022 instalado e configurado
- Ferramenta Postmane ou Swagger apra testar os endpoints

# Passos
1. Clone o repositório:<br>
git clone https://github.com/seu-usuario/LibraryApp.git<br>
cd LibraryApp<br>

2. Configura a string de conexão no arquivo appsettings.json:
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

3. Execute as migrações do EntityFrameworkCore:
dotnet ef database update --project LibraryApp.Infrastructure --startup-project LibraryApp.WebAPI

4. Execute a aplicação:
dotnet run --project LibraryApp.Api

5. Acesse a documentação da API via Swagger:
https://localhost:5002/swagger/index.html

6. Endpoints Disponíveis

GET<br>
curl --location 'https://localhost:5002/api/Book' \
--data ''

POST<br>
curl --location 'https://localhost:5002/api/Book' \
--header 'Content-Type: application/json' \
--data '{
    "title": "Clean Code",
        "author": "Robert C. Martin",
        "year": 2008
}'

GET ID<br>
curl --location 'https://localhost:5002/api/Book/1' \
--data ''

PUT<br>
curl --location --request PUT 'https://localhost:5002/api/Book/1' \
--header 'Content-Type: application/json' \
--data '{
    "id": 1,
    "title": "Clean Code 2",
    "author": "Robert C. Martin",
    "year": 2008
}'

DELETE<br>
curl --location --request DELETE 'https://localhost:5002/api/Book/id?id=1' \
--header 'Content-Type: application/json' \
--data '{
    "id": 1,
    "title": "Clean Code 2",
    "author": "Robert C. Martin",
    "year": 2008
}'