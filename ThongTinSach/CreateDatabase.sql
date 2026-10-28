create database DuLieu;

create table CongViec(
	MaSach nvarchar(15) primary key ,
	TenSach nText NOT NULL,
	GiaTien nvarchar(12) not null
);

insert into CongViec(MaSach,TenSach,GiaTien) values (N'S001',N'Lập trình',N'180');