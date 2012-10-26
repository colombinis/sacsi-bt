/*SCRIPT PARA LIMPIAR LA BASE Y EMPEZAR DESDE 0*/
--TABLAS DEBERIA ESTAR precargadas
select * from tbl_momento
select * from tbl_doc_x_momento
select * from tbl_vinculo
select * from tbl_tipoEmpresa
select * from tbl_estadoEmpresa
select * from tbl_estadocuota
select * from tbl_valorConocimiento
select * from tbl_Conocimiento
select * from tbl_Documento
select * from tbl_tipoDoc
select * from tbl_especialidad

--Limpiar la base de datos
delete from tbl_empresa
delete from tbl_doc_x_empresa
delete from tbl_cuotasEmpresa
delete from tbl_busqueda
delete from tbl_conocimiento_x_postulante
delete from tbl_RelacionPostulante_Empresa
delete from tbl_postulante_x_busqueda
delete from tbl_postulante
delete from tbl_domicilios_x_postulante