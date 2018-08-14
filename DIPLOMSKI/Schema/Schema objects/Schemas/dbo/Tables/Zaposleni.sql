CREATE
  TABLE Zaposleni
  (
    MBR           VARCHAR (50) NOT NULL ,
    DAT           DATETIME2 NOT NULL ,
    IME           VARCHAR (70) NOT NULL ,
    PRZ           VARCHAR (70) NOT NULL ,
    TEL           VARCHAR (50) NOT NULL ,
    PLT           DECIMAL (18) NOT NULL ,
    Restoran_ID   INTEGER ,
    Zaposleni_MBR VARCHAR (50)
  )
  ON "default"
GO
