# .Net Core C# (6) ApiRestFull Swagger Autenticação JWT

Criar uma API que implementa o crud de posts com os seguintes campos:

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
- GET /posts/id
  - Obtém um post específico por meio do Id
- PUT /post
  - Atualizar um post pelo Id com upload de imagem e envio de email ao realizar a operação.
- DELETE /posts/id
  - Deleta um post especifico através do id informado
- POST /arquivos
  - Upload de um arquivo CSV separado por ; e os com nome e email, os registros devem ser inseridos na tabela itens com relacionamento da tabela Arquivos que deve conter os arquivos que foram enviados.

[Iniciar Video](https://www.youtube.com/watch?v=)
##### Autor > Felipe Rodrigues Farias

![alt text](https://github.com/FelipeRfariasDev/ApiJwtBlogDotnetCore6/blob/main/Documenta%C3%A7%C3%A3o/swagger.png?raw=true)

