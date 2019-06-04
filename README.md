# Arctouch.CodeChallenge
Live do projeto: [UpcomingMovies](https://d11xeajcmehuq7.cloudfront.net/)
## Detalhamento técnico
- Aplicação totalmente Serverless, hospedada na Amazon Web Services, utilizando CloudFront, API Gateway e AWS Lambda
- Backend em .Net Core 2.1

## Front-end
Front-end em Single Page Application, hospedado em AWS S3 e distribuído via AWS CloudFront (CDN)
- Front montado com Vue.js, utilizando Vue-router para carregar dinâmicamente os componentes 
de acordo com a rota
- Utilizei Less para estilizar a aplicação
- Utilixei Webpack como bundler
- Criei componentes em vue e reaproveitei eles, para manter a aplicação o menor possível 

``` bash
#Configurações do Vue.js: 

# instalar dependências
npm install

# serve com hot reload at localhost:8080
npm run dev

# build para produção com minify
npm run build
```

## Back-end
Back-end Serverless, utilizando .net Core como framework, API Gateway para expor o Lambda e AWS Lambda
para executar as funções.
Utilizei arquitetura em camadas, com pattern DDD, onde os serviços são injetados via Injeção de dependência.

Cada uma da 3 ações do usuário é uma função Lambda, sendo elas:
- Arctouh.CodeChallenge.Tmdb.UpcomingMovies, responsável por coletar os filmes UPCOMING da TMDB. Recebe por parâmetro a página.
- Arctouh.CodeChallenge.Tmdb.Search, responsável por buscar os filmes de acordo com a pesquisa do usuário. Recebe por parâmetro a página e o parâmetro de pesquisa.
- Arctouh.CodeChallenge.Tmdb.MovieDetails, responsável por coletar os detalhes do filme para exibir ao usuário. Recebe por parâmetro o id do filme.

3 Serviços foram criados, sendo eles:
- TmdbHttpClientServices, o qual realiza as chamadas Http para a API da Tmbd. Tem exposto um método GET. Nele, adiciono a API Key e a rota base, deixando essas informações privadas.
- JsonServices, responsável pela deserialização do retorno da Tmdb. Possui lógica para tratar os códigos Http.
- TmdbServices, o qual chama os anteriores e é exposto para os Lambdas
