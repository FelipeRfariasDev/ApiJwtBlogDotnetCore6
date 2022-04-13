# .Net Core C# (6) ApiRestFull Swagger Autenticação JWT

1 -> A API deve implementar o verbo endpoint:

- POST /arquivos
  - Upload de um arquivo CSV separado por ; e os com nome e email, os registros devem ser inseridos na tabela Itens com relacionamento da tabela Arquivos que deve conter os arquivos que foram enviados e armazenados no diretório ApiJwtBlogDotnetCore6/wwwroot/uploadsCsv


2 -> Criar uma API que implementa o crud de posts com os seguintes campos:

- Id (Int) Autoincrement
- Titulo (String)
- Descricao (String)
- Imagem (File)
- DataCadastro (Date)

A API deve implementar os seguintes verbos e endpoint:

- GET /posts?offset=1&limit=2&buscar=tit
  - Lista todos os posts com paginação e a busca deve acontecer pelo Titulo ou Descricao.


- POST /posts
  - Cria um novo post com upload de imagem e envio de email ao registrar um novo post.
  - O Email deve conter o Titulo no assunto e no corpo do email a Descricao e Url da imagem que foi realizado o upload.


- PUT /post
  - Atualizar um novo post pelo id com upload de imagem e envio de email ao atualizar.
  - O Email deve conter o Titulo no assunto e no corpo do email a Descricao e Url da imagem que foi realizado o upload.

- GET /posts/id
  - Obtém um post específico por meio do Id


- DELETE /posts/id
  - Deleta um post especifico através do id informado


[Iniciar Video](https://www.youtube.com/watch?v=)
##### Autor > Felipe Rodrigues Farias

## Adionar via postmam e recebimento do email com upload da imagem

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/postman/add-postman.png?raw=true)

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/postman/add-postman-email.png?raw=true)

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/postman/add-postman-email-img-upload.png?raw=true)

Atualizar via postmam e recebimento do email com upload da imagem

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/postman/put-postman.png?raw=true)

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/postman/put-postman-email.png?raw=true)

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/postman/put-postman-email-img-upload.png?raw=true)


## Swagger


![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/swagger.png?raw=true)


## Teste Unitário

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/TesteUnit%C3%A1rio.png?raw=true)

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/TesteUnit%C3%A1rio2.png?raw=true)


![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/TesteUnit%C3%A1rio3.png?raw=true)

## Postaman
https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/Api%20Dotnet%20Core%206.postman_collection.json

https://www.getpostman.com/collections/3fe1cb971c191254ce8c

https://go.postman.co/workspace/Team-Workspace~ae3c3730-a225-4945-879f-78225a00b42d/collection/17591629-4596bf0f-9efa-4bf6-9391-2a6d2286a951?action=share&creator=17591629