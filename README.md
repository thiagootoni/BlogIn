# BlogIn

O BlogIn é um projeto de Blog desenvolvido em Asp.Net Core, como forma de aprendizado da disciplina de programação C# web, na plataforma Aps.Net.

A ideia é trabalhar conceitos de Orientação a Objetos com a utilização de frameworks como Entity aplicando conceitos de MVC.

A estrutura será criada em cima das seguintes regras de negócio:

O blog terá usuários, os quais poderão escrever posts e avaliar posts de outros usuários, os posts poderão ser salvos para leitura posterior e poderão ser avaliados com "like" e poderão receber comentários.

As postagens terão um sistema de versão/revisão, e como dito anteriormente, terão classificação de gostei/não gostei e comentários. Elas serão classificadas de acordo com categorias e terão tags para facilitar a busca de interessados no assunto.

De maneira tópica, as regras de negócio, são:

-----------------------------------------------------------------------------
Usuários podem ser Autores ou Administradores

Administradores podem gerenciar Autores
Administradores podem gerenciar Categorias
Administradores podem gerenciar Etiquetas

Autores podem gerenciar Postagens próprias
Autores podem gerenciar Comentários em Postagens próprias

Postagens devem ser alocadas em Categorias
Postagens possuem Revisões
Revisões são criadas para cada edição nas Postagens
Postagens podem receber Etiquetas
Postagens podem receber Comentários pelos Visitantes
Postagens podem receber Classificações pelos Visitantes

Visitantes podem buscar por Postagens
Visitantes podem compartilhar Postagens

-----------------------------------------------------------------------------
