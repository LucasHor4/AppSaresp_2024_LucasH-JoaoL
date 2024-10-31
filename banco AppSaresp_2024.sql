drop database dbSaresp_2024;
create database dbSaresp_2024;
use dbSaresp_2024;

create table tbprofessorAplicador(
IdProfessor int primary key auto_increment,
Nome varchar(100) not null,
CPF bigint not null,
RG decimal(9,0) not null,
Telefone bigint not null,
DataNasc date not null
);

create table tbaluno(
IdAluno int primary key auto_increment,
Nome varchar(100) not null,
Email varchar(200) not null,
Telefone bigint not null,
Serie varchar(200) not null,
Turma varchar(50) not null,
DataNasc date not null
);
select * from tbprofessorAplicador;
describe tbprofessorAplicador;
describe tbaluno;
