/*
DELETE FROM [dbo].[Customer];

DBCC CHECKIDENT ([Customer], RESEED, 0);

INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ABANTO INTERNACIONAL','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009000','ABASTECEDORA DE FIERRO Y ACERO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ACERO Y PVC','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10000202','ACEROS ALI, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007600','ACEROS ALTURA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10000300','ACEROS CONSOLIDADA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10006500','ACEROS FESA SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10000400','ACEROS GENERALES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007800','ACEROS INOXIDABLES ASA SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007400','ACEROS INOXIDABLES Y ALEACIONES IG S A DE C V','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10000600','ACEROS MEXICO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ACEROS PALMEXICO','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10000700','ACEROS ROCO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10000800','ACEROS ROSCADOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10000900','ACEROS TEPOTZOTLAN, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10001000','ACEROS TOCA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10008700','ACEROS TUBOS Y PERFILES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10001100','ACEROS Y METALES RECUPERADOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10001200','ACEROS Y TUBOS VILLALI, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10005800','ACEROS Y VALVULAS DEL NORTE S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10000500','ACEROTEK, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ALINEA CONSULTORES','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10008900','ALTOS HORNOS DE MEXICO, S.A.B. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007100','ANRO SERVICIOS INTEGRALES S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10001302','ASESORIA Y VENTA DE ACERO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10001402','AYANTE S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10006800','BOREAS, SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','C-3','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10008100','CAI ESPECTACULARES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','CASA SOMMER','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10001502','CENTRO LOGISTICO INTERMODAL DE MANZANILLO, S.A. DE C.V.,','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','CETSA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','CIATEQ Q BQ','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10005000','COM DE ACEROS MAT Y HTS IND SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10001701','COMERCIAL DE ACERO Y SERVICIOS INDUSTRIALES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10001802','COMERCIAL DE TUBOS DEL BAJIO S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009300','COMERCIAL INDUSTRIAL DE ACEROS Y TUBOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10008200','COMERCIAL INDUSTRIAL Y VALVULAS S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','COMERCIALIZADORA DEL GOLFO','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10001900','COMERCIALIZADORA INTERNACIONAL MORELOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','COMERCIALIZADORA ITEK','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10005600','COMPUGRAFIC, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007700','CONSTRUCTOR Y PROVEEDOR DEL BAJIO SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10005700','CONTROL INDUSTRIAL FORZA, S.C. DE R.L. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10005400','DESIGN EXPRESS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007400','DESIGN PRINT, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007200','DG CONSTRUCCION EFECTIVA S A DE C V','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10005900','DISTRIBUIDORA HIDRAULICA BEGA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','DISTRIBUIDORA MAJUM','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002000','ELECTROMECANICA INGENIERIA Y SERVICIO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ERKA PUBLICIDAD','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ERMI RESTAURACIONES','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002100','ESPINOZA AGUILAR CONSTRUCCIONES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10008100','ETISA DE GUADALAJARA S A DE C V','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','C&F IMPLEMENTOS Y SERVICIOS HIDRAULICOS SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007900','FABRICANTES Y MONTAJES INDUSTRIALES','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','FAPCO PARTS','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002201','FERRECABSA, S.A. DE C..V','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10006000','FERREPACIFICO CORPORACION SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10006300','FERRETODO MEXICO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','FERRO DE OCCIDENTE','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002200','FORZA STEEL, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','GD INTERNACIONAL','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','GEOTECH CONSTRUCCIONES','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10006500','GERARDO SANCHEZ GARCIA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002300','GLOBAL DE ACEROS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','GOMAR COMERCIALIZADORA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004800','GRUPO COMERCIAL TAJSA S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009400','GRUPO CONSTRUCTOR INDUSTRIAL GRUCOIN,S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','GRUPO INDUSTRIAL FERRETZ','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','GRUPO INGENIEROS MEXICANOS ASOCIADOS SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007000','GRUPO LOGISTICO INTERMODAL PORTUARIO,S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004800','H & R TUBERIAS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009800','IMPORTACIONES Y DESARROLLOS INDUSTRIALES, S.A.DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10005600','INDUSTRIAL TORREON S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002600','INOVACION Y ESTRUCTURAS PUBLICITARIAS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','INOXIDABLES BEST SUPPLY SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004600','INOXIDABLES NUEVA IMAGEN SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007300','JAIME ALMARAZ RAMIREZ','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10005700','JAIME RODRIGUEZ GODINEZ','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10008300','JESUS VILLARREAL VIDAÑA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007500','JOIST ESTRUCTURAS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002700','JORGE AMEZQUITA GALINDO','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10006300','JOSE ARTURO ORTIZ RANGEL','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10002502','LA FERRE COMERCIALIZADORA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002800','LIC. JORGE CESAR TORRES ALANIS','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003600','LIC. RANULFO III RODRIGUEZ VILLARREAL','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10005300','LUIS ALBERTO CASILLAS GUZMAN','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10005000','MANUEL MARTIN CANTU GUAJARDO','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007700','MARTINEZ RANGEL TECNICOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','MATERIALES INDUSTRIALES DE COATZACOALCOS SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10006900','MATERIALES INDUSTRIALES DE MEXICO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','MATERIALES INDUSTRIALES DE MONTERREY','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10002900','MATERIALES INDUSTRIALES DEL BAJIO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10000102','MATERIALES INDUSTRIALES DEL SURESTE, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003000','MEXICROM, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009600','MINERALES MONCLOVA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','MM TUBOS PARA AGUA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004502','MULTIPERFILES, S.A.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','OPERADORA CICSA, SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ORGANIZACIÓN COMERCIAL ATLAS SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10006100','OSCAR ISRAEL GARCIA OCHOA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10006600','OUTDOOR COMPANY DE MEXICO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10003102','PERFI TUBOS Y ACCESORIOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004404','PETRA DURAN VAZQUEZ','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007300','PLOMERIA INDUSTRIAL DE GUADALAJARA S A DE C V','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007600','PLOMERIA UNIVERSAL DE OCCIDENTE S A DE C V','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','POTENCIA FLUIDA QUERÉTARO','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10003202','POTENCIA FLUIDA TORREON, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10003302','POTENCIA FLUIDA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10005400','PROVEEDORA ARNOR, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','PROVEEDORA INDUSTRIAL DE VALVULAS','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','PROYECTOS GLOBAL SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003500','PUBLICIDAD EN IMAGEN, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','PUBLIREX','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003700','ROBERTO GERARDO LICONA LOPEZ','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007200','SAYCO INTERNACIONAL, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003800','SERVICIOS DE ANUNCIOS PUBLICITARIOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10005800','SIS ELECTRON, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009100','SOPORTE EN ELECTRICIDAD Y CONTROL, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10006000','SSTEEL COMERCIALIZADORA INDUSTRIAL, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','SUMINISTROS INDUSTRIALES MONTERO SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003900','TECNO TUBOS VH, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10006400','TELETEC DE MEXICO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10006100','TODO DE TUBOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','TRANSPORTES GAMMA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004000','TREFILADOS Y CLAVOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10007500','TRIDAN','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004102','TUBERIA LAGUNA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10008000','TUBERIA Y LAMINA DE DURANGO SA DE CV','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10007900','TUBERIA Y PLACA DE ACERO, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004501','TUBERIA Y VALVULAS S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004700','TUBERIAS ACCESORIOS Y RECUBRIMIENTOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004103','TUBERIAS AGRICOLAS E INDUSTRIALES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','TUBERIAS ARSO','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004300','TUBERIAS VALVULAS Y CONEXIONES DE LOS ALTOS, S.DER.L.DEC.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10010000','TUBERIAS VISA DE CULIACAN, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004401','TUBERIAS VISA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004900','TUBERIAS Y ACCESORIOS SAGA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004500','TUBERIAS Y FIERROS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009900','TUBERIAS Y VALVULAS DEL NOROESTE S A DE C V','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004402','TUBERIAS, ACCESORIOS Y RECUBRIMIENTOS S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004600','TUBO Y ACERO DE MONTERREY, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004700','TUBOS Y EQUIPOS, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10004405','TUBOS Y MATERIALES TUYMA S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','TUBOS, REFACCIONES Y VALVULAS INDUSTRIALES','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003901','TUMATSA MONTERREY, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10005500','TUVAMSA S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ULTRAINGENIERIA','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10004201','VACONSA DEL NORTE, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10003400','VALVULAS INDUSTRIALES DE TOLUCA, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('D10005100','VALVULAS Y REFACCIONES INDUSTRIALES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('P10009200','VIEJO FERRETERIA Y MATERIALES, S.A. DE C.V.','A','admin',GETDATE());
INSERT INTO [dbo].[Customer]([ShortName],[Description],[Active],[Creator],[Created]) VALUES('S/N','ZUVAL ACEROS','A','admin',GETDATE());

SELECT * FROM [dbo].[Customer];
*/