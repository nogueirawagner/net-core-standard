# .NET CORE + DDD 
Projeto utilizando .NET Core 

Utilizando modelando a arquitetura em camadas
Camada de Apresentação
Camada de Serviços
Camada de Aplicação
Camada de Domínio
Camada de Dados
Camada de CrossCutting
Projeto de Testes Unity
Deploy
Virtualização com Docker

----
Escolhendo o tipo de projeto correto entre .NET Core e .NET Standard
Consulte: https://docs.microsoft.com/pt-br/dotnet/standard/net-standard

<strong>Standard:</strong> Aponta para a plataforma 'netstandard 1.4' aponta para uma compatibilidade full framework 4.6.1, podendo mudar a versão do .net standard. 
Irá unir .net core com o .net framework tradicional, e com certeza será facilmente migrada para o .net standard 2.0;

<strong>.NET Core:</strong> Possui necessidade de trabalhar ou fazer deploy da aplicação em alguma plataforma diferente da Windows? Se sim, então .NET Core
Se realmente precisa trabalhar entre multi-plataformas, trabalhar com microsservices para utilizar docker, azures, trabalhar baseado em containeres.
Precisa trabalhar com versões lado a lado, porém não terá suporte para alguns pacotes, pois a maioria dos pacotes já estão apontando pro .net core, 
mas dependendo do tipo de pacote, é importante avalir se tudo aquilo que vc precisa vai estar disponível em .net core. Caso contrário terá que esperar a biblioteca até migrar para o .net core.

<strong> 
Projeto utilizado neste projeto é um .net core, editado para apontar para o netstandard 1.6; A única coisa que muda é o target.
</strong>


