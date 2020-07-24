USE WSTower_app

select * from Usuario;
SELECT * FROM TipoDeIngresso;
SELECT * FROM FormaDePagamento;
SELECT * FROM Jogos;
SELECT * FROM Times;
SELECT * FROM Estadio;
SELECT * FROM CompraIngressos;
SELECT * FROM IngressosVendidos;


INSERT INTO Usuario(Nome,Email,NomeUsuario,Senha,Acesso)
VALUES('Pedro alves da silva','pedro@gmail.com','PedroAlves','pedro123',1),
	('maria alves da optus','maria@gmail.com','mariaAlves','maria123',0),
	('Joao alves da max','joao@gmail.com','jogoa123','joao123',0),
	('diego alves da silva','diego@gmail.com','diegoAlves','diego123',0),
	('joaquina alves da pedroso','joaquina@gmail.com','joaquinaAlves','joaquina123',0);


INSERT INTO TipoDeIngresso(Tipo_de_Ingresso,Valor)
VALUES('Camarote',210.00),
('Cobertura',120.00),
('Arquibancada (Sem cobertura)',60.00),
('Camarote VIP',320.00),
('Camarote VIP II',450.00);


INSERT INTO FormaDePagamento(Forma_de_Pagamento)
VALUES('Cartão de credito'),
('Boleto'),
('Cartão de débito'),
('Transferência bancaria'),
('Cartão fiel torcedor');

INSERT INTO Times(Nome)
VALUES('Corinthians'),
('Coritiba'),
('Cruzeiro'),
('Botafogo'),
('São Paulo');

INSERT INTO Estadio(Nome,Endereco,QuantidadeDeLugares)
VALUES('Maracanã','Av. Pres. Castelo Branco, Portão 3, Rio de Janeiro',78.838),
('Morumbi','Praça Roberto Gomes Pedrosa, 1, São Paulo',72.039),
('Castelão','Av. Alberto Craveiro, 2901, Fortaleza',63.903),
('Arena do Grêmio','Av. Padre Leopoldo Brentano, 110, Porto Alegre',55.662),
('Arena Corinthians','Av. Miguel Ignácio Curi, 111, São Paulo',45.000);


INSERT INTO Jogos(Horario,IdTimeCasa,IdTimeVisitante,IdEstadio,Detalhes)
VALUES('20-10-20 20:30',1,2,2,'Uma partida emocionantes de ver'),
('20-10-16 20:30',4,5,5,'Uma partida transmitida na rede globo'),
('19-09-20 16:00',1,3,3,'Revanche de gigantes no Castelão'),
('20-12-20 20:00',5,2,1,'Só crack nesse jogo, lindo de ver compra seu ingresso veja você mesmo'),
('01-01-21 21:00',2,3,4,'Partida vai se inesquecivel para os torcedores fanaticos');


INSERT INTO CompraIngressos(Quantidade,Valor,IdFormaDePagamento,IdUsuario,IdTipoDeIngresso,IdJogo)
VALUES(1,210.00,1,2,1,2),
(2,120.00,3,5,3,1),
(3,1350.00,3,4,5,5),
(1,320.00,5,4,4,3),
(6,720.00,5,1,2,4);

INSERT INTO IngressosVendidos(NumeroDoIngresso,IdCompra)
VALUES('FD43RE',1),
('EWEWFWK',2),
('EWWIEIW',2),
('SAJDSHD3',3),
('RJEREN12',3),
('DSIEIU2',3),
('FKDFJDU',1),
('SAUDT32',5),
('3283JGD',5),
('DJSDUS3',5),
('LDSI32',5),
('EWOE82',5),
('EW8EHOEW',5);