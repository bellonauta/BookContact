# Agenda de contatos

Uma API para manutenção/CRUD de uma agenda de contatos.
Uma visão de desenvolvimento utilizando principalmente as metodologias DDD e
Design Patterns, baseada na série de vídeos do treinamento de "backends robustos" do
Andre Baltieri. Se interessar, veja o primeiro vídeo em: 
https://www.youtube.com/watch?v=9rHQfspuAFM&list=PLTMuY7ptzFISS-rK8alGtUKqco4vrg2B-&index=11&ab_channel=AndreBaltieri

---
## Dependências
- C#
- dotNet >= 5.0.32
- Entity Framework 6.4.4
- AspNet Cors 5.2.7
- AspNet WebApi 5.2.7
- Owin 4.2.0
- MS SQL Server

---
## Publicação
- Faça o deploy e ative o serviço "BookContactControl.Api", da solução.

---
## Consumo
- Obter token de autorização de consumo:
	Request tipo "POST" para "url_da_api/security/token".
	Headers: 
		Content-type : application/x-www-form-urlencoded.
	Parâmetros:
		grant_type : "password";
		username   : "seu_username_recebido" (No momento, coloque um e-mail qualquer).

- Inclusão de contato: 
	Request tipo "PUT" para "url_da_api/insert";
	Headers:
		Authorization : "bearer access_token_recebido";		
		Content-type  : application/json.
	Parâmetros:
	headers: 
	    Email : Conta de e-mail do contato (Key);
		Nome  : Nome do contato;
		Phone : Número do celular do contato;

- Alteração de contato: 
	Request tipo "POST" para "url_da_api/update".
	Headers:
		Authorization : "bearer access_token_recebido";		
		Content-type  : application/json.
	Parâmetros:
	headers: 
	    Email : Conta de e-mail do contato (Key);
		Nome  : Nome do contato;
		Phone : Número do celular do contato.

- Lista de contatos: 
	Request tipo "POST" para "url_da_api/list"
	Headers:
		Authorization : "bearer access_token_recebido";		
		Content-type  : application/json.
	Parâmetros:
	headers: 
	    Skip : Contatos a ignorar no início(conforme Order)
		Take : Quantidade de contatos para retorno
		Order : "pk" = Ordem ascendente das contas de e-mails dos contatos(Default);
		        "asc" = Ordem ascendente dos nomes dos contatos;
				"desc" = Ordem descendente dos nomes dos contatos.

---
## ToDo
- Adicionar controle de status de contato na agenda;
- Adicionar endereço do contato na agenda;