/*tbl_personas*/
create table tbl_clientes
(
id int primary key auto_increment,
primer_nombre varchar(50) not null,
segundo_nombre varchar(50),
apellidos varchar(100) not null,
identificacion varchar(50) unique not null,
correo varchar(50) ,
estado  bool not null
);

INSERT INTO tbl_clientes (primer_nombre, segundo_nombre, apellidos, identificacion, correo, estado)
VALUES ('Juan', 'Esteban', 'Perez', '1234567890', 'juan.perez@iroute.com.ec', 1);

INSERT INTO tbl_clientes (primer_nombre, segundo_nombre, apellidos, identificacion, correo, estado)
VALUES ('Juan', 'Alberto', 'Perez', '2234567890', 'pedro.perez@iroute.com.ec', 0);

INSERT INTO tbl_clientes (primer_nombre, apellidos, identificacion, correo, estado)
VALUES ('Juan', 'De los Palotes', '3334567890', 'perico.delospalotes@iroute.com.ec', 1);



