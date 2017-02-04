

go
Create database BDEscola
go

use BDEscola

go



create table Pais
(
  id int identity primary key,
  nome varchar(100) not null,
  
)
go
create table Estado
(
  id int identity primary key,
  id_pais int not null references Pais(id)on update cascade on delete cascade,
  sigla varchar(10) not null,
  nome varchar(100) not null,

)
go
create table Cidade
(
  id int not null primary key,
  nome varchar(100) not null,
  id_estado int not null references Estado(id)on update cascade on delete cascade,
  capital bit not null
  

)
go

create table Pessoa
(
   id int identity primary key,
   nome varchar(100) not null,
   data_nasc varchar(10),
   sexo varchar(20) not null,
   cpf varchar(20) ,
   rg varchar(20) not null unique,
   rua varchar(100) not null,
   bairro varchar(100) not null,
   complemento varchar(100),
   localidade int not null references Cidade(id)

)
go
create table Telefone
(
  id int not null primary key references Pessoa(id) on update cascade on delete cascade,

  tel_pessoal varchar(20) not null,
   tel_residencia varchar(20)
  
)

go

create table Aluno
(
  
  id int not null primary key references Pessoa(id)on update cascade on delete cascade,
  rm varchar(50) not null unique,
  ra varchar(50) not null unique,
  rne varchar(50) ,
  nome_pai varchar(100),
  nome_mae varchar(100),
  foto varchar(100),
  inf varchar(max)
 
)

go

create table Professor
(
  id int not null primary key references Pessoa(id)on update cascade on delete cascade,
  registr varchar(50) not null
)

go

create table Usuario
(
  id int not null primary key references Pessoa(id)on update cascade on delete cascade,
 email varchar(100) not null unique,
 senha varchar (MAX),
  permissao varchar(20) not null
)
--INSERT INTO Usuario (email, senha, permissao)
--VALUES ('teste@teste.com',PWDENCRYPT('senha_para armazenar'),adm)

--SELECT Codigo, email, Permissao
--FROM Usuario
--WHERE email = 'teste@teste.com'
--AND PWDCOMPARE('p$on_line', senha) = 'senha salva!'



--falta historico
go
create table Turma
(
  id int identity primary key,
  nome varchar(100) not null,
  periodo varchar(50) not null,
  desativado int
)

go

create table Disciplina
(
  id int identity primary key,
  nome varchar(100) not null,
  informacoes varchar(max)
   
)

go

create table r_Turma_Disc_Prof
(
  
  id_turma int not null,
  id_disciplina int not null,
  id_prof int not null ,
  data int ,
  desativado int,

  primary key(id_turma,id_disciplina,id_prof),
  foreign key(id_turma) references Turma(id) ,
  foreign key(id_disciplina) references Disciplina(id) ,
  foreign key(id_prof) references Professor(id) 

)

go


  create table status
(
  id	     int			not null primary key identity,
  descricao  varchar(100)   not null
)
go

create table Matricula
(
  id int identity ,
  id_aluno int not null  references Aluno(id) ,
  id_turma int not null references Turma(id) ,
  data int not null,
  desativado int not null,
   status int references status(id)
  primary key (id,data, desativado)
   
  
  )
  go
  
  create table Bimestre
  (
   id int identity primary key,
   nome varchar(50) not null,
   status int not null references status(id)
  )

  create table r_matr_r_Turma_Disc_Prof
  (

    id_matricula int not null ,
    id_prof int not null,
	id_turma int not null,
	id_disci int not null ,
	nota decimal(4, 2) not null,
	faltas int not null,
	id_bimestre int not null references Bimestre(id) ,
	data int not null,
	desativado int not null,

	primary key(id_matricula,data, id_turma,id_disci,id_bimestre),
	foreign key (id_turma,id_disci,id_prof) references r_Turma_Disc_Prof(id_turma,id_disciplina,id_prof),
	foreign key (id_matricula,data,desativado) references Matricula (id,data,desativado) 


	  )



	create table historico
(
	
	id_serie int not null ,
	id_aluno int not null references Aluno(id),
	id_cidade int not null references cidade(id),
	nome_escola varchar(100) not null,
		
	ano int not null,
	
	primary key(id_serie, id_aluno)
)

go 

create table Anotacoes
(
   id int not null references Aluno(id) primary key,
   Anotacao varchar(max) 

)

alter table Aluno add  status int not null references status(id)


	  select * from Aluno, Pessoa,Telefone
   select * from Aluno

  INSERT INTO  Pessoa VALUES('@nome','@data_nasc' ,'@sexo','@cpf','@rg','@rua','@bairro','@complemento','1')


  insert into Pais values('Brasil')
   insert into Estado values(1,'MS', 'Mato Grosso Do Sul')
   insert into Cidade values(2,'Dourados')

   select * from Pais p
       join Estado e on (p.id = e.id_pais)
	   join Cidade c on (c.id_estado = e.id)
	   Where e.nome = 'Sao Paulo'

   select nome , registr [r] from Pessoa p
			 join Professor u on (p.id = u.id)
			 join Telefone t on (p.id = t.id)
			 where u.rm like '5465465'			


			 Select * from Aluno 
                       Where rm like '5465465'

			Insert into Pessoa values ('Marcilio','1993-09-17','Masculino','123456','111111111','tal','tbtal',
                                'logo ali',1 )

			insert into Usuario values(32,'marcilio.93@hotmail.com','12345','ADM')
                               




 select * from Cidade where id_estado = 1

 select * from Estado

   drop table Cidade

   Select ci.id,ci.nome  from Estado e
   join Cidade ci on (e.id = ci.id_estado)

   where ci.id = 559

   select * from  Pessoa p join Aluno pr on (p.id = pr.id)
   join Telefone t on (p.id = t.id )
   join Cidade c on (p.localidade = c.id)
   where p.id =28

   select c.nome [cidade] ,e.nome [estado] from Pessoa p 
   join Cidade c on (p.localidade = c.id)
   join Estado e on (e.id = c.id_estado)
   where p.id =2

   delete Pessoa where id = 1
   select * from Pessoa

/*
   DELETE FROM  Telefone, Aluno, Pessoa	
 Using Telefone  
inner JOIN Aluno  
ON( Telefone.id =Aluno.id)
inner join Pessoa 
on (Pessoa.id = Aluno.id)
WHERE Aluno.rm Like '12132132132'
*/


SELECT * FROM Pessoa p
     Join  Professor pr on (p.id = pr.id)


	SELECT id, nome , informacoes [inf] FROM Disciplina





	SELECT * FROM Pessoa p Join Professor pr ON (p.id = pr.id)
     Join Telefone t ON (p.id = t.id)
      Where p.id = 28


	  select * from Usuario

	  Select * From Professor pr 
	  join Pessoa p on (p.id = pr.id)


	  select * from r_Turma_Disc_Prof

	  Select c.id [cidade] , e.id [estado] from Cidade c 
	  join Estado e on (c.id_estado = e.id )
	  where c.id = 1 and c.nome = ''


	  select * from Disciplina

	  select * from Aluno a join Pessoa p on (a.id = p.id)
	   
	  select * from  turma where nome Like'1 Série%'

	  select * from Bimestre
	  insert into Bimestre values('4 Bimester',1)
	   insert into status values('Desativado')
	   insert into status values('')

	   /*  select * from status

		m join Turma t 
	  on (m.id_turma = t.id) left join  r_Turma_Disc_Prof r 
	  on (t.id = r.id_turma)left join Disciplina d on 
	  (r.id_disciplina = d.id) 
	  where 


	  --select * from r_matr_r_Turma_Disc_Prof
	  -- select * from r_Turma_Disc_Prof
	
	   delete from Aluno

	   delete from Matricula where id=2
	   delete  from r_matr_r_Turma_Disc_Prof
	     delete  from r_Turma_Disc_Prof where id_disciplina = 5
	   alter table r_matr_r_Turma_Disc_Prof alter Column data int
	   alter table r_Turma_Disc_Prof Add Column data int not null
	   */
	   --select * from Turma t join Matricula m on (t.id = m.id_turma)
	   --where m.id_aluno = 1 and m.data = 2013

	   --delete from Turma

	   /*select * from Matricula m  join Turma t 
	  on (m.id_turma = t.id)   join  r_Turma_Disc_Prof r 
	  on (t.id = r.id_turma)  join Disciplina d on 
	  (r.id_disciplina = d.id)   join r_matr_r_Turma_Disc_Prof rl 
	  on (m.id = rl.id_matricula and rl.data = 2014)
	  where m.id= 2  and rl.data = 2014
	  delete from s

	  select * from Disciplina 

	  select * from r_matr_r_Turma_Disc_Prof rl
	  join r_Turma_Disc_Prof r on ( rl.id_disci = r.id_disciplina )
	 join Disciplina d on ( r.id_disciplina = d.id)
	 join Turma t on r.id_turma = rl.id_turma
	 join Bimestre b on rl.id_bimestre = b.id
	  
	   where rl.id_matricula = 11 and (r.desativado = 0 or r.desativado > 2013) and t.id = 7 and b.id = 1


	   select * from r_matr_r_Turma_Disc_Prof r 
	   where r.id_matricula = 3 and r.id_disci = 1

	   select * from r_matr_r_Turma_Disc_Prof r 
	   join Turma t on r.id_turma = t.id 
	   where r.data = 2015 and t.id = 1



	    select * from r_matr_r_Turma_Disc_Prof r
	 join Matricula m on r.id_matricula = m.id 
	   where r.id_matricula = 5

 
	  select * from  r_Turma_Disc_Prof rt 
	   join Turma t on rt.id_turma = t.id
	   join Matricula m on m.id_turma = t.id 
	   where m.id = 4 and t.id = 2 and rt.id_disciplina = 2 and (rt.desativado = 0 or rt.desativado > 2013)

	   select * from Turma t 
	   join r_Turma_Disc_Prof r on t.id = r.id_turma
	   join Disciplina d on r.id_disciplina = d.id
	   where t.id = 8


	   select * from Matricula where id_turma = 8

	   select p.nome from Matricula m
	   join Aluno a on m.id_aluno = a.id
	   join Pessoa p on a.id = p.id
	   where m.id_aluno = 5

	   select * from r_Turma_Disc_Prof r 
	   join Professor p on r.id_prof = p.id
	   where r.id_turma = 1 and r.id_disciplina = 2

	   select * from r_Turma_Disc_Prof r 
	   join Disciplina p on r.id_disciplina = p.id
	   where r.id_turma = 8 and r.id_prof = 1


	   ALTER TABLE historico
ADD 


--select avg(nota) as Media from r_matr_r_Turma_Disc_Prof  where id_matricula = 14 and id_disci = 3 and desativado !=2013

--select distinct r.id_matricula from r_matr_r_Turma_Disc_Prof r where r.id_turma = 8 and (r.desativado = 0 or r.desativado > 2013)
--select * from r_matr_r_Turma_Disc_Prof r where r.id_turma = 8 and (r.desativado = 0 or r.desativado > 2013) and r.id_matricula =14

--select distinct r.id_disci from r_matr_r_Turma_Disc_Prof r where r.id_turma = 8 and (r.desativado = 0 or r.desativado > 2013) 

--select distinct d.nome from r_matr_r_Turma_Disc_Prof r join Disciplina d on r.id_disci = d.id where r.id_turma = 8 and (r.desativado = 0 or r.desativado > 2013) 


--select distinct a.id from aluno a join Matricula m on a.id != m.id_aluno


--select * from Cidade c join Estado e on c.id_estado = e.id where c.nome like 'Sao Paulo' and e.sigla like 'SP'

--select * from historico

*/