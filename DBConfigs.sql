SET GLOBAL  max_allowed_packet=1024*1024*1024;

DROP VIEW IF EXISTS zapatosyexists; -- "OR REPLACE"

create view zapatosyexists as 
	select zapatos.idZapato , zapatos.Codigo, 
	(select Marca from marcas where zapatos.idMarca = marcas.idMarca ) as Marca, zapatos.Modelo, zapatos.Tacon,
	(select SUM(Existencia) from tallas where tallas.idZapato = zapatos.idZapato) as Existencia 
	from zapatos;